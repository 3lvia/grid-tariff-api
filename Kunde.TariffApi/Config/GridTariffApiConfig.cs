using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kunde.TariffApi.Config
{
    public class GridTariffApiConfig
    {
        public string DBConnectionString { get; set; }
        public string InstrumentationKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AlternativeSource { get; set; }
        public DateTime MinStartDateAllowedQuery { get; set; }
    }
}
