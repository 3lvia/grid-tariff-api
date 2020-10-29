using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kunde.TariffApi.Controllers
{
    /// <summary>
    /// Ping to validate security
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SecureController : ControllerBase
    {

        /// <summary>
        /// Ping to validate security
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
