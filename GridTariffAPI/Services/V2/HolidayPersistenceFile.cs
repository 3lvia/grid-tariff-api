using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Holidays;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Services.V2
{
    public class HolidayPersistenceFile : IHolidayPersistence
    {
        private static string _holidayFileName = "Artifacts\\holidays.json";

        public HolidayPersistenceFile()
        {

        }

        public List<Holiday> GetHolidays()
        {
            string jsonString = File.ReadAllText(_holidayFileName);

            var earth = JsonConvert.DeserializeObject<Earth>(jsonString);
            return earth.Countries.FirstOrDefault(a => a.Code == 47).Holidays;
        }
    }
}
