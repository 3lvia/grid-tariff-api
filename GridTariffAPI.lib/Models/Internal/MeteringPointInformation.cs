using System;

namespace GridTariffApi.Lib.Models.Internal
{
    public class MeteringPointInformation
    {
        public MeteringPointInformation(string meteringPointId, string tariffKey, double? maxConsumption, DateTimeOffset maxConsumptionLastUpdated)
        {
            MeteringPointId = meteringPointId;
            TariffKey = tariffKey;
            MaxConsumption = maxConsumption;
            MaxConsumptionLastUpdated = maxConsumptionLastUpdated;
        }
        public String MeteringPointId { get;}
        public String TariffKey { get; set; }
        public double? MaxConsumption { get; set; }
        public DateTimeOffset MaxConsumptionLastUpdated { get; set; }
    }
}
