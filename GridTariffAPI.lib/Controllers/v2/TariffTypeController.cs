using GridTariffApi.Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Controllers.v2
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/powerbased")]

    public class TariffTypeController : ControllerBase
    {
        private readonly ITariffTypeService _tariffTypeService;
        public TariffTypeController(ITariffTypeService tariffTypeService)
        {
            _tariffTypeService = tariffTypeService;
        }

        /// <summary>
        /// Service returns all available private tariffs
        /// </summary>
        /// <remarks>Service returns all available tariffs</remarks>
        /// <returns>All tariffs</returns>
        [HttpGet]
        [Route("tarifftype")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Models.Digin.TariffTypeContainer>> Get()
        {
            var result = await _tariffTypeService.GetTariffTypes();
            return Ok(result);
        }
    }
}
