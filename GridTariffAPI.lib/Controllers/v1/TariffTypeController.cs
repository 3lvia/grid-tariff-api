using Elvia.Telemetry;
using GridTariffApi.Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Controllers.v1
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("digin/api/{v:apiVersion}")]

    public class TariffTypeController : ControllerBase
    {
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITelemetryInsightsLogger _logger;

        public TariffTypeController(ITariffTypeService tariffTypeService,
            ITelemetryInsightsLogger telemetryInsightsLogger)
        {
            _tariffTypeService = tariffTypeService;
            _logger = telemetryInsightsLogger;

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
            try
            {
                var result = await _tariffTypeService.GetTariffTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.TrackException(ex);
                return Problem(ex.Message);
            }
        }
    }
}
