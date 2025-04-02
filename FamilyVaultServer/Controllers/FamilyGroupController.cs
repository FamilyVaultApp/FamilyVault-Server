using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services.PrivMx;
using FamilyVaultServer.Services.PrivMx.Models.Result;
using FamilyVaultServer.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

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
                var responseJson = await _privMx.PrivMxListUsersFromContext(request.ContextId, 0, 100, "desc");

                return Ok(new ListMembersFromFamilyGroupResponse
                {
                    Members = responseJson.Users.Select(FamilyGroupMember.FromPrivMxContextUser).ToList(),
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
        public async Task<ActionResult<ChangeMemberPermissionGroupResponse>> ChangeMemberPermmissionGroup(ChangeMemberPermissionGroupRequest request)
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
        public async Task<ActionResult<GetFamilyGroupInformation_ContextInfo>> GetFamilyGroupInformation(GetFamilyGroupInformationRequest request)
        {
            try
            {
                var responseJson = await _privMx.GetContext(request.ContextId);

                return Ok(new GetFamilyGroupInformation_ContextInfo
                {
                    Id = responseJson.ContextInfo.Id,
                    Created = responseJson.ContextInfo.Created,
                    Modified = responseJson.ContextInfo.Modified,
                    Solution = responseJson.ContextInfo.Solution,
                    Shares = responseJson.ContextInfo.Shares,
                    Name = responseJson.ContextInfo.Name,
                    Description = responseJson.ContextInfo.Description,
                    Scope = responseJson.ContextInfo.Scope,
                    Policy = responseJson.ContextInfo.Policy
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }
    }
}
