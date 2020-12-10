using Elvia.Telemetry;
using Kunde.TariffApi.Config;
using Kunde.TariffApi.Models;
using Kunde.TariffApi.Models.TariffQuery;
using Kunde.TariffApi.Services.TariffQuery;
using Kunde.TariffApi.Services.TariffType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kunde.TariffApi.Controllers.v1
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/tariffquery")]
    public class TariffQueryController : ControllerBase
    {
        private readonly ITelemetryInsightsLogger _telemetry;
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITariffQueryService _tariffQueryService;
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        public TariffQueryController(
            ITelemetryInsightsLogger telemetry,
            ITariffTypeService tariffTypeService,
            ITariffQueryService tariffQueryService,
            GridTariffApiConfig gridTariffApiConfig)
        {
            _telemetry = telemetry;
            _tariffTypeService = tariffTypeService;
            _tariffQueryService = tariffQueryService;
            _gridTariffApiConfig = gridTariffApiConfig;
        }

        /// <summary>
        /// Returns tariff data for a given tariff for a given timeperiod
        /// </summary>
        /// <remarks>Returns tariff data for a given tariff for a given timeperiod</remarks>
        /// <param name="tariffQueryRequest"></param>
        /// JSON format. <br></br>
        /// TariffKey dictates which tariff will be queried<br></br>
        /// Range dictates which day to query. Valid values is yesterday,today,tomorrow<br></br>
        /// StartTime/EndTime dictates which timeperiod to query.<br></br>
        /// Range and StartTime/Endtime is mutual exclusive, meaning either one must be present, but not both<br></br>
        /// <returns>TariffData matching query parameters</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] TariffQueryRequest tariffQueryRequest)
        {
            var processingTime = Stopwatch.StartNew();
            string validationErrorMsg = ValidateRequestInput(tariffQueryRequest);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }
            DateTime startDateTime = GetStartTime(tariffQueryRequest);
            DateTime endDateTime = GetEndTime(tariffQueryRequest);
            TariffQueryResult tariffQueryResult = _tariffQueryService.QueryTariff(tariffQueryRequest.TariffKey, startDateTime, endDateTime);
            _telemetry.TrackMetric($"TariffAPI|TimeToQueryTariffsInSeconds", (double)processingTime.ElapsedMilliseconds / 1000);
            return Ok(tariffQueryResult);
        }


        private string ValidateRequestInput(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel == null)
            {
                return "Missing model";
            }

            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            if (!tariffTypeContainer.TariffTypes.Exists(t => t.TariffKey.Equals(tariffQueryModel.TariffKey)))
            {
                return $"TariffType {tariffQueryModel.TariffKey} not found";
            }

            DateTime startDateTime = GetStartTime(tariffQueryModel);
            if (startDateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }
            return String.Empty;
        }

        private DateTime GetStartTime(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel.StartTime.HasValue)
            {
                return (DateTime)tariffQueryModel.StartTime;
            }
            return AddDaysUsingQueryRangeParameter(tariffQueryModel, DateTime.UtcNow.Date);
        }

        private DateTime GetEndTime(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel.EndTime.HasValue)
            {
                return (DateTime)tariffQueryModel.EndTime;
            }
            return AddDaysUsingQueryRangeParameter(tariffQueryModel, DateTime.UtcNow.Date.AddDays(1).AddSeconds(-1));
        }

        private DateTime AddDaysUsingQueryRangeParameter(TariffQueryRequest tariffQueryRequest, DateTime dateTime)
        {
            if (!String.IsNullOrEmpty(tariffQueryRequest.Range))
            {
                if (tariffQueryRequest.Range.Equals("yesterday"))
                {
                    return dateTime.AddDays(-1);
                }
                if (tariffQueryRequest.Range.Equals("tomorrow"))
                {
                    return dateTime.AddDays(1);
                }
            }
            return dateTime;
        }
    }
}
