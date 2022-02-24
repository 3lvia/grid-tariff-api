using System;

namespace GridTariffApi.Lib.Models.Internal
{
    public class MeteringPointInformation
    {
        public MeteringPointInformation(string meteringPointId, string productKey, double? maxConsumption, DateTimeOffset? maxConsumptionLastUpdated)
        {
            MeteringPointId = meteringPointId;
            ProductKey = productKey;
            MaxConsumption = maxConsumption;
            MaxConsumptionLastUpdated = maxConsumptionLastUpdated;
        }
        public String MeteringPointId { get;}
        public String ProductKey { get; set; }
        public double? MaxConsumption { get; set; }
        public DateTimeOffset? MaxConsumptionLastUpdated { get; set; }
    }
}
