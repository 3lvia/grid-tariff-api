using System;

#nullable disable

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class MeteringPointProduct
    {
        public int Id { get; set; }
        public string MeteringpointId { get; set; }
        public string Product { get; set; }
        public string TariffKey { get; set; }
        public int AreaCode { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
