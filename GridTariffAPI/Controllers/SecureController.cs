using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GridTariffApi.Controllers
{
    /// <summary>
    /// Ping to validate security
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + "BasicAuthentication")]
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
