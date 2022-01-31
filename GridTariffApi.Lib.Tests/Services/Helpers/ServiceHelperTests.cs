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
            var localTimeNow = _serviceHelper.ToConfiguredTimeZone(DateTime.UtcNow);
            var testValue = new DateTimeOffset(localTimeNow.Year, localTimeNow.Month, localTimeNow.Day, 0, 0, 0, localTimeNow.Offset);
            testValue = testValue.AddDays(daysToAdd);
            Assert.Equal(testValue, startDate);
            Assert.Equal(testValue.Offset, startDate.Offset);
        }

        [Theory]
        [InlineData("yesterday", 0)]
        [InlineData("today", 1)]
        [InlineData("tomorrow", 2)]

        public void GetEndDateTimeOffsetTest(string range, int daysToAdd)
        {
            Setup();
            var startDate = _serviceHelper.GetEndDateTimeOffset(range, null);
            var localTimeNow = _serviceHelper.ToConfiguredTimeZone(DateTime.UtcNow);
            var testValue = new DateTimeOffset(localTimeNow.Year, localTimeNow.Month, localTimeNow.Day, 0, 0, 0, localTimeNow.Offset);
            testValue = testValue.AddDays(daysToAdd).AddSeconds(-1);
            Assert.Equal(testValue, startDate);
            Assert.Equal(testValue.Offset, startDate.Offset);
        }

        [Fact]
        public void TimePeriodIsIncludingTodayTests()
        {
            Setup();

            //historic
            var fromDate = DateTimeOffset.UtcNow.AddDays(-2);
            var toDate = DateTimeOffset.UtcNow.AddDays(-1);
            Assert.False(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate,toDate));

            //todate inside
            fromDate = DateTimeOffset.UtcNow.AddDays(-2);
            toDate = DateTimeOffset.UtcNow;
            Assert.True(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate, toDate));

            //fromDate inside
            fromDate = DateTimeOffset.UtcNow;
            toDate = DateTimeOffset.UtcNow.AddDays(1);
            Assert.True(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate, toDate));

            //future
            fromDate = DateTimeOffset.UtcNow.AddDays(1);
            toDate = DateTimeOffset.UtcNow.AddDays(2);
            Assert.False(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate, toDate));

            //completely overlapping today
            fromDate = DateTimeOffset.UtcNow.AddDays(-1);
            toDate = DateTimeOffset.UtcNow.AddDays(2);
            Assert.True(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate, toDate));

            //todate = start of today
            fromDate = DateTimeOffset.UtcNow.AddDays(-1);
            toDate = _serviceHelper.ToConfiguredTimeZone(DateTimeOffset.UtcNow);
            toDate = new DateTimeOffset(toDate.Date, toDate.Offset);
            Assert.False(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate, toDate));

            //fromdate = end of today
            fromDate = _serviceHelper.ToConfiguredTimeZone(DateTimeOffset.UtcNow.AddDays(1));
            fromDate = new DateTimeOffset(fromDate.Date, fromDate.Offset);
            toDate = DateTimeOffset.UtcNow.AddDays(2);
            Assert.False(_serviceHelper.TimePeriodIsIncludingLocaleToday(fromDate, toDate));
        }
    }
}
