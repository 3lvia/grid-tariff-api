using System;

namespace GridTariffApi.Mdmx.Dtos
{
    public class VolumeAggregationBatchQuery
    {
        /// <summary>
        /// The ids of the metering points to aggregate volumes for
        /// </summary>
        public string[] MeteringPointIds { get; set; }

        /// <summary>
        /// The register to aggregate volumes for.
        /// </summary>
        public string Register { get; set; }

        /// <summary>
        /// Aggregate volumes where volume.LastMeasurementTime greater or equal MeasurementTimeGe.
        /// </summary>
        public DateTimeOffset MeasurementTimeGe { get; set; }

        /// <summary>
        /// Aggregate volumes where volume.LastMeasurementTime lesser or equal MeasurementTimeLe.
        /// </summary>
        public DateTimeOffset MeasurementTimeLe { get; set; }
    }
}