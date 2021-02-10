using System;

namespace GridTariffApi.Lib.Models.TariffQuery
{
    public class TariffType
    {
        public string TariffKey { get; set; }
        public String Company { get; set; }
        public String CustomerType { get; set; }
        public String Title { get; set; }
        public int Resolution { get; set; }
        public String Description { get; set; }
    }
}
