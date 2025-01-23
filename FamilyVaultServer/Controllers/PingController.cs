using Microsoft.AspNetCore.Mvc;

namespace FamilyVaultServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }
    }
}
