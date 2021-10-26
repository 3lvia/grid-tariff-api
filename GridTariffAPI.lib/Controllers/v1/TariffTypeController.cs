using GridTariffApi.Lib.Models;
using GridTariffApi.Lib.Services.TariffType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GridTariffApi.Lib.Controllers.v1
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/tarifftype")]
    public class TariffTypeController : ControllerBase
    {
        private readonly ITariffTypeService _tariffTypeService;

        public TariffTypeController(ITariffTypeService tariffTypeService)
        {
            _tariffTypeService = tariffTypeService;
        }
        /// <summary>
        /// Service returns all available private tariffs
        /// </summary>
        /// <remarks>Service returns all available tariffs</remarks>
        /// <returns>All tariffs</returns>
        [HttpGet]
        public ActionResult<TariffTypeContainer> Get()
        {
            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            return Ok(tariffTypeContainer);
        }
    }
}
