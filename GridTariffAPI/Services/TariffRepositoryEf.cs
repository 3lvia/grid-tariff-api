using Elvia.Telemetry;
using GridTariffApi.Database;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.PriceStructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Services
{
    public class TariffRepositoryEf : ITariffRepository
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _elviaCompanyOrgNumber = "980489698";


        public TariffRepositoryEf(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task<TariffPriceStructureRoot> GetTariffPriceStructureAsync()
        {
            TariffPriceStructureRoot retVal = null;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var elviaDbContext = scope.ServiceProvider.GetRequiredService<ElviaDbContext>();

                    var elviaPrices = elviaDbContext.PriceStructure.FirstOrDefault(x => x.Company.OrgNumber == _elviaCompanyOrgNumber);
                    retVal = JsonConvert.DeserializeObject<TariffPriceStructureRoot>(elviaPrices.JsonPayload);
                }
                catch (Exception e)
                {
                    var telemetryLogger = scope.ServiceProvider.GetRequiredService<ITelemetryInsightsLogger>();
                    telemetryLogger.TrackException(e);
                    throw;
                }
            }
            return Task.FromResult(retVal);
        }
    }
}
