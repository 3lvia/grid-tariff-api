using GridTariffApi.Lib.Models.Holidays;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface IHolidayRepository
    {
        public Task<IReadOnlyList<Holiday>> GetHolidaysAsync();
    }
}
