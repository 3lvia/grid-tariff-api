using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Services.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateLocaledDateTimeOffsetDateTimeOffsetTest()
        {
            var mockServiceHelper = new Mock<ServiceHelper>(null);
            mockServiceHelper.Setup(x => x.CreateLocaledDateTimeOffset(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>())).Returns(DateTimeOffset.MaxValue);

            mockServiceHelper.Object.CreateLocaledDateTimeOffset(DateTimeOffset.MaxValue);
            mockServiceHelper.Verify(x => x.CreateLocaledDateTimeOffset(
                 It.IsAny<int>(),
                 It.IsAny<int>(),
                 It.IsAny<int>(),
                 It.IsAny<int>(),
                 It.IsAny<int>(),
                 It.IsAny<int>()),Times.Once);
        }

        [Fact()]
        public void GetMonthPeriodsMultiplePeriodsTest()
        {
            Setup();

            var fromDate = new DateTimeOffset(2022, 1, 3, 1, 0, 0, 0, new TimeSpan(1, 0, 0));
            var toDate = new DateTimeOffset(2022, 11, 7, 2, 0, 0, 0, new TimeSpan(1, 0, 0));
            var months = new List<int>() { 11, 12, 1, 2, 3 };

            var retVal = _serviceHelper.GetMonthPeriods(fromDate, toDate, months);
            Assert.Equal(2, retVal.Count);

            var timePeriod1 = retVal.ElementAt(0);
            var endDate1 = new DateTimeOffset(2022, 4, 1, 0, 0, 0, 0, new TimeSpan(2, 0, 0));
            Assert.Equal(fromDate, timePeriod1.StartDate);
            Assert.Equal(endDate1, timePeriod1.EndDate);

            var timePeriod2 = retVal.ElementAt(1);
            var startDate2 = new DateTimeOffset(2022, 11, 1, 0, 0, 0, 0, new TimeSpan(1, 0, 0));
            Assert.Equal(startDate2, timePeriod2.StartDate);
            Assert.Equal(toDate, timePeriod2.EndDate);
        }

        [Fact()]
        public void GetMonthPeriodsOverlapStartTest()
        {
            Setup();

            var fromDate = new DateTimeOffset(2022, 1, 3, 1, 0, 0, 0, new TimeSpan(1, 0, 0));
            var toDate = new DateTimeOffset(2022, 5, 7, 2, 0, 0, 0, new TimeSpan(1, 0, 0));
            var months = new List<int>() { 4, 5, 6, 7, 8, 9, };

            var fromDateCheckValue = new DateTimeOffset(2022, 4, 1, 0, 0, 0, 0, new TimeSpan(2, 0, 0));

            var retVal = _serviceHelper.GetMonthPeriods(fromDate, toDate, months);
            Assert.Single(retVal);

            var timePeriod = retVal.ElementAt(0);
            Assert.Equal(fromDateCheckValue, timePeriod.StartDate);
            Assert.Equal(toDate, timePeriod.EndDate);
        }


        [Fact()]
        public void GetMonthPeriodsTotalOverlapSeasonTest()
        {
            Setup();

            var fromDate = new DateTimeOffset(2022, 1, 3, 1, 0, 0, 0, new TimeSpan(1, 0, 0));
            var toDate = new DateTimeOffset(2022, 12, 7, 2, 0, 0, 0, new TimeSpan(1, 0, 0));
            var months = new List<int>() { 4, 5, 6, 7, 8, 9, };

            var fromDateCheckValue = new DateTimeOffset(2022, 4, 1, 0, 0, 0, 0, new TimeSpan(2, 0, 0));
            var toDateCheckValue = new DateTimeOffset(2022, 10, 1, 0, 0, 0, 0, new TimeSpan(2, 0, 0));

            var retVal = _serviceHelper.GetMonthPeriods(fromDate, toDate, months);
            Assert.Single(retVal);

            var timePeriod = retVal.ElementAt(0);
            Assert.Equal(fromDateCheckValue, timePeriod.StartDate);
            Assert.Equal(toDateCheckValue, timePeriod.EndDate);
        }


        [Fact()]
        public void GetMonthPeriodsOutsideSeasonTest()
        {
            Setup();

            var fromDate = new DateTimeOffset(2022, 1, 3, 1, 0, 0, 0, new TimeSpan(2, 0, 0));
            var toDate = new DateTimeOffset(2022, 2, 7, 2, 0, 0, 0, new TimeSpan(2, 0, 0));
            var months = new List<int>() { 4, 5, 6, 7, 8, 9, 10 };

            var retVal = _serviceHelper.GetMonthPeriods(fromDate, toDate, months);
            Assert.Empty(retVal);
        }

        [Fact()]
        public void GetMonthPeriodsInsideSeasonTest()
        {
            Setup();

            var fromDate = new DateTimeOffset(2022, 5, 3, 1, 0, 0, 0, new TimeSpan(2, 0, 0));
            var toDate = new DateTimeOffset(2022, 8, 7, 2, 0, 0, 0, new TimeSpan(2, 0, 0));
            var months = new List<int>() { 4, 5, 6, 7, 8, 9, 10 };

            var retVal = _serviceHelper.GetMonthPeriods(fromDate, toDate, months);
            Assert.Single(retVal);

            var timePeriod = retVal.ElementAt(0);
            Assert.Equal(fromDate, timePeriod.StartDate);
            Assert.Equal(toDate, timePeriod.EndDate);
        }

        [Theory]
        [InlineData(2022, 03, 27, 1, 0, 0, 60)]     //Just before Daylight Saving Time (Norway)
        [InlineData(2022, 03, 27, 3, 0, 0, 120)]     //Inside Daylight Saving Time (Norway)
        [InlineData(2022, 10, 30, 1, 0, 0, 120)]     //Just before Standard time (Norway)
        [InlineData(2022, 10, 30, 3, 0, 0, 60)]     //Inside Standard time (Norway)

        public void CreateLocaledDateTimeOffsetTest(
            int year, 
            int month, 
            int day, 
            int hour, 
            int minute, 
            int second,
            int houroffset)
        {
            Setup();

            var localized = _serviceHelper.CreateLocaledDateTimeOffset(year, month, day, hour,minute,second);
            Assert.Equal(year, localized.Year);
            Assert.Equal(month, localized.Month);
            Assert.Equal(day, localized.Day);
            Assert.Equal(hour, localized.Hour);
            Assert.Equal(minute, localized.Minute);
            Assert.Equal(second, localized.Second);
            Assert.Equal(houroffset, localized.Offset.Hours*60+ localized.Offset.Minutes);
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
            testValue = testValue.AddDays(daysToAdd);
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
