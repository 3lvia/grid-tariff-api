using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.V2.Internal
{
    public class MeteringPointTariff
    {
        public MeteringPointTariff(string meteringPointId, string tariffKey)
        {
            MeteringPointId = meteringPointId;
            TariffKey = tariffKey;
        }
        public String MeteringPointId { get;}
        public String TariffKey { get; }
    }
}
