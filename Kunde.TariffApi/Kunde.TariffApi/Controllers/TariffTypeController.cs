using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kunde.TariffApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TariffTypeController : ControllerBase
    {
        private ITariffTypeService _tariffTypeService;
        public TariffTypeController(ITariffTypeService tariffTypeService)
        {
            _tariffTypeService = tariffTypeService;
        }
        // GET: api/<TariffTypeController>
        [HttpGet]
        public TariffTypeContainer Get()
        {
            return _tariffTypeService.GetTariffTypes();
        }

    }
}
