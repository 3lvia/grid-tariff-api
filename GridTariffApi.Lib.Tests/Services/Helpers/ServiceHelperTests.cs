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
        public void GetStartOfNextMonthTests()
        {
            Setup();
            //change of year
            var test1 = new DateTimeOffset(2021, 12, 31, 5, 5, 5, new TimeSpan(1, 0, 0));
            var retVal1 = _serviceHelper.GetStartOfNextMonth(test1);
            Assert.Equal(2022,retVal1.Year);
            Assert.Equal(1, retVal1.Month);
            Assert.Equal(1, retVal1.Day);
            Assert.Equal(0, retVal1.Hour);
            Assert.Equal(0, retVal1.Minute);
            Assert.Equal(0, retVal1.Second);
            Assert.Equal(1, retVal1.Offset.Hours);

            //from standard time to DST
            var test2 = new DateTimeOffset(2022, 3, 26, 5, 5, 5, new TimeSpan(1, 0, 0));
            var retVal2 = _serviceHelper.GetStartOfNextMonth(test2);
            Assert.Equal(2022, retVal2.Year);
            Assert.Equal(4, retVal2.Month);
            Assert.Equal(1, retVal2.Day);
            Assert.Equal(0, retVal2.Hour);
            Assert.Equal(0, retVal2.Minute);
            Assert.Equal(0, retVal2.Second);
            Assert.Equal(2, retVal2.Offset.Hours);

            //from DST to standardtime
            var test3 = new DateTimeOffset(2022, 10, 26, 5, 5, 5, new TimeSpan(1, 0, 0));
            var retVal3 = _serviceHelper.GetStartOfNextMonth(test3);
            Assert.Equal(2022, retVal3.Year);
            Assert.Equal(11, retVal3.Month);
            Assert.Equal(1, retVal3.Day);
            Assert.Equal(0, retVal3.Hour);
            Assert.Equal(0, retVal3.Minute);
            Assert.Equal(0, retVal3.Second);
            Assert.Equal(1, retVal3.Offset.Hours);

            //"Wrong" offset for the configured timezone
            var test4 = new DateTimeOffset(2022, 10, 26, 5, 5, 5, new TimeSpan(5, 0, 0));
            var retVal4 = _serviceHelper.GetStartOfNextMonth(test4);
            Assert.Equal(2022, retVal4.Year);
            Assert.Equal(11, retVal4.Month);
            Assert.Equal(1, retVal4.Day);
            Assert.Equal(0, retVal4.Hour);
            Assert.Equal(0, retVal4.Minute);
            Assert.Equal(0, retVal4.Second);
            Assert.Equal(1, retVal4.Offset.Hours);

        }


        private static DateTimeOffset GetStartOfNextMonthLocaled(DateTimeOffset fromDateLocaled)
        {
            var retVal = new DateTimeOffset(fromDateLocaled.Year, fromDateLocaled.Month, 1, 0, 0, 0, 0, fromDateLocaled.Offset);
            retVal = retVal.AddMonths(1);
            return retVal;
        }



        [Fact()]
        public void WithCorrectedLocalizedOffsetTest()
        {
            var mockServiceHelper = new Mock<ServiceHelper>(null);
            mockServiceHelper.Setup(x => x.CreateLocaledDateTimeOffset(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>())).Returns(DateTimeOffset.MaxValue);

            mockServiceHelper.Object.WithCorrectedLocalizedOffset(DateTimeOffset.MaxValue);
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
        [Fact]
        public void DecideEndOfDayTests()
        {
            Setup();
            //no DST change, before mid day
            var currentDateTime1 = new DateTimeOffset(2022, 06, 01, 1, 0, 0, new TimeSpan(2, 0, 0));
            var paramToDate1 = new DateTimeOffset(2022, 12, 01, 1, 0, 0, new TimeSpan(1, 0, 0));
            var expected1 = new DateTimeOffset(2022, 06, 02, 0, 0, 0, new TimeSpan(2, 0, 0));
            var retVal1 = _serviceHelper.DecideEndOfDay(paramToDate1, currentDateTime1);
            Assert.Equal(expected1,retVal1);

            //no DST change, after mid dat
            var currentDateTime2 = new DateTimeOffset(2022, 06, 01, 18, 0, 0, new TimeSpan(2, 0, 0));
            var retVal2= _serviceHelper.DecideEndOfDay(paramToDate1, currentDateTime2);
            Assert.Equal(expected1, retVal2);

            //no DST change, at midnight
            var currentDateTime3 = new DateTimeOffset(2022, 06, 01, 0, 0, 0, new TimeSpan(2, 0, 0));
            var retVal3 = _serviceHelper.DecideEndOfDay(paramToDate1, currentDateTime3);
            Assert.Equal(expected1, retVal3);

            //picking least of next day and todate
            var paramToDate4 = new DateTimeOffset(2022, 6, 01, 18, 0, 0, new TimeSpan(2, 0, 0));
            var retVal4 = _serviceHelper.DecideEndOfDay(paramToDate4, currentDateTime3);
            Assert.Equal(paramToDate4, retVal4);

            //to DST within timeperiod
            var currentDateTime5 = new DateTimeOffset(2022, 03, 27, 00, 0, 0, new TimeSpan(1, 0, 0));
            var expected5 = new DateTimeOffset(2022, 03, 28, 0, 0, 0, new TimeSpan(2, 0, 0));
            var retVal5 = _serviceHelper.DecideEndOfDay(paramToDate4, currentDateTime5);
            Assert.Equal(expected5, retVal5);

            //to no DST within timperiod
            var currentDateTime6 = new DateTimeOffset(2022, 10, 30, 00, 0, 0, new TimeSpan(2, 0, 0));
            var expected6 = new DateTimeOffset(2022, 10, 31, 0, 0, 0, new TimeSpan(1, 0, 0));
            var retVal6 = _serviceHelper.DecideEndOfDay(paramToDate1, currentDateTime6);
            Assert.Equal(expected6, retVal6);

        }
    }
}
