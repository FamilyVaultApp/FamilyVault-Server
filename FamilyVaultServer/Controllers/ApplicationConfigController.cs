using FamilyVaultServer.Models.Responses;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using FamilyVaultServer.Services.PrivMx;

namespace FamilyVaultServer.Controllers
{
    [Route("ApplicationConfig/[action]")]
    [ApiController]
    public class ApplicationConfigController : ControllerBase
    {
        private readonly IPrivMxService _privMxService;
        private readonly string _bridgeUrl;

        public ApplicationConfigController(IOptions<PrivMxOptions> privMxOptions, IPrivMxService privMxService)
        {
            _privMxService = privMxService;
            _bridgeUrl = privMxOptions.Value.Url;
        }

        [HttpGet]
        public async Task<ActionResult<GetSolutionIdResponse>> GetSolutionId()
        {
            return Ok(new GetSolutionIdResponse { SolutionId = await _privMxService.GetSolutionId() });
        }

        [HttpGet]
        public ActionResult<GetBridgeUrlResponse> GetBridgeUrl()
        {
            return Ok(new GetBridgeUrlResponse { BridgeUrl = _bridgeUrl });
        }
    }
}
