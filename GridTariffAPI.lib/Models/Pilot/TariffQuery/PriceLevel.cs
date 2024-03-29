﻿using System;

namespace GridTariffApi.Lib.Models.Pilot.TariffQuery
{
    public class PriceLevel
    {
        public String Level { get; set; }
        public String LevelInfo { get; set; }
        public Decimal Total { get; set; }
        public Decimal Fixed { get; set; }
        public Decimal Taxes { get; set; }
        public String Currency { get; set; }
        public string Uom { get; set; }
    }
}
