using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.V2.Digin;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.V2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Mime;
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

        public async Task<ActionResult<Models.V2.Digin.TariffQueryResult>> TariffQuery([FromQuery] TariffQueryRequest request)  
        {
            string validationErrorMsg = ValidateRequestInput(request);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }
            DateTimeOffset startDateTime = _serviceHelper.GetStartDateTimeOffset(request.Range, request.StartTime);
            DateTimeOffset endDateTime = _serviceHelper.GetEndDateTimeOffset(request.Range, request.EndTime);

            var tariffKey = DecideTariffKeyFromInput(request);
            var result = await _tariffQueryService.QueryTariffAsync(tariffKey, startDateTime, endDateTime);
            return Ok(result);
        }
        public string ValidateRequestInput(TariffQueryRequest request)
        {
            if (request == null)
            {
                return "Missing model";
            }

            bool tariffKeyAndProductMissing = String.IsNullOrEmpty(request.TariffKey) && String.IsNullOrEmpty(request.Product);
            bool tariffKeyAndProductBothPresent = !String.IsNullOrEmpty(request.TariffKey) && !String.IsNullOrEmpty(request.Product);
            if (tariffKeyAndProductMissing)
            {
                return $"Neither TariffKey nor Product present in request";
            }
            if (tariffKeyAndProductBothPresent)
            {
                return $"Both TariffKey and Product present in request. These are mutually exclusive";
            }

            var tariffKey = request.TariffKey;
            var tariffs = _tariffPriceCache.GetTariffs();

            if (!String.IsNullOrEmpty(request.Product))
            {
                var tariff = tariffs.FirstOrDefault(x => x.Product == request.Product);
                if (tariff == null)
                {
                    return $"Tariff with productcode {request.Product} not found";
                }
                tariffKey = tariff.TariffKey;
            }

            if (!tariffs.Any(x => x.TariffKey == tariffKey))
            {
                return $"TariffType {tariffKey} not found";
            }

            var startDateTime = _serviceHelper.GetStartDateTimeOffset(request.Range, request.StartTime);
            if (startDateTime.DateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }
            return String.Empty;
        }

        public string DecideTariffKeyFromInput(TariffQueryRequest request)
        {
            if (!String.IsNullOrEmpty(request.TariffKey))
            {
                return request.TariffKey;
            }
            var tariff = _tariffPriceCache.GetTariffs().FirstOrDefault(x => x.Product == request.Product);
            if (tariff != null)
            {
                return tariff.TariffKey;
            }
            return String.Empty;
        }
    }
}
