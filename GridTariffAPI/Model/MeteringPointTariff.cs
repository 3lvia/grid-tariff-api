using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Model
{
    /// <summary>
    /// Maps a meteringpoint to a Company and a product/tariff
    /// </summary>
    public partial class MeteringPointTariff
    {
        /// <summary>
        /// for internal use
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Company owning meteringpoint
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// Meteringpoint
        /// </summary>
        public string MeteringPointId { get; set; }

        /// <summary>
        /// ProductKey for Tariff
        /// </summary>
        public string ProductKey { get; set; }

        /// <summary>
        /// Tariffkey for Tariff
        /// </summary>
        public string TariffKey { get; set; }

        /// <summary>
        /// Last updated
        /// </summary>
        public DateTimeOffset LastUpdatedUtc { get; set; }
    }
}
