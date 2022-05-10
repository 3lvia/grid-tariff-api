using System;

namespace GridTariffApi.Mdmx.Dtos
{
    public class MaxConsumptionAggregationBatchQuery
    {
        /// <summary>
        /// The ids of the metering points to aggregate volumes for.
        /// </summary>
        public string[] MeteringPointIds { get; set; }

        /// <summary>
        /// The time for when to calculate MaxConsumption. The volumes from the start of the month (in Norwegian time zone) up to the given time is included in the calculation. Default: now.
        /// </summary>
        public DateTimeOffset? MeasurementTimeLe { get; set; }
    }
}