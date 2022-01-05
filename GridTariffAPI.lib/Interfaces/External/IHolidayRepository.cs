using GridTariffApi.Lib.Models.Holidays;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface IHolidayRepository
    {
        public IReadOnlyList<Holiday> GetHolidays();
    }
}
