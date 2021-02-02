using System;
using System.Collections.Generic;

#nullable disable

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class MeteringPointProduct
    {
        public int Id { get; set; }
        public string Mpid { get; set; }
        public string Product { get; set; }
        public string Tariffkey { get; set; }
        public int Areacode { get; set; }
        public DateTime Lastupdateddate { get; set; }
    }
}
