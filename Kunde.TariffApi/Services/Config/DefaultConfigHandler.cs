using Kunde.TariffApi.Config;

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
