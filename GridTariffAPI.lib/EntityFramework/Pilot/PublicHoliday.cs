using System;

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class PublicHoliday
    {
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public string Description { get; set; }
    }
}
