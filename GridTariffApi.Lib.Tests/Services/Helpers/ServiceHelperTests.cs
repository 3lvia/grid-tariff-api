using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace GridTariffApi.Lib.Tests.Services.Helpers
{
    public class ServiceHelperTests
    {
        GridTariffApiConfig _gridTariffApiConfig;
        IServiceHelper _serviceHelper;

        private void Setup()
        {
            _gridTariffApiConfig = new GridTariffApiConfig();
            _gridTariffApiConfig.TimeZoneForQueries = NorwegianTimeZoneInfo();
            _serviceHelper = new ServiceHelper(_gridTariffApiConfig);
        }


        [Fact()]
        public void GetStartDateTest()
        {
            Setup();
            DateTime now = DateTime.UtcNow;
            Assert.Equal(now, _serviceHelper.GetStartTime(null, now));
            Assert.Equal(now, _serviceHelper.GetStartTime("yesterday", now));
            Assert.Equal(now.AddDays(-1).Date, _serviceHelper.GetStartTime("yesterday", null));
            Assert.Equal(now.Date, _serviceHelper.GetStartTime("today", null));
            Assert.Equal(now.AddDays(+1).Date, _serviceHelper.GetStartTime("tomorrow", null));
        }

        [Fact()]
        public void GetEndDateTest()
        {
            Setup();
            DateTime now = DateTime.UtcNow;
            Assert.Equal(now, _serviceHelper.GetEndTime(null, now));
            Assert.Equal(now, _serviceHelper.GetEndTime("yesterday", now));
            Assert.Equal(now.AddDays(-1).Date.AddDays(1).AddSeconds(-1), _serviceHelper.GetEndTime("yesterday", null));
            Assert.Equal(now.Date.AddDays(1).AddSeconds(-1), _serviceHelper.GetEndTime("today", null));
            Assert.Equal(now.AddDays(+2).Date.AddSeconds(-1), _serviceHelper.GetEndTime("tomorrow", null));
        }

        private static TimeZoneInfo NorwegianTimeZoneInfo()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return norwegianTimeZone;
        }


    }
}
