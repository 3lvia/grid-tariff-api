using System;

namespace GridTariffApi.Lib.Models.Internal
{
    public class MeteringPointTariff
    {
        public MeteringPointTariff(string meteringPointId, string tariffKey)
        {
            MeteringPointId = meteringPointId;
            TariffKey = tariffKey;
        }
        public String MeteringPointId { get;}
        public String TariffKey { get; set; }
    }
}
