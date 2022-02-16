using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Model
{
    public partial class SyncStatus
    {
        /// <summary>
        /// For internal use
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Table of interest
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// TimeStamp of last update.
        /// </summary>
        public DateTimeOffset LastUpdated { get; set; }
    }
}
