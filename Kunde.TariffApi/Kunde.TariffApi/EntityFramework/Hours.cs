using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Hours
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public string Starttimetext { get; set; }
        public string Expiredattext { get; set; }
        public string Hourshortname { get; set; }
    }
}
