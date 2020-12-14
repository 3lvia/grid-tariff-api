using Elvia.Configuration.HashiVault;
using Kunde.TariffApi.Config;
using Microsoft.Extensions.Configuration;
using System;

namespace Kunde.TariffApi.Services.Config
{
    public class ElviaConfigHandler : IConfigHandler
    {
        private readonly IConfiguration _configuration;
        public ElviaConfigHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public GridTariffApiConfig GetConfig(GridTariffApiConfig gridTariffAPIConfig)
        {
            gridTariffAPIConfig.DBConnectionString = HashiVault.GetGenericSecret("kunde/kv/sql/kunde-sqlserver/NettTariff/connection-string");
            gridTariffAPIConfig.InstrumentationKey = HashiVault.GetGenericSecret("kunde/kv/appinsights/kunde/instrumentation-key");
            gridTariffAPIConfig.Username = HashiVault.GetGenericSecret("kunde/kv/nett-tariff-api/username");
            gridTariffAPIConfig.Password = HashiVault.GetGenericSecret("kunde/kv/nett-tariff-api/password");
            gridTariffAPIConfig.MinStartDateAllowedQuery = _configuration.GetValue<DateTime>("minStartDateAllowedQuery");
            return gridTariffAPIConfig;
        }
    }
}
