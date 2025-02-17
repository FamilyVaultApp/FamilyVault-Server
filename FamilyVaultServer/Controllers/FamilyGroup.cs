using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Services.PrivMx;
using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FamilyGroup : ControllerBase
    {
        IPrivMxService _privMx;
        public FamilyGroup(IPrivMxService privMx)
        {
            _privMx = privMx;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.CreateContext(request.Name, request.Description, "private");
                
                return Ok(new { result = response });    
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}
