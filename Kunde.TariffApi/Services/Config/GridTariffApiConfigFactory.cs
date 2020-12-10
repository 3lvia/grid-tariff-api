using Kunde.TariffApi.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kunde.TariffApi.Services.Config
{
    public static class GridTariffApiConfigFactory
    {
        public static GridTariffApiConfig GetGridTariffAPIConfig(IConfiguration configuration)
        {
            var gridTariffAPIParameters = configuration.GetSection("GridTariffAPIConfig").Get<GridTariffApiConfig>();
            IConfigHandler configHandler = getImplementetation(gridTariffAPIParameters.AlternativeSource);
            return configHandler.GetConfig(gridTariffAPIParameters);
        }

        private static IConfigHandler getImplementetation (string alternativeSource)
        {
            if (alternativeSource.Equals("Elvia"))
            {
                return new ElviaConfigHandler();
            }
            return new DefaultConfigHandler();
        }
    }
}
