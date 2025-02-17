using FamilyVaultServer.Models.Responses;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using FamilyVaultServer.Services.PrivMx;

namespace FamilyVaultServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApplicationConfig : ControllerBase
    {
        private readonly IOptions<PrivMxOptions> _privMxOptions;
        private readonly IPrivMxService _privMxService;

        public ApplicationConfig(IOptions<PrivMxOptions> privMxOptions, IPrivMxService privMxService)
        {
            _privMxOptions = privMxOptions;
            _privMxService = privMxService;
        }

        [HttpGet]
        public ActionResult<GetPrivMxUrlResponse> GetPrivMxUrl()
        {
            return Ok(new GetPrivMxUrlResponse { Url = _privMxOptions.Value.Url });
        }

        [HttpGet]
        public async Task<ActionResult<GetSolutionIdResponse>> GetSolutionId()
        {
            return Ok(new GetSolutionIdResponse { SolutionId = await _privMxService.GetSolutionId() });
        }
    }
}
