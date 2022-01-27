using Elvia.Telemetry;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.PriceStructure;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GridTariffApi.Services
{
    public class TariffRepositoryFile : ITariffRepository
    {
        private static readonly string TariffPriceFileName = Path.Join("Artifacts", "GridTariffPriceConfiguration.v1_0_gridtariffprices.json");
        private readonly ITelemetryInsightsLogger _telemetryLogger;

        public TariffRepositoryFile(ITelemetryInsightsLogger telemetryLogger)
        {
            _telemetryLogger = telemetryLogger;
        }

        public async Task<TariffPriceStructureRoot> GetTariffPriceStructureAsync()
        {
            TariffPriceStructureRoot retVal;
            try
            {
                string jsonString = await File.ReadAllTextAsync(TariffPriceFileName);
                retVal = JsonConvert.DeserializeObject<TariffPriceStructureRoot>(jsonString);
            }
            catch (Exception e)
            {
                _telemetryLogger.TrackException(e);
                throw;
            }
            return retVal;
        }
    }
}
