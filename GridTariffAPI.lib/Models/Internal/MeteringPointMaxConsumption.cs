using System;

namespace GridTariffApi.Lib.Models.Internal
{
    public class MeteringPointMaxConsumption
    {
        public string MeteringPointId { get; set; }
        /// <summary>
        /// The maximum hourly energy consumption (max measured volume) for the meteringPoint this current month. Null if no measured volumes are available.
        /// </summary>
        public double? MaxHourlyEnergyConsumption { get; set; }
        /// <summary>
        /// The end time of the newest volume that the MaxHourlyEnergyConsumption is based on. An indication of the freshness of the data that the aggregation is based on.
        /// </summary>
        public DateTimeOffset? LastVolumeEndTime { get; set; }
    }
}
