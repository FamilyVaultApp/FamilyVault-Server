using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("FamilyGroupMemberJoinStatus/[action]")]
    [ApiController]
    public class FamilyGroupMemberJoinController : ControllerBase
    {
        private IFamilyGroupMemberJoinService _familyGroupMemberJoinService { get; set; }
        public FamilyGroupMemberJoinController(IFamilyGroupMemberJoinService familyGroupmemberJoinService)
        {
            _familyGroupMemberJoinService = familyGroupmemberJoinService;
        }

        [HttpGet]
        public ActionResult<FamilyGroupMemberJoinResponse> Generate()
        {
            return new FamilyGroupMemberJoinResponse
            {
                FamilyGroupMemberJoinStatus = _familyGroupMemberJoinService.GenerateNew()
            };
        }
        [HttpDelete]
        public ActionResult Delete(FamilyGroupMemberJoinTokenRequest req)
        {
            _familyGroupMemberJoinService.Delete(req.Token);

            return Ok();
        }
        [HttpGet]
        public ActionResult<FamilyGroupMemberJoinResponse> GetByToken([FromQuery] FamilyGroupMemberJoinTokenRequest req)
        {
            var statusToken = _familyGroupMemberJoinService.GetStatusByToken(req.Token);

            if (statusToken == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FamilyGroupMemberJoinResponse { FamilyGroupMemberJoinStatus = statusToken });
            }
        }
        [HttpPost]
        public ActionResult<FamilyGroupMemberJoinResponse> UpdateStatus(FamilyGroupMemberJoinStatusUpdateRequest req)
        {
            var statusToken = _familyGroupMemberJoinService.UpdateStatus(req.Token, req.Status);

            if (statusToken == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FamilyGroupMemberJoinResponse { FamilyGroupMemberJoinStatus = statusToken });
            }
        }
        [HttpPost]
        public ActionResult<FamilyGroupMemberJoinResponse> UpdateInfo(FamilyGroupMemberJoinUpdateInfoRequest req)
        {
            var statusToken = _familyGroupMemberJoinService.UpdateInfo(req.Token, req.Info);

            if (statusToken == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FamilyGroupMemberJoinResponse { FamilyGroupMemberJoinStatus = statusToken });
            }
        }
    }
}
