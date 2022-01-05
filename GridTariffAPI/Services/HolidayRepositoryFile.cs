﻿using Elvia.Telemetry;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GridTariffApi.Services
{
    public class HolidayRepositoryFile : IHolidayRepository
    {
        private static readonly string _holidayFileName = Path.Join("Artifacts","holidays.json");
        private readonly ITelemetryInsightsLogger _telemetryLogger;

        public HolidayRepositoryFile(ITelemetryInsightsLogger telemetryLogger)
        {
            _telemetryLogger = telemetryLogger;
        }

        public IReadOnlyList<Holiday> GetHolidays()
        {
            IReadOnlyList<Holiday> retVal = null;
            try
            {
                string jsonString = File.ReadAllText(_holidayFileName);
                var earth = JsonConvert.DeserializeObject<Earth>(jsonString);
                retVal =  earth.Countries.FirstOrDefault(a => a.Code == 47).Holidays;
            }
            catch (Exception e )
            {
                _telemetryLogger.TrackException(e);
                throw;
            }
            return retVal;
        }
    }
}