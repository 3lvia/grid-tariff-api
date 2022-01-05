using GridTariffApi.Lib.Models.Holidays;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface IHolidayRepository
    {
        public IReadOnlyList<Holiday> GetHolidays();
    }
}
