using GridTariffApi.Lib.Models.Digin;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using GridTariffApi.Lib.Interfaces;

namespace GridTariffApi.Lib.Controllers.v1
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("digin/api/{v:apiVersion}")]
    public class TariffQueryController : ControllerBase
    {
        private readonly ITariffQueryService _tariffQueryService;
        private readonly IServiceHelper _serviceHelper;
        private readonly ILoggingDataCollector _loggingDataCollector;
        private readonly IControllerValidationHelper _controllerValidationHelper;

        public TariffQueryController(ITariffQueryService tariffQueryService,
            IServiceHelper serviceHelper,
            ILoggingDataCollector loggingDataCollector,
            IControllerValidationHelper controllerValidationHelper)
        {
            _tariffQueryService = tariffQueryService;
            _serviceHelper = serviceHelper;
            _loggingDataCollector = loggingDataCollector;
            _controllerValidationHelper = controllerValidationHelper;
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

        public async Task<ActionResult<Models.Digin.TariffQueryResult>> TariffQuery([FromQuery] TariffQueryRequest request)  
        {
            string validationErrorMsg = await _controllerValidationHelper.ValidateRequestInputAsync(request);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }
            DateTimeOffset startDateTime = _serviceHelper.GetStartDateTimeOffset(request.Range, request.StartTime);
            DateTimeOffset endDateTime = _serviceHelper.GetEndDateTimeOffset(request.Range, request.EndTime);
            _loggingDataCollector?.RegisterTariffPeriodAndNumMeteringPoints(startDateTime, endDateTime, null);
            var tariffKey = await _controllerValidationHelper.DecideTariffKeyFromInputAsync(request);
            var result = await _tariffQueryService.QueryTariffAsync(tariffKey, startDateTime, endDateTime);
            return Ok(result);
        }

        /// <summary>
        /// Returns tariff data for a given set of meteringpoints for a given timeperiod.
        /// </summary>
        /// Range and StartTime/Endtime is mutual exclusive, meaning either one must be present, but not bot. Date time formats using Edielstandard, see README file
        [HttpPost]
        [Route("tariffquery/meteringpointsgridtariffs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Models.Digin.TariffQueryRequestMeteringPointsResult>> MeteringPointsTariffQuery([FromBody] TariffQueryRequestMeteringPoints request)
        {
            string validationErrorMsg = _controllerValidationHelper.ValidateRequestInput(request);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }
            DateTimeOffset startDateTime = _serviceHelper.GetStartDateTimeOffset(request.Range, request.StartTime);
            DateTimeOffset endDateTime = _serviceHelper.GetEndDateTimeOffset(request.Range, request.EndTime);
            _loggingDataCollector?.RegisterTariffPeriodAndNumMeteringPoints(startDateTime, endDateTime, request.MeteringPointIds?.Count);
            var result = await _tariffQueryService.QueryMeteringPointsTariffsAsync(startDateTime, endDateTime,request.MeteringPointIds.Distinct().ToList());
            return Ok(result);
        }
    }
}
