using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<AddMemberToFamilyGroupResponse>> AddGuardianToFamilyGroup(AddMemberToFamilyGroupRequest request)
        {
            // TODO Określić ACLe format:
            // w stringu = ALLOW store/READ\nALLOW thread/ALL

            try
            {
                await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");

                return Ok();
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
                await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddMemberToFamilyGroupResponse>> AddGuestToFamilyGroup(AddMemberToFamilyGroupRequest request)
        {
            try
            {
                await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");

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
                var response = await _privMx.UpdateContext(request.ContextId, request.Name);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<SetUserAclResponse>> SetUserAcl(SetUserAclRequest request)
        {
            // TODO: Gdy będą już zdefiniowane ACL dać enum na 3 z nich
            try
            {
                var response = await _privMx.SetUserAcl(request.ContextId, request.UserId, "ALLOW ALL");

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseError { Message = e.Message });
            }
        }
    }
}
