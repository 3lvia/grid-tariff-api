using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.PriceStructure;
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
        private static string _filename = "Artifacts\\GridTariffPriceConfiguration.v0_9_gridtariffprices_json_example.json";
        public TariffPersistenceFile()
        {

        }

        public TariffPriceStructureRoot GetTariffPriceStructure()
        {
            string jsonString = File.ReadAllText(_filename);


            var gridTariffPriceConfiguration = JsonSerializer.Deserialize<GridTariffPriceConfiguration>(jsonString);

//            var test = JsonSerializer.Deserialize<Newtonsoft.Json.Linq.JObject>(jsonString);


            var tariffPriceStructureRoot = JsonSerializer.Deserialize<TariffPriceStructureRoot>(jsonString);
            return tariffPriceStructureRoot;
        }
    }
}
