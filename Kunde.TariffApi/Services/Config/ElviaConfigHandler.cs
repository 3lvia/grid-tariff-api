using Elvia.Configuration.HashiVault;
using Kunde.TariffApi.Config;

namespace Kunde.TariffApi.Services.Config
{
    public class ElviaConfigHandler : IConfigHandler
    {
        public ElviaConfigHandler()
        {
        }
        public GridTariffApiConfig GetConfig(GridTariffApiConfig gridTariffAPIConfig)
        {
            gridTariffAPIConfig.DBConnectionString = HashiVault.GetGenericSecret("kunde/kv/sql/kunde-sqlserver/NettTariff/connection-string");
            gridTariffAPIConfig.InstrumentationKey = HashiVault.GetGenericSecret("kunde/kv/appinsights/kunde/instrumentation-key");
            gridTariffAPIConfig.Username = HashiVault.GetGenericSecret("kunde/kv/nett-tariff-api/username");
            gridTariffAPIConfig.Password = HashiVault.GetGenericSecret("kunde/kv/nett-tariff-api/password");
            return gridTariffAPIConfig;
        }
    }
}
