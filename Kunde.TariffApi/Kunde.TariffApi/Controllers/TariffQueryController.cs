using Elvia.Telemetry;
using Kunde.TariffApi.Models;
using Kunde.TariffApi.Models.TariffQuery;
using Kunde.TariffApi.Services.TariffQuery;
using Kunde.TariffApi.Services.TariffType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kunde.TariffApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TariffQueryController : ControllerBase
    {
        private readonly ITelemetryInsightsLogger _telemetry;
        private static readonly List<string> _allowedRangeValues = new List<string> { "yesterday", "today", "tomorrow" };
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITariffQueryService _tariffQueryService;
        public TariffQueryController(ITelemetryInsightsLogger telemetry, ITariffTypeService tariffTypeService, ITariffQueryService tariffQueryService)
        {
            _telemetry = telemetry;
            _tariffTypeService = tariffTypeService;
            _tariffQueryService = tariffQueryService;
        }

        /// <summary>
        /// Returns tariff data for a given tariff for a given timeperiod
        /// </summary>
        /// <remarks>Returns tariff data for a given tariff for a given timeperiod</remarks>
        /// <param name="tariffQueryRequest">
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

        private DateTime GetStartTime(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel.StartTime.HasValue)
            {
                return (DateTime)tariffQueryModel.StartTime;
            }
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return AddDaysUsingQueryRangeParameter(tariffQueryModel, startTime);
        }

        private DateTime GetEndTime(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel.EndTime.HasValue)
            {
                return (DateTime)tariffQueryModel.EndTime;
            }
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            return AddDaysUsingQueryRangeParameter(tariffQueryModel, startTime);
        }

        private DateTime AddDaysUsingQueryRangeParameter(TariffQueryRequest tariffQueryModel, DateTime dateTime)
        {
            int indexpos = _allowedRangeValues.IndexOf(tariffQueryModel.Range);
            if (indexpos == 0)
            {
                return dateTime.AddDays(-1);
            }
            if (indexpos == 2)
            {
                return dateTime.AddDays(1);
            }
            return dateTime;
        }

        private string ValidateRequestInput(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel == null)
            {
                return "Missing model";
            }
            if (String.IsNullOrEmpty(tariffQueryModel.TariffKey))
            {
                return "Missing TariffKey";
            }
            bool hasRange = !String.IsNullOrEmpty(tariffQueryModel.Range);
            bool hasStart = tariffQueryModel.StartTime.HasValue;
            bool hasEnd = tariffQueryModel.EndTime.HasValue;

            if (!hasRange && !(hasStart || hasEnd))
            {
                return "Neither range nor StartTime/Endtime set";
            }

            if (hasRange)
            {
                if (hasStart || hasEnd)
                {
                    return "Both range and StartTime/Endtime set";
                }
                if (!(_allowedRangeValues.Exists(x => x.Equals(tariffQueryModel.Range))))
                {
                    string values = String.Empty;
                    foreach (String allowedRangeValue in _allowedRangeValues) { values = $"{values} {allowedRangeValue}"; };
                    return $"Illegal value for range. Allowd values: {values}";
                }
            }
            else
            {
                if (!hasStart || !hasEnd)
                {
                    return "Both Start and end must be present";
                }
                if (tariffQueryModel.StartTime > tariffQueryModel.EndTime)
                {
                    return "Starttime is greather than EndTime";
                }
            }

            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            if (!tariffTypeContainer.TariffTypes.Exists(t => t.TariffKey.Equals(tariffQueryModel.TariffKey)))
            {
                return $"TariffType {tariffQueryModel.TariffKey} not found";
            }
            return String.Empty;
        }
    }
}
