using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.Holidays
{
    public class Holiday
    {
        [JsonConstructor]
        public Holiday(
            [JsonProperty("Date")] DateTime date,
            [JsonProperty("Name")] string name
        )
        {
            this.Date = date;
            this.Name = name;
        }

        [JsonProperty("Date")]
        public DateTime Date { get; }

        [JsonProperty("Name")]
        public string Name { get; }
    }

    public class Country
    {
        [JsonConstructor]
        public Country(
            [JsonProperty("Code")] int code,
            [JsonProperty("Name")] string name,
            [JsonProperty("Holidays")] List<Holiday> holidays
        )
        {
            this.Code = code;
            this.Name = name;
            this.Holidays = holidays;
        }

        [JsonProperty("Code")]
        public int Code { get; }

        [JsonProperty("Name")]
        public string Name { get; }

        [JsonProperty("Holidays")]
        public IReadOnlyList<Holiday> Holidays { get; }
    }

    public class Earth
    {
        [JsonConstructor]
        public Earth(
            [JsonProperty("Countries")] List<Country> countries
        )
        {
            this.Countries = countries;
        }

        [JsonProperty("Countries")]
        public IReadOnlyList<Country> Countries { get; }
    }


}
