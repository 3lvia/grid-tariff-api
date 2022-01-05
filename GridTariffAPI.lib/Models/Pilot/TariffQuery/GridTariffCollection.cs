using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.Pilot.TariffQuery
{
    public class GridTariffCollection
    {
        public GridTariff GridTariff{ get; set; }
        public List<string> MeteringPointIds { get; set; }
    }
}
