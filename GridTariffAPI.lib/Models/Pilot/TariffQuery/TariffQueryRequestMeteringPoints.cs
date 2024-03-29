﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GridTariffApi.Lib.Models.Pilot.TariffQuery
{
    public class TariffQueryRequestMeteringPoints    {
        /// <summary>
        /// Mutual exclusive with startTime/EndTime.  Valid values: yesterday,today,tomorrow. 
        /// </summary>
        /// <example>tomorrow</example>
        [StringLength(10)]
        [RegularExpression("yesterday|today|tomorrow", ErrorMessage = "Valid values is 'yesterday','today','tomorrow'")]
        public String Range { get; set; }

        /// <summary>
        /// Mutual exclusive with Range. Used together with EndTime. Sample value: 2020-11-09T00:00:00.000Z
        /// </summary>
        /// <example>2020-11-09T00:00:00.000Z</example>
        [DataType(DataType.DateTime)]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Mutual exclusive with Range. Used together with StartTime. Sample value: 2020-12-31T00:00:00.000Z
        /// </summary>
        /// <example>2020-12-31T00:00:00.000Z</example>
        [DataType(DataType.DateTime)]
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// List of meteringpoints which is used for determining tarriff data for
        /// </summary>
        /// <example>707057500020404292</example>
        public List<String> MeteringPointIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool hasRange = !String.IsNullOrEmpty(Range);
            bool hasStart = StartTime.HasValue;
            bool hasEnd = EndTime.HasValue;
            if (!hasRange && !(hasStart || hasEnd))
            {
                yield return new ValidationResult(
                              $"Neither range nor StartTime/Endtime specified",
                              new[] { nameof(Range), nameof(StartTime), nameof(EndTime) });
            }
            if (hasRange)
            {
                if (hasStart || hasEnd)
                {
                    yield return new ValidationResult(
                      $"Both range and StartTime/Endtime specified",
                      new[] { nameof(Range), nameof(StartTime), nameof(EndTime) });
                }
            }
            else
            {
                if (!hasStart)
                {
                    yield return new ValidationResult(
                      $"StartTime Not specified",
                      new[] { nameof(StartTime) });
                }
                if (!hasEnd)
                {
                    yield return new ValidationResult(
                      $"Endtime Not specified",
                      new[] { nameof(EndTime) });

                }
                if (StartTime > EndTime)
                {
                    yield return new ValidationResult(
                      $"StartTime greather than EndTime",
                      new[] { nameof(StartTime), nameof(EndTime) });
                }
            }

            if (MeteringPointIds == null)
            {
                yield return new ValidationResult(
                    $"{nameof(MeteringPointIds)} missing",
                    new[] { nameof(MeteringPointIds)});
            }
        }

    }
}
