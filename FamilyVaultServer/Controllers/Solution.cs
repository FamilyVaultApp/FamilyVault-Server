using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class Solution : ControllerBase
    {
        IPrivMxBridgeService _privMx;
        public Solution(IPrivMxBridgeService privMx)
        {
            _privMx = privMx;
        }

        [Route("")]
        [HttpPost]
        public async Task Create(CreateSolutionRequest request)
        {
            // TODO: Reagować na błędy i poprawić response
            await _privMx.CreateSolution(request.Name);
        }
    }
}
