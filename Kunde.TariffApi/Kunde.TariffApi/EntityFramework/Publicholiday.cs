using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Publicholiday
    {
        public int Id { get; set; }
        public DateTime Holidaydate { get; set; }
        public string Description { get; set; }
    }
}
