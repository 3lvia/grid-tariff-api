using System;
using System.ComponentModel.DataAnnotations;

namespace GridTariffApi.Model
{
    /// <summary>
    /// PriceStructure for a Company
    /// Contains all tariffs for the company
    /// </summary>

    public partial class PriceStructure
    {
        /// <summary>
        /// For internal use
        /// </summary>
        [Key]
        public int Id { get; set; }

        public Company Company { get; set; }
        public DateTimeOffset LastUpdatedUtc { get; set; }

        /// <summary>
        /// Format version of pricestructure
        /// </summary>
        public string JsonVersion { get; set; }

        /// <summary>
        /// PriceStructure in Json format.
        /// </summary>
        public string JsonPayload { get; set; }
    }
}
