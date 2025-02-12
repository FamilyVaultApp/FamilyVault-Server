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
            try
            {
                await _privMx.CreateFamilyGroup(request.Solution, request.Name, request.Description, request.Scope);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
