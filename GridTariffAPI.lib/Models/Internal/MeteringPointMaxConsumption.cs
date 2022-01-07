using System;

namespace GridTariffApi.Lib.Models.Internal
{
    public class MeteringPointMaxConsumption
    {
        public string MeteringPointId { get; set; }
        /// <summary>
        /// The maximum hourly energy consumption (max measured volume) for the meteringPoint this current month
        /// </summary>
        public double MaxHourlyEnergyConsumption { get; set; }
        /// <summary>
        /// The max LastMeasurementTime from all the aggregated volumes (except estimated volumes). An indication of the freshness of the meter values that the aggregation is based on.
        /// </summary>
        public DateTimeOffset? LatestMeasurementTime { get; set; }
    }
}
