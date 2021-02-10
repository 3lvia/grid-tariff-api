using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models;
using GridTariffApi.Lib.Models.TariffQuery;
using GridTariffApi.Lib.Services.TariffQuery;
using GridTariffApi.Lib.Services.TariffType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GridTariffApi.Lib.Controllers.v1
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/tariffquery")]
    public class TariffQueryController : ControllerBase
    {
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITariffQueryService _tariffQueryService;
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        public TariffQueryController(
            ITariffTypeService tariffTypeService,
            ITariffQueryService tariffQueryService,
            GridTariffApiConfig gridTariffApiConfig)
        {
            _tariffTypeService = tariffTypeService;
            _tariffQueryService = tariffQueryService;
            _gridTariffApiConfig = gridTariffApiConfig;
        }


        /// <summary>
        /// Returns tariff data for a given set of meteringpoints for a given timeperiod.
        /// </summary>
        /// <remarks>Returns tariff data for a given set of meteringpoints for a given timeperiod.</remarks>
        /// <param name="TariffQueryRequestMeteringPoints"></param>
        /// JSON format. <br></br>
        /// MeteringPointIds ditctates which meteringpoints to return tariff data for.<br></br>
        /// If a meteringpointid is unknown to api it will be omitted from the response.<br></br>
        /// Range dictates which day to query. Valid values is yesterday,today,tomorrow<br></br>
        /// StartTime/EndTime dictates which timeperiod to query.<br></br>
        /// Range and StartTime/Endtime is mutual exclusive, meaning either one must be present, but not both.<br></br>
        /// <returns>TariffData matching query parameters, also including meteringpoints associated with each tariff.</returns>

        [HttpPost]
        [Route("meteringpointsgridtariffs")]
        public IActionResult GridTariffsByMeteringPoints([FromBody] TariffQueryRequestMeteringPoints tariffQueryRequest)
        {
            DateTime startDateTime = GetStartTime(tariffQueryRequest.Range, tariffQueryRequest.StartTime);
            DateTime endDateTime = GetEndTime(tariffQueryRequest.Range, tariffQueryRequest.EndTime);
            var result = _tariffQueryService.QueryTariff(tariffQueryRequest.MeteringPointIds, startDateTime, endDateTime);
            return Ok(result);
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
            string validationErrorMsg = ValidateRequestInput(tariffQueryRequest);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }

            DateTime startDateTime = GetStartTime(tariffQueryRequest.Range, tariffQueryRequest.StartTime);
            DateTime endDateTime = GetEndTime(tariffQueryRequest.Range, tariffQueryRequest.EndTime);
            TariffQueryResult tariffQueryResult = _tariffQueryService.QueryTariff(tariffQueryRequest.TariffKey, startDateTime, endDateTime);
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

            DateTime startDateTime = GetStartTime(tariffQueryModel.Range, tariffQueryModel.StartTime);
            if (startDateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }
            return String.Empty;
        }

        public DateTime GetStartTime(string? range, DateTime? startDateTime)
        {
            if (startDateTime.HasValue)
            {
                return (DateTime)startDateTime;
            }
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime);

        }

        public DateTime GetEndTime(string? range, DateTime? endDateTime)
        {
            if (endDateTime.HasValue)
            {
                return (DateTime)endDateTime;
            }
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime.AddDays(1).AddSeconds(-1));
        }

        private DateTime AddDaysUsingQueryRangeParameter(string? range, DateTime dateTime)
        {
            if (!String.IsNullOrEmpty(range))
            {
                if (range.Equals("yesterday"))
                {
                    return dateTime.AddDays(-1);
                }
                if (range.Equals("tomorrow"))
                {
                    return dateTime.AddDays(1);
                }
            }
            return dateTime;
        }

        private DateTime GetTimeZonedDateTime(DateTime datetime)
        {
            var timeZonedDateTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, _gridTariffApiConfig.TimeZoneForQueries);
            return timeZonedDateTime;
        }
    }
}
