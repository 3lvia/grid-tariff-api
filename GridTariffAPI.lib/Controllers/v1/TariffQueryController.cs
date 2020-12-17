using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using GridTariffApi.Lib.Services.TariffType;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Services.TariffQuery;
using GridTariffApi.Lib.Models.TariffQuery;
using GridTariffApi.Lib.Models;
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
            DateTime startDateTime = GetStartTime(tariffQueryRequest);
            DateTime endDateTime = GetEndTime(tariffQueryRequest);
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
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(tariffQueryModel, timeZonedDateTime);
        }

        private DateTime GetTimeZonedDateTime(DateTime datetime)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(_gridTariffApiConfig.TimeZone);
            var timeZonedDateTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, timeZone);
            return timeZonedDateTime;
        }

        private DateTime GetEndTime(TariffQueryRequest tariffQueryModel)
        {
            if (tariffQueryModel.EndTime.HasValue)
            {
                return (DateTime)tariffQueryModel.EndTime;
            }
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(tariffQueryModel, timeZonedDateTime.AddDays(1).AddSeconds(-1));
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
