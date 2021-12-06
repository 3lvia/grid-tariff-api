using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.TariffQuery;
using GridTariffApi.Lib.Models.V2.Digin;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.V2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Controllers.v2
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/powerbased")]
    public class TariffQueryController : ControllerBase
    {
        private readonly ITariffQueryService _tariffQueryService;
        private readonly IServiceHelper _serviceHelper;
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        private readonly ITariffPriceCache _tariffPriceCache;
        public TariffQueryController(ITariffQueryService tariffQueryService,
            IServiceHelper serviceHelper,
            GridTariffApiConfig gridTariffApiConfig,
            ITariffPriceCache tariffPriceCache)
        {
            _tariffQueryService = tariffQueryService;
            _serviceHelper = serviceHelper;
            _gridTariffApiConfig = gridTariffApiConfig;
            _tariffPriceCache = tariffPriceCache;
        }


        /// <summary>
        /// Returns tariff data for a given set of meteringpoints for a given timeperiod.
        /// </summary>
        /// Range and StartTime/Endtime is mutual exclusive, meaning either one must be present, but not bot. Date time formats using Edielstandard, see README file
        [HttpGet]
        [Route("tariffquery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Models.V2.Digin.TariffQueryResult>> TariffQuery([FromQuery] TariffQueryRequest tariffQueryRequest)  
        {
            //todo no TariffQueryRequest present in Digin. Todo FromQuery or FromBody?
            string validationErrorMsg = ValidateRequestInput(tariffQueryRequest);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }
            DateTimeOffset startDateTime = _serviceHelper.GetStartDateTimeOffset(tariffQueryRequest.Range, tariffQueryRequest.StartTime);
            DateTimeOffset endDateTime = _serviceHelper.GetEndDateTimeOffset(tariffQueryRequest.Range, tariffQueryRequest.EndTime);
            var result = await _tariffQueryService.QueryTariffAsync(tariffQueryRequest.TariffKey, startDateTime, endDateTime);
            return Ok(result);
        }
        private string ValidateRequestInput(TariffQueryRequest tariffQueryModel)
        {
            //todo netproduct missing from model
            //todo either tariffkey or netproduct
            if (tariffQueryModel == null)
            {
                return "Missing model";
            }

            var tariffs = _tariffPriceCache.GetTariffs().ToList();
            if (!tariffs.Exists(x => x.TariffKey == tariffQueryModel.TariffKey))
            {
                return $"TariffType {tariffQueryModel.TariffKey} not found";
            }

            //todo either tariffkey or netproduct

            //todo datetimeoffset
            DateTime startDateTime = _serviceHelper.GetStartTime(tariffQueryModel.Range, tariffQueryModel.StartTime);
            if (startDateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }
            return String.Empty;
        }

    }
}
