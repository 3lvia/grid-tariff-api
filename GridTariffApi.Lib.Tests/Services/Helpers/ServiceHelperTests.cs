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
            _gridTariffApiConfig = new GridTariffApiConfig
            {
                TimeZoneForQueries = NorwegianTimeZoneInfo()
            };
            _serviceHelper = new ServiceHelper(_gridTariffApiConfig);
        }


        [Fact()]
        public void GetStartDateTest()
        {
            Setup();
            DateTimeOffset value = new DateTimeOffset(new DateTime(2021,01,01), new TimeSpan(1, 0, 0));
            Assert.Equal(value.DateTime, _serviceHelper.GetStartTime(null, value));
            Assert.Equal(value.DateTime, _serviceHelper.GetStartTime("yesterday", value));
            Assert.Equal(DateTime.Now.AddDays(-1).Date, _serviceHelper.GetStartTime("yesterday", null));
            Assert.Equal(DateTime.Now.Date, _serviceHelper.GetStartTime("today", null));
            Assert.Equal(DateTime.Now.AddDays(+1).Date, _serviceHelper.GetStartTime("tomorrow", null));
        }

        [Fact()]
        public void GetEndDateTest()
        {
            Setup();
            DateTimeOffset value = new DateTimeOffset(new DateTime(2021, 01, 01), new TimeSpan(1, 0, 0));
            Assert.Equal(value.DateTime, _serviceHelper.GetEndTime(null, value));
            Assert.Equal(value.DateTime, _serviceHelper.GetEndTime("yesterday", value));
            Assert.Equal(DateTime.Now.AddDays(-1).Date.AddDays(1).AddSeconds(-1), _serviceHelper.GetEndTime("yesterday", null));
            Assert.Equal(DateTime.Now.Date.AddDays(1).AddSeconds(-1), _serviceHelper.GetEndTime("today", null));
            Assert.Equal(DateTime.Now.AddDays(+2).Date.AddSeconds(-1), _serviceHelper.GetEndTime("tomorrow", null));
        }

        private static TimeZoneInfo NorwegianTimeZoneInfo()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return norwegianTimeZone;
        }

        [Theory]
        [InlineData("yesterday",-1)]
        [InlineData("today",0)]
        [InlineData("tomorrow",1)]

        public void GetStartDateTimeOffsetTest(string range, int daysToAdd)
        {
            Setup();
            var startDate = _serviceHelper.GetStartDateTimeOffset(range, null);
            var testValue = _serviceHelper.GetTimeZonedDateTime(DateTime.UtcNow).Date.AddDays(daysToAdd).ToUniversalTime();
            Assert.Equal(testValue, startDate);
        }


        [Theory]
        [InlineData("yesterday", 0)]
        [InlineData("today", 1)]
        [InlineData("tomorrow", 2)]

        public void GetEndDateTimeOffsetTest(string range, int daysToAdd)
        {
            Setup();
            var startDate = _serviceHelper.GetEndDateTimeOffset(range, null);
            var testValue = _serviceHelper.GetTimeZonedDateTime(DateTime.UtcNow).Date.AddDays(daysToAdd).AddSeconds(-1).ToUniversalTime();
            Assert.Equal(testValue, startDate);
        }

    }
}
