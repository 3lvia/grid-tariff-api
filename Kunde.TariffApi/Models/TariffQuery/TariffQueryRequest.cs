using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kunde.TariffApi.Models.TariffQuery
{
    public class TariffQueryRequest : IValidatableObject
    {
        [Required]
        [StringLength(100)]
        public String TariffKey { get; set; }

        /// <summary>
        /// Mutual exclusive with startTime/EndTime.  Valid values: yesterday,today,tomorrow. 
        /// 
        /// </summary>
        /// <example>tomorrow</example>
        [StringLength(10)]
        [RegularExpression("yesterday|today|tomorrow", ErrorMessage = "Valid values is 'yesterday','today','tomorrow'")]
        public String Range { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndTime { get; set; }

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
        }
    }
}
