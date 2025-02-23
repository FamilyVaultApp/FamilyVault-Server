using FamilyVaultServer.Exceptions;
using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FamilyGroup : ControllerBase
    {
        IPrivMxService _privMx;
        public FamilyGroup(IPrivMxService privMx)
        {
            _privMx = privMx;
        }

        [HttpPost]
        public async Task<ActionResult<CreateFamilyGroupResponse>> CreateFamilyGroup(CreateFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.CreateContext(request.Name, request.Description, "private");
                
                return Ok(new CreateFamilyGroupResponse { ContextId = response.ContextId});    
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
    }
}
