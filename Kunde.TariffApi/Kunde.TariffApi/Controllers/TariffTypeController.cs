using Elvia.Telemetry;
using Kunde.TariffApi.Models;
using Kunde.TariffApi.Services.TariffType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kunde.TariffApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TariffTypeController : ControllerBase
    {
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITelemetryInsightsLogger _telemetry;
        public TariffTypeController(ITariffTypeService tariffTypeService, ITelemetryInsightsLogger telemetry)
        {
            _tariffTypeService = tariffTypeService;
            _telemetry = telemetry;
        }
        /// <summary>
        /// Get all tariffs
        /// </summary>
        /// <remarks>Service returns all available tariffs</remarks>
        /// <returns>All tariffs</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var processingTime = Stopwatch.StartNew();
            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            _telemetry.TrackMetric($"TariffAPI|TimeToGetTariffTypesInSeconds", (double)processingTime.ElapsedMilliseconds / 1000);

            return Ok(_tariffTypeService.GetTariffTypes());
        }

    }
}
