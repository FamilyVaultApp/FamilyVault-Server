using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
using FamilyVaultServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("JoinStatus/[action]")]
    [ApiController]
    public class JoinStatusController : ControllerBase
    {
        private IJoinStatusService _joinStatusService { get; set; }
        public JoinStatusController(IJoinStatusService joinStatusService)
        {
            _joinStatusService = joinStatusService;
        }

        [HttpGet]
        public ActionResult<JoinStatusResponse> Generate()
        {
            return new JoinStatusResponse
            {
                Status = _joinStatusService.GenerateNew()
            };
        }

        [HttpPost]
        public ActionResult Delete(JoinStatusTokenRequest req)
        {
            _joinStatusService.Delete(req.Token);

            return Ok();
        }

        [HttpGet]
        public ActionResult<JoinStatusResponse> GetByToken([FromQuery] JoinStatusTokenRequest req)
        {
            var statusToken = _joinStatusService.GetStatusByToken(req.Token);

            if (statusToken == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new JoinStatusResponse { Status = statusToken });
            }
        }

        [HttpPost]
        public ActionResult<JoinStatusResponse> UpdateStatus(JoinStatusUpdateRequest req)
        {
            var statusToken = _joinStatusService.UpdateStatus(req.Token, req.State);

            if (statusToken == null)
            {
                return NotFound();
            }


            if (req.Info != null)
            {
                _joinStatusService.UpdateInfo(req.Token, req.Info);
            }

            return Ok(new JoinStatusResponse { Status = statusToken });
        }
    }
}
