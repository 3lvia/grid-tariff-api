using GridTariffApi.Lib.Models.V2.Holidays;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface IHolidayPersistence
    {
        public List<Holiday> GetHolidays();
    }
}
