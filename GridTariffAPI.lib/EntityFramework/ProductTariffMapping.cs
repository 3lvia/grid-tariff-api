using System;

#nullable disable

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class ProductTariffMapping
    {
        public int Id { get; set; }
        public string NetProduct { get; set; }
        public string Tariffkey { get; set; }
        public DateTime Created { get; set; }
        public DateTime Lastupdated { get; set; }
    }
}
