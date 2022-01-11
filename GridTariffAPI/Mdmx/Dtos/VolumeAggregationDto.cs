using System;

namespace GridTariffApi.Mdmx.Dtos
{
    public class VolumeAggregationDto
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
    /// The max LastMeasurementTime from all the aggregated volumes (except estimated volumes). An indication of the freshness of the meter values that the aggregation is based on.
    /// </summary>
    public DateTimeOffset? LatestMeasurementTime { get; set; }
    }
}