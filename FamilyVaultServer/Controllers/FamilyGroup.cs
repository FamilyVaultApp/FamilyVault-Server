using FamilyVaultServer.Models.Requests;
using FamilyVaultServer.Models.Responses;
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
        public async Task<ActionResult<CreateFamilyGroupResponse>> Create(CreateFamilyGroupRequest request)
        {
            try
            {
                var response = await _privMx.CreateContext(request.Name, request.Description, "private");
                
                return Ok(new CreateFamilyGroupResponse { ContextId = response.ContextId});    
            }
            catch (Exception e)
            {
                // TODO: Stworzyć model error respose
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}
