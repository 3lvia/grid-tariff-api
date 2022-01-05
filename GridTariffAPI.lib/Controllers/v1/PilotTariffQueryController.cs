using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models;
using GridTariffApi.Lib.Models.TariffQuery;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.Pilot;
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
    public class PilotTariffQueryController : ControllerBase
    {
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITariffQueryService _tariffQueryService;
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        private readonly IServiceHelper _serviceHelper;
        public PilotTariffQueryController(
            ITariffTypeService tariffTypeService,
            ITariffQueryService tariffQueryService,
            GridTariffApiConfig gridTariffApiConfig,
            IServiceHelper serviceHelper)
        {
            _tariffTypeService = tariffTypeService;
            _tariffQueryService = tariffQueryService;
            _gridTariffApiConfig = gridTariffApiConfig;
            _serviceHelper = serviceHelper;
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
        public ActionResult<TariffQueryRequestMeteringPointsResult> GridTariffsByMeteringPoints([FromBody] TariffQueryRequestMeteringPoints tariffQueryRequest)
        {
            string validationErrorMsg = ValidateRequestInput(tariffQueryRequest);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }
            DateTime startDateTime = _serviceHelper.GetStartTime(tariffQueryRequest.Range, tariffQueryRequest.StartTime);
            DateTime endDateTime = _serviceHelper.GetEndTime(tariffQueryRequest.Range, tariffQueryRequest.EndTime);
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
        public ActionResult<TariffQueryResult> Get([FromQuery] TariffQueryRequest tariffQueryRequest)
        {
            string validationErrorMsg = ValidateRequestInput(tariffQueryRequest);
            if (!String.IsNullOrEmpty(validationErrorMsg))
            {
                return BadRequest(validationErrorMsg);
            }

            DateTime startDateTime = _serviceHelper.GetStartTime(tariffQueryRequest.Range, tariffQueryRequest.StartTime);
            DateTime endDateTime = _serviceHelper.GetEndTime(tariffQueryRequest.Range, tariffQueryRequest.EndTime);
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

            DateTime startDateTime = _serviceHelper.GetStartTime(tariffQueryModel.Range, tariffQueryModel.StartTime);
            if (startDateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }
            return String.Empty;
        }
        private string ValidateRequestInput(TariffQueryRequestMeteringPoints tariffQueryRequest)
        {
            if (tariffQueryRequest == null)
            {
                return "Missing model";
            }
            DateTime startDateTime = _serviceHelper.GetStartTime(tariffQueryRequest.Range, tariffQueryRequest.StartTime);
            if (startDateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }
            if (tariffQueryRequest.MeteringPointIds == null)
            {
                return $"Missing {nameof(TariffQueryRequestMeteringPoints.MeteringPointIds)}";
            }
            return String.Empty;
        }
    }
}
