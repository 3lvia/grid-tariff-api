using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Model
{
    /// <summary>
    /// Defines a Company
    /// </summary>
    public partial class Company
    {
        /// <summary>
        /// For internal use
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Company is identified by OrgNumber in the API.
        /// </summary>
        public string OrgNumber { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        public string Name { get; set; }
    }
}
