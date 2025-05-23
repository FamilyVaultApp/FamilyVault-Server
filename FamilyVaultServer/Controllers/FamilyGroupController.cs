﻿using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services.PrivMx;
using FamilyVaultServer.Services.PrivMx.Models;
using FamilyVaultServer.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FamilyVaultServer.Controllers
{
    [Route("FamilyGroup/[action]")]
    [ApiController]
    public class FamilyGroupController : ControllerBase
    {
        IPrivMxService _privMx;
        public FamilyGroupController(IPrivMxService privMx)
        {
            _privMx = privMx;
        }

        [HttpPost]
        public async Task<ActionResult<CreateFamilyGroupResponse>> CreateFamilyGroup(CreateFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.CreateContext(request.Name, request.Description, "private");

                return Ok(new CreateFamilyGroupResponse { ContextId = response.ContextId });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddMemberToFamilyGroupResponse>> AddMemberToFamilyGroup(AddMemberToFamilyGroupRequest request)
        {
            try
            {
                var aclPermissions = PermissionGroupToAclMapper.Map(request.Role);
                await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, aclPermissions);

                return Ok(new AddMemberToFamilyGroupResponse { });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ListMembersFromFamilyGroupResponse>> ListMembersFromFamilyGroup(ListMembersFromFamilyGroupRequest request)
        {
            try
            {
                var listUsersFromContextResponse = await _privMx.ListUsersFromContext(request.ContextId, 0, 100, "desc");

                return Ok(new ListMembersFromFamilyGroupResponse
                {
                    Members = listUsersFromContextResponse.Users.Select(FamilyGroupMember.FromPrivMxContextUser).ToList(),
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetMemberFromFamilyGroupResponse>> GetMemberFromFamilyGroup(GetMemberFromFamilyGroupRequest request)
        {
            try
            {
                PrivMxContextUser? contextUser = null;

                if (request.UserId is not null)
                {
                    contextUser = (await _privMx.GetUserFromContext(request.ContextId, request.UserId)).User;
                }

                if (request.PublicKey is not null)
                {
                    contextUser = (await _privMx.GetUserFromContextByPubKey(request.ContextId, request.PublicKey)).User;
                }

                if (contextUser is null)
                {
                    return NotFound("User not found with the specified public key or user ID");
                }

                return Ok(new GetMemberFromFamilyGroupResponse
                {
                    Member = FamilyGroupMember.FromPrivMxContextUser(contextUser)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<RenameFamilyGroupResponse>> Rename(RenameFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.UpdateContext(request.ContextId, request.Name);

                return Ok(new RenameFamilyGroupResponse { });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ChangeMemberPermissionGroupResponse>> ChangeMemberPermissionGroup(ChangeMemberPermissionGroupRequest request)
        {
            try
            {
                var aclPermissions = PermissionGroupToAclMapper.Map(request.Role);
                await _privMx.SetUserAcl(request.ContextId, request.UserId, aclPermissions);

                return Ok(new ChangeMemberPermissionGroupResponse { });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<RemoveMemberFromFamilyGroupResponse>> RemoveMemberFromFamilyGroup(RemoveMemberFromFamilyGroupRequest request)
        {
            try
            {
                await _privMx.RemoveUserFromContextByPubKey(request.ContextId, request.UserPubKey);

                return Ok(new RemoveMemberFromFamilyGroupResponse { });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetFamilyGroupNameResponse>> GetFamilyGroupName(GetFamilyGroupNameRequest request)
        {
            try
            {
                var getContextResponse = await _privMx.GetContext(request.ContextId);

                return Ok(new GetFamilyGroupNameResponse
                {
                    FamilyGroupName = getContextResponse.Context.Name
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }
    }
}
