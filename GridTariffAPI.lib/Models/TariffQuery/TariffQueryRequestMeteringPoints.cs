using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GridTariffApi.Lib.Models.TariffQuery
{
    public class TariffQueryRequestMeteringPoints    {
        [StringLength(10)]
        [RegularExpression("yesterday|today|tomorrow", ErrorMessage = "Valid values is 'yesterday','today','tomorrow'")]
        public String Range { get; set; }

        /// <summary>
        /// Mutual exclusive with Range. Used together with EndTime. Sample value: 2020-11-09T00:00:00.000Z
        /// </summary>
        /// <example>2020-11-09T00:00:00.000Z</example>
        [DataType(DataType.DateTime)]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Mutual exclusive with Range. Used together with StartTime. Sample value: 2020-12-31T00:00:00.000Z
        /// </summary>
        /// <example>2020-12-31T00:00:00.000Z</example>
        [DataType(DataType.DateTime)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// List of meteringpoints which is used for determining tarriff data for
        /// </summary>
        /// <example>707057500020404292</example>
        public List<String> MeteringPointIds { get; set; }
    }
}
