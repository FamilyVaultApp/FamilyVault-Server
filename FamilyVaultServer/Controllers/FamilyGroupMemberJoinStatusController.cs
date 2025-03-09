using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("FamilyGroupMemberJoinStatus/[action]")]
    [ApiController]
    public class FamilyGroupMemberJoinStatusController : Controller
    {
        private IFamilyGroupMemberJoinService _familyGroupMemberJoinService { get; set; }
        public FamilyGroupMemberJoinStatusController(IFamilyGroupMemberJoinService familyGroupmemberJoinService)
        {
            _familyGroupMemberJoinService = familyGroupmemberJoinService;
        }

        [HttpGet]
        public ActionResult<FamilyGroupMemberJoinStatusResponse> Generate()
        {
            return new FamilyGroupMemberJoinStatusResponse
            {
                FamilyGroupMemberJoinStatus = _familyGroupMemberJoinService.GenerateNew()
            };
        }
        [HttpDelete]
        public ActionResult Delete(FamilyGroupMemberTokenRequest req)
        {
            _familyGroupMemberJoinService.Delete(req.Token);

            return Ok();
        }
        [HttpGet]
        public ActionResult<FamilyGroupMemberJoinStatusResponse> GetByToken([FromQuery] FamilyGroupMemberTokenRequest req)
        {
            var statusToken = _familyGroupMemberJoinService.GetStatusByToken(req.Token);

            if (statusToken is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FamilyGroupMemberJoinStatusResponse { FamilyGroupMemberJoinStatus = statusToken });
            }
        }
        [HttpPost]
        public ActionResult<FamilyGroupMemberJoinStatusResponse> UpdateStatus(FamilyGroupMemberJoinStatusUpdateRequest req)
        {
            var statusToken = _familyGroupMemberJoinService.UpdateStatus(req.Token, req.Status);

            if (statusToken == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FamilyGroupMemberJoinStatusResponse { FamilyGroupMemberJoinStatus = statusToken });
            }
        }
        [HttpPost]
        public ActionResult<FamilyGroupMemberJoinStatusResponse> UpdateInfo(FamilyGroupMemberJoinUpdateInfoRequest req)
        {
            var statusToken = _familyGroupMemberJoinService.UpdateInfo(req.Token, req.Info);

            if (statusToken == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FamilyGroupMemberJoinStatusResponse { FamilyGroupMemberJoinStatus = statusToken });
            }
        }
    }
}
