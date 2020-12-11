using Kunde.TariffApi.Config;
using Microsoft.Extensions.Configuration;

namespace Kunde.TariffApi.Services.Config
{
    public static class GridTariffApiConfigFactory
    {
        public static GridTariffApiConfig GetGridTariffAPIConfig(IConfiguration configuration)
        {
            var gridTariffAPIParameters = configuration.GetSection("GridTariffAPIConfig").Get<GridTariffApiConfig>();
            IConfigHandler configHandler = GetImplementetation(gridTariffAPIParameters.AlternativeSource);
            return configHandler.GetConfig(gridTariffAPIParameters);
        }

        private static IConfigHandler GetImplementetation (string alternativeSource)
        {
            if (alternativeSource.Equals("Elvia"))
            {
                return new ElviaConfigHandler();
            }
            return new DefaultConfigHandler();
        }
    }
}
