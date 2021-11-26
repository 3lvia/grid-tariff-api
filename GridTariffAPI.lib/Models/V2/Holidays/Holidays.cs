using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.V2.Holidays
{
    public class Holiday
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class Country
    {
        [JsonProperty("Code")]
        public int Code { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Holidays")]
        public List<Holiday> Holidays { get; set; }
    }

    public class Earth
    {
        [JsonProperty("Countries")]
        public List<Country> Countries { get; set; }
    }

}
