﻿using Microsoft.AspNetCore.Mvc;

namespace Kunde.TariffApi.Controllers
{

    /// <summary>
    /// Ping to check system health
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        /// <summary>
        /// Ping to check system health
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}