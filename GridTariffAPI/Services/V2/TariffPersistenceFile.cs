using Elvia.Telemetry;
using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GridTariffApi.Services.V2
{
    public class TariffPersistenceFile : ITariffPersistence
    {
        private static string _tariffPriceFileName = Path.Join( "Artifacts","GridTariffPriceConfiguration.v0_9_gridtariffprices_json_example.json");
        private readonly ITelemetryInsightsLogger _telemetryLogger;

        public TariffPersistenceFile(ITelemetryInsightsLogger telemetryLogger)
        {
            _telemetryLogger = telemetryLogger;
        }

        public TariffPriceStructureRoot GetTariffPriceStructure()
        {
            TariffPriceStructureRoot retVal = null;
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
