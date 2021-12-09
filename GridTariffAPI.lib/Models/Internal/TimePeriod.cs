using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.Internal
{
    public class TimePeriod
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
