using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FamilyGroup : ControllerBase
    {
        IPrivMxBridgeService _privMx;
        public FamilyGroup(IPrivMxBridgeService privMx)
        {
            _privMx = privMx;
        }

        [Route("")]
        [HttpPost]
        public async Task Create(CreateFamilyGroupRequest request)
        {
            // TODO: Reagować na błędy i poprawić response
            await _privMx.CreateSolution(request.Name);
        }
    }
}
