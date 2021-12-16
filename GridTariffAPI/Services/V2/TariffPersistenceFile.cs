using Elvia.Telemetry;
using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using Newtonsoft.Json;
using System;
using System.IO;

namespace GridTariffApi.Services.V2
{
    public class TariffPersistenceFile : ITariffPersistence
    {
        private static readonly string _tariffPriceFileName = Path.Join("Artifacts", "GridTariffPriceConfiguration.v1_0_gridtariffprices.json");
        private readonly ITelemetryInsightsLogger _telemetryLogger;

        public TariffPersistenceFile(ITelemetryInsightsLogger telemetryLogger)
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
