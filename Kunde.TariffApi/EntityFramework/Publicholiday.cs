using System;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class PublicHoliday
    {
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public string Description { get; set; }
    }
}
