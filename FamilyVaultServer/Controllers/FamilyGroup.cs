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
        public async Task<IActionResult> Create(CreateFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.CreateFamilyGroup(request.Solution, request.Name, request.Description, request.Scope);
                
                return Ok(new { result = response.Result });    
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}
