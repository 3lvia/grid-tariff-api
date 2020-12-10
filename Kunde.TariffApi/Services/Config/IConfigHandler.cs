using Kunde.TariffApi.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kunde.TariffApi.Services.Config
{
    public interface IConfigHandler
    {
        GridTariffApiConfig GetConfig(GridTariffApiConfig gridTariffAPIConfig);
    }
}
