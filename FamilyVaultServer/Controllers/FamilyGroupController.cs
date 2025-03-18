using FamilyVaultServer.Models;
using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

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
                switch (request.Role)
                {
                    case FamilyGroupMemberPermissionGroup.Guardian:
                        await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");
                        break;
                    case FamilyGroupMemberPermissionGroup.Member:
                        await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");
                        break;
                    case FamilyGroupMemberPermissionGroup.Guest:
                        await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");
                        break;
                    default:
                        throw new ArgumentException("Unknown family role.");
                }

                return Ok();
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
        public async Task<ActionResult<RenameFamilyGroupResponse>> RenameFamilyGroup(RenameFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.UpdateContext(request.ContextId, request.Name, null, null, null);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ChangeUserPermmissionGroupResponse>> ChangeUserPermmissionGroup(ChangeUserPermmissionGroupRequest request)
        {
            try
            {
                switch (request.Role)
                {
                    case FamilyGroupMemberPermissionGroup.Guardian:
                        await _privMx.SetUserAcl(request.ContextId, request.UserId, "ALLOW ALL");
                        break;
                    case FamilyGroupMemberPermissionGroup.Member:
                        await _privMx.SetUserAcl(request.ContextId, request.UserId, "ALLOW ALL");
                        break;
                    case FamilyGroupMemberPermissionGroup.Guest:
                        await _privMx.SetUserAcl(request.ContextId, request.UserId, "ALLOW ALL");
                        break;
                    default:
                        throw new ArgumentException("Unknown family role.");
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }
    }
}
