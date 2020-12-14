using Kunde.TariffApi.Config;
using Microsoft.Extensions.Configuration;
using System;

namespace Kunde.TariffApi.Services.Config
{
    public static class GridTariffApiConfigFactory
    {
        private static IConfiguration _configuration;
        public static GridTariffApiConfig GetGridTariffAPIConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            GridTariffApiConfig gridTariffApiConfig = GetAlternativeSource(_configuration);
            IConfigHandler configHandler = GetImplementetation(gridTariffApiConfig.AlternativeSource);
            return configHandler.GetConfig(gridTariffApiConfig);
        }

        private static IConfigHandler GetImplementetation (string alternativeSource)
        {
            if (alternativeSource.Equals("Elvia"))
            {
                return new ElviaConfigHandler(_configuration);
            }
            return new DefaultConfigHandler();
        }

        public static GridTariffApiConfig GetAlternativeSource(IConfiguration configuration)
        {
            string alternativeSource = configuration.GetValue<string>("alternativeSource");
            if (!String.IsNullOrEmpty(alternativeSource))
            {
                return new GridTariffApiConfig() { AlternativeSource = alternativeSource };
            }
            return configuration.GetSection("GridTariffAPIConfig").Get<GridTariffApiConfig>();
        }
    }
}
