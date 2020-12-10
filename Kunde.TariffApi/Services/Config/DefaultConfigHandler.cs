using Kunde.TariffApi.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kunde.TariffApi.Services.Config
{
    public class DefaultConfigHandler : IConfigHandler
    {
        public DefaultConfigHandler()
        {
        }
        public GridTariffApiConfig GetConfig(GridTariffApiConfig gridTariffAPIConfig)
        {
            return gridTariffAPIConfig;
        }
    }
}
