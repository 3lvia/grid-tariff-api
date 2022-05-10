using System;

namespace GridTariffApi.Mdmx.Dtos
{
    public class MaxConsumptionAggregationDto
    {
        public string MeteringPointId { get; set; }

        /// <summary>
        /// The minimum value of volumes for a given meteringPoint
        /// </summary>
        public double? Min { get; set; }

        /// <summary>
        /// The maximum value of volume for a given meteringPoint
        /// </summary>
        public double? Max { get; set; }

        /// <summary>
        /// The sum of volume values for a given meteringPoint
        /// </summary>
        public double? Sum { get; set; }

        /// <summary>
        /// The number of aggregated volumes for the given meteringPoint
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The max LastMeasurementTime from all the aggregated volumes (except estimated volumes). An indication of the freshness of the meter values that the aggregation is based on.
        /// </summary>
        public DateTimeOffset? LastVolumeEndTime { get; set; }

        /// <summary>
        /// The "MaxConsumption", the value used for determining the power based fixed price level in the tariff.
        /// The average of the max hourly consumptions (volumes) on 3 different days within the calendar month.
        /// See https://github.com/3lvia/mdmx/tree/trunk/Server/src/Mdmx.Apps.Shared/Api/Model/VolumeAggregations/MaxConsumptionAggregation.cs.
        /// </summary> 
        public double? MaxConsumption { get; set; }

        /// <summary>
        /// The start of the period used for retrieving volumes.
        /// </summary>
        public DateTimeOffset MeasurementTimeGe { get; set; }

        /// <summary>
        /// The end of the period used for retrieving volumes.
        /// </summary>
        public DateTimeOffset MeasurementTimeLe { get; set; }
    }
}