using Elvia.Telemetry;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.PriceStructure;
using Newtonsoft.Json;
using System;
using System.IO;

namespace GridTariffApi.Services
{
    public class TariffRepositoryFile : ITariffRepository
    {
        private static readonly string _tariffPriceFileName = Path.Join("Artifacts", "GridTariffPriceConfiguration.v1_0_gridtariffprices.json");
        private readonly ITelemetryInsightsLogger _telemetryLogger;

        public TariffRepositoryFile(ITelemetryInsightsLogger telemetryLogger)
        {
            _telemetryLogger = telemetryLogger;
        }

        public TariffPriceStructureRoot GetTariffPriceStructure()
        {
            TariffPriceStructureRoot retVal;
            try
            {
                string jsonString = File.ReadAllText(_tariffPriceFileName);
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
