using System;

namespace GridTariffApi.Lib.Models.Internal
{
    public class MeteringPointMaxConsumption
    {
        public string MeteringPointId { get; set; }

        /// <summary>
        /// The "MaxConsumption", the value used for determining the power based fixed price level in the tariff.
        /// The average of the max hourly consumptions (volumes) on 3 different days within the calendar month.
        /// </summary>
        public double? MaxConsumption { get; set; }

        /// <summary>
        /// The end time of the newest volume that the MaxConsumption is based on. An indication of the freshness of the data available.
        /// </summary>
        public DateTimeOffset? LastVolumeEndTime { get; set; }
    }
}
