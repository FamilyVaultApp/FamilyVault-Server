using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FamilyMember : ControllerBase
    {
        IPrivMxService _privMx;
        public FamilyMember(IPrivMxService privMx)
        {
            _privMx = privMx;
        }

        [HttpPost]
        public async Task<ActionResult> AddGuardianToFamily(AddMemberToFamilyGroupRequest request)
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
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMemberToFamily(AddMemberToFamilyGroupRequest request)
        {
            try
            {
                await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddGuestToFamily(AddMemberToFamilyGroupRequest request)
        {
            try
            {
                await _privMx.AddUserToContext(request.ContextId, request.UserId, request.UserPubKey, "DENY ALL");

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}
