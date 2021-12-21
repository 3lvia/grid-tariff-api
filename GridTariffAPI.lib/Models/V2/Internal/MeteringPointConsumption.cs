using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.V2.Internal
{
    public class MeteringPointMaxConsumption
    {
        public MeteringPointMaxConsumption(string meteringPointId, double maxConsumption)
        {
            MeteringPointId = meteringPointId;
            MaxConsumption = maxConsumption;
        }
        public String MeteringPointId { get; }
        public double MaxConsumption { get; }
    }
}
