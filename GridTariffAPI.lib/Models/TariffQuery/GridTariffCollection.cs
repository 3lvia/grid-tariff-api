using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.TariffQuery
{
    public class GridTariffCollection
    {
        public GridTariff GridTariff{ get; set; }
        public List<string> MeteringPointIds { get; set; }
    }
}
