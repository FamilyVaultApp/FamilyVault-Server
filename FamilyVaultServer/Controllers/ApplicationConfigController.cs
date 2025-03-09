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

        public ApplicationConfigController(IOptions<PrivMxOptions> privMxOptions, IPrivMxService privMxService)
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
