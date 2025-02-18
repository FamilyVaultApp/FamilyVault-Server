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
        private readonly IPrivMxService _privMxService;

        public ApplicationConfig(IOptions<PrivMxOptions> privMxOptions, IPrivMxService privMxService)
        {
            _privMxService = privMxService;
        }

        [HttpGet]
        public async Task<ActionResult<GetSolutionIdResponse>> GetSolutionId()
        {
            return Ok(new GetSolutionIdResponse { SolutionId = await _privMxService.GetSolutionId() });
        }
    }
}
