using GridTariffApi.Lib.Models.V2.PriceStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.Internal
{
    public class SeasonData
    {
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public Season Season{ get; set; }
    }
}
