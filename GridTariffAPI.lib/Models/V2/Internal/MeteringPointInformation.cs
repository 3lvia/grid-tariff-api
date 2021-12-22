using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.V2.Internal
{
    public class MeteringPointInformation
    {
        public MeteringPointInformation(string meteringPointId, string tariffKey, double? maxConsumption)
        {
            MeteringPointId = meteringPointId;
            TariffKey = tariffKey;
            MaxConsumption = maxConsumption;
        }
        public String MeteringPointId { get;}
        public String TariffKey { get; set; }
        public double? MaxConsumption { get; set; }
    }
}
