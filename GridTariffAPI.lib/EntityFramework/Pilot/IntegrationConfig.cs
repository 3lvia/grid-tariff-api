using System;

#nullable disable

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class IntegrationConfig
    {
        public int Id { get; set; }
        public string TableUpdated { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
