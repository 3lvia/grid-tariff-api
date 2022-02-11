using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.PriceStructure;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;


namespace GridTariffApi.Lib.Tests.Services
{
    public class TariffQueryServiceTests
    {
        private TariffQueryService _tariffQueryService;
        private IServiceHelper _serviceHelper;

        private void Setup()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            var gridTariffApIConfig = new GridTariffApiConfig()
            {
                TimeZoneForQueries = norwegianTimeZone
            };
            _serviceHelper = new ServiceHelper(gridTariffApIConfig);
            _tariffQueryService = new TariffQueryService(null, null, _serviceHelper);
        }

        [Theory]
        [InlineData(100, 0, 1, "identificator", 4.1667, 4.1667)]
        [InlineData(100, 25, 1, "identificator", 4.1667, 5.2083)]
        [InlineData(100, 0, 30, "identificator", 0.1389, 0.1389)]
        [InlineData(100, 25, 30, "identificator", 0.1389, .1736)]
        public void CalcMonthlyFixedPricesCalculationTest(int monthlyPriceExAllTaxes,
            int vatPercent,
            int daysInMonth,
            string identificator,
            decimal totalExVat,
            decimal total)
        {
            Setup();

            var vatTax = new FixedPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", vatPercent, "", "");
            var taxes = new List<FixedPriceTax>
            {
                vatTax
            };
            var fixedPriceLevel = new FixedPriceLevel(String.Empty, 0, 0, String.Empty, String.Empty, String.Empty, monthlyPriceExAllTaxes, String.Empty, String.Empty, String.Empty, String.Empty);

            var hourFixedPrices = _tariffQueryService.CalcMonthlyFixedPrices(fixedPriceLevel, taxes, daysInMonth, identificator);
            Assert.Equal(identificator, hourFixedPrices.Id);
            Assert.Equal(daysInMonth, hourFixedPrices.NumberOfDaysInMonth);
            Assert.Equal(totalExVat, (decimal)hourFixedPrices.TotalExVat, 4);
            Assert.Equal(total, (decimal)hourFixedPrices.Total, 4);
        }

        [Theory]
        [InlineData(100, 200, 0, 1, "identificator", 4.1667, 4.1667, 8.3333, 8.3333)]
        [InlineData(100, 200, 25, 1, "identificator2", 4.1667, 5.2083, 8.3333, 10.4167)]
        [InlineData(100, 200, 0, 30, "identificator", 0.1389, 0.1389, 0.2778, 0.2778)]
        [InlineData(100, 200, 25, 30, "identificator", 0.1389, 0.1736, 0.2778, 0.3472)]
        public void CalcMonthlyPowerPricesCalculationTest(int monthlyActivePriceExAllTaxes,
            int monthlyReActivePriceExAllTaxes,
            int vatPercent,
            int daysInMonth,
            string identificator,
            decimal totalActiveExVat,
            decimal totalActive,
            decimal totalReActiveExVat,
            decimal totalReActive)
        {
            Setup();

            var vatTax = new PowerPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", vatPercent, "", "");
            var taxes = new List<PowerPriceTax>
            {
                vatTax
            };

            var powerPriceLevel = new PowerPriceLevel(identificator, 0, 0, String.Empty, String.Empty, String.Empty, monthlyActivePriceExAllTaxes, monthlyReActivePriceExAllTaxes, String.Empty, String.Empty, String.Empty, String.Empty);
            var hourPowerPrices = _tariffQueryService.CalcMonthlyPowerPrices(powerPriceLevel, taxes, daysInMonth);
            Assert.Equal(totalActiveExVat, (decimal)hourPowerPrices.ActiveTotalExVat, 4);
            Assert.Equal(totalActive, (decimal)hourPowerPrices.ActiveTotal, 4);
            Assert.Equal(totalReActiveExVat, (decimal)hourPowerPrices.ReactiveTotalExVat, 4);
            Assert.Equal(totalReActive, (decimal)hourPowerPrices.ReactiveTotal, 4);
        }

        [Theory]
        [InlineData("nok", "kr/kwh", "level", 1, 0, 1.1, 1, "season", 3.1, 3.1, 0)]
        [InlineData("nok", "kr/kwh", "level", 1, 25, 1.1, 1, "season", 3.1, 3.875, 0.775)]
        [InlineData("nok", "kr/kwh", "level", 0, 25, 0, 0, "season", 0, 0, 0)]
        [InlineData("nok", "kr/kwh", "level", 10, 25, 0, 0, "season", 10, 12.5, 2.5)]
        [InlineData("nok", "kr/kwh", "level", 0, 25, 1, 0, "season", 1, 1.25, 0.25)]
        [InlineData("nok", "kr/kwh", "level", 0, 25, 0, 1, "season", 1, 1.25, 0.25)]
        [InlineData("nok", "kr/kwh", "level", 0, 25, 1, 1, "season", 2, 2.5, 0.5)]
        public void PriceLevelEnergyPriceToEnergyPriceLevelTest(
            string currency,
            string monetaryUnitOfMeasure,
            string level,
            decimal energyExTaxes,
            int vatPercentValue,
            double consumptionTaxValue,
            double enovaTaxValue,
            string season,
            decimal totalExVat,
            decimal total,
            decimal taxes
            )
        {
            Setup();

            var energyPrice = new EnergyPrice(null, currency, monetaryUnitOfMeasure);
            var energyPriceLevel = new EnergyPriceLevel(string.Empty, level, (double)energyExTaxes, null);

            var vatTax = new EnergyPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", vatPercentValue, "", "");
            var cumsumptionTax = new EnergyPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "consumptionTax", consumptionTaxValue, "", "");
            var enovaTax = new EnergyPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "enovaTax", enovaTaxValue, "", "");
            var energyTaxes = new List<EnergyPriceTax>
            {
                vatTax,
                cumsumptionTax,
                enovaTax
            };

            var energyPrices = _tariffQueryService.PriceLevelEnergyPriceToEnergyPriceLevel(energyPrice, energyPriceLevel, energyTaxes, season, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            Assert.Equal(DateTimeOffset.MinValue, energyPrices.StartDate);
            Assert.Equal(DateTimeOffset.MaxValue, energyPrices.EndDate);
            Assert.Equal(season, energyPrices.Season);
            Assert.Equal(level, energyPrices.Level);
            Assert.Equal(currency, energyPrices.Currency);
            Assert.Equal(monetaryUnitOfMeasure, energyPrices.MonetaryUnitOfMeasure);

            Assert.Equal(energyExTaxes, (decimal)energyPrices.EnergyExTaxes, 4);
            Assert.Equal(totalExVat, (decimal)energyPrices.TotalExVat, 4);
            Assert.Equal(total, (decimal)energyPrices.Total, 4);
            Assert.Equal(taxes, (decimal)energyPrices.Taxes);
        }

        [Theory]
        [InlineData(104, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 104, 26, 130)]
        [InlineData(152, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 152, 38, 190)]
        [InlineData(224, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 224, 56, 280)]
        [InlineData(300, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 300, 75, 375)]
        [InlineData(376, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 376, 94, 470)]
        [InlineData(452, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 452, 113, 565)]
        [InlineData(1000, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 1000, 250, 1250)]
        [InlineData(1376, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 1376, 344, 1720)]
        [InlineData(1752, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 1752, 438, 2190)]
        [InlineData(3344, 25, "1", null, 2, "2", "3", "4", "5", "6", "7", "8", 3344, 836, 4180)]

        public void PriceLevelPriceToFixedPriceLevelTest(
            int monthlyPriceExAllTaxes,
            int vatPercent,
            string id,
            double? valueMin,
            double? valueMax,
            string nextIdDown,
            string nextIdUp,
            string valueUnitOfMeasure,
            string monthlyUnitOfMeasure,
            string levelInfo,
            string currency,
            string monetaryUnitOfMeasure,
            decimal MonthlyTotalExVat,
            decimal monthlyTaxes,
            decimal monthlyTotal)
        {
            Setup();

            var vatTax = new FixedPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", vatPercent, "", "");
            var taxes = new List<FixedPriceTax>
            {
                vatTax
            };
            var fixedPricePriceLevel = new FixedPriceLevel(
                id,
                valueMin,
                valueMax,
                nextIdDown,
                nextIdUp,
                valueUnitOfMeasure,
                monthlyPriceExAllTaxes,
                monthlyUnitOfMeasure,
                levelInfo,
                currency,
                monetaryUnitOfMeasure);

            var fixedPriceLevel = _tariffQueryService.PriceLevelPriceToFixedPriceLevel(fixedPricePriceLevel, taxes);
            Assert.Equal(id, fixedPriceLevel.Id);
            Assert.Equal(valueMin, fixedPriceLevel.ValueMin);
            Assert.Equal(valueMax, fixedPriceLevel.ValueMax);
            Assert.Equal(nextIdDown, fixedPriceLevel.NextIdDown);
            Assert.Equal(nextIdUp, fixedPriceLevel.NextIdUp);
            Assert.Equal(valueUnitOfMeasure, fixedPriceLevel.ValueUnitOfMeasure);
            Assert.Equal(monthlyUnitOfMeasure, fixedPriceLevel.MonthlyUnitOfMeasure);
            Assert.Equal(levelInfo, fixedPriceLevel.LevelInfo);
            Assert.Equal(currency, fixedPriceLevel.Currency);
            Assert.Equal(monthlyUnitOfMeasure, fixedPriceLevel.MonthlyUnitOfMeasure);

            Assert.Equal(monthlyPriceExAllTaxes, fixedPriceLevel.MonthlyExTaxes, 4);
            Assert.Equal(MonthlyTotalExVat, (decimal)fixedPriceLevel.MonthlyExTaxes, 4);
            Assert.Equal(monthlyTaxes, (decimal)fixedPriceLevel.MonthlyTaxes, 4);
            Assert.Equal(monthlyTotal, (decimal)fixedPriceLevel.MonthlyTotal, 4);

        }

        [Theory]
        [InlineData(25, "1", null, 2, "2", "3", "4", 11, 5.61, "5", "6", "7", "8", 11, 11, 13.75, 2.75, 5.61, 5.61, 7.0125, 1.4025)]
        public void PriceLevelPriceToPowerPriceLevelTest(
            int vatPercent,
            string id,
            double? valueMin,
            double? valueMax,
            string nextIdDown,
            string nextIdUp,
            string valueUnitOfMeasure,
            decimal monthlyActivePowerExTaxes,
            decimal monthlyReactivePowerExTaxes,
            string monthlyUnitOfMeasure,
            string levelInfo,
            string currency,
            string monetaryUnitOfMeasure,

            decimal MonthlyActivePowerExTaxes,
            decimal MonthlyActivePowerTotalExVat,
            decimal MonthlyActivePowerTotal,
            decimal MonthlyActivePowerTaxes,
            decimal MonthlyReactivePowerExTaxes,
            decimal MonthlyReactivePowerTotalExVat,
            decimal MonthlyReactivePowerTotal,
            decimal MonthlyReactivePowerTaxes

            )
        {
            Setup();

            var vatTax = new PowerPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", vatPercent, "", "");
            var taxes = new List<PowerPriceTax>
            {
                vatTax
            };
            var powerPricePriceLevel = new PowerPriceLevel(id, valueMin, valueMax, nextIdDown, nextIdUp, valueUnitOfMeasure, (double)monthlyActivePowerExTaxes, (double)monthlyReactivePowerExTaxes, monthlyUnitOfMeasure, levelInfo, currency, monetaryUnitOfMeasure);

            var powerPriceLevel = _tariffQueryService.PriceLevelPowerPriceToPowerPriceLevel(powerPricePriceLevel, taxes);
            Assert.Equal(id, powerPriceLevel.Id);
            Assert.Equal(valueMin, powerPriceLevel.ValueMin);
            Assert.Equal(valueMax, powerPriceLevel.ValueMax);
            Assert.Equal(nextIdDown, powerPriceLevel.NextIdDown);
            Assert.Equal(nextIdUp, powerPriceLevel.NextIdUp);
            Assert.Equal(valueUnitOfMeasure, powerPriceLevel.ValueUnitOfMeasure);
            Assert.Equal(monthlyUnitOfMeasure, powerPriceLevel.MonthlyUnitOfMeasure);
            Assert.Equal(levelInfo, powerPriceLevel.LevelInfo);
            Assert.Equal(currency, powerPriceLevel.Currency);
            Assert.Equal(monthlyUnitOfMeasure, powerPriceLevel.MonthlyUnitOfMeasure);

            Assert.Equal(MonthlyActivePowerExTaxes, (decimal)powerPriceLevel.MonthlyActivePowerExTaxes, 4);
            Assert.Equal(MonthlyActivePowerTotalExVat, (decimal)powerPriceLevel.MonthlyActivePowerTotalExVat, 4);
            Assert.Equal(MonthlyActivePowerTotal, (decimal)powerPriceLevel.MonthlyActivePowerTotal, 4);
            Assert.Equal(MonthlyActivePowerTaxes, (decimal)powerPriceLevel.MonthlyActivePowerTaxes, 4);

            Assert.Equal(MonthlyReactivePowerExTaxes, (decimal)powerPriceLevel.MonthlyReactivePowerExTaxes, 4);
            Assert.Equal(MonthlyReactivePowerTotalExVat, (decimal)powerPriceLevel.MonthlyReactivePowerTotalExVat, 4);
            Assert.Equal(MonthlyReactivePowerTotal, (decimal)powerPriceLevel.MonthlyReactivePowerTotal, 4);
            Assert.Equal(MonthlyReactivePowerTaxes, (decimal)powerPriceLevel.MonthlyReactivePowerTaxes, 4);
        }

        [Theory]
        [InlineData("31/12/2021 23:00", false, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0000-0100", 60)]
        [InlineData("31/12/2021 23:00", true, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0000-0100", 60)]
        [InlineData("31/05/2021 22:00", false, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0000-0100", 60)]
        [InlineData("28/03/2021 00:00", false, 1, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0100-0300", 60)]
        [InlineData("31/10/2021 00:00", false, 2, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0200-0200", 60)]
        [InlineData("31/12/2021 23:15", false, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0015-0030", 15)]

        public void ToHourWithoutPowerTest(
            string startTimeStr,
            bool isPublicHoliday,
            int localedHour,
            string energyPriceId,
            decimal energyPriceTotal,
            decimal energyPriceTotalExVat,
            string fixePriceId,
            string fixedPriceHourId,
            string powerPriceId,
            string powerPriceHourId,

            string expectedShortName,
            int minutesToAdd)
        {
            Setup();

            var parseDateTimeAsUtc = DateTime.SpecifyKind(DateTime.ParseExact(startTimeStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), DateTimeKind.Utc);

            var startTime = new DateTimeOffset(parseDateTimeAsUtc);
            var expireAt = startTime.AddMinutes(minutesToAdd);

            var energyInformation = new EnergyInformation
            {
                HourArray = new Models.Digin.EnergyPrices[25]
            };
            energyInformation.HourArray[localedHour] = new Models.Digin.EnergyPrices
            {
                Id = energyPriceId,
                Total = (double)energyPriceTotal,
                TotalExVat = (double)energyPriceTotalExVat
            };


            var fixedPriceElement = new PriceElement
            {
                Id = fixePriceId,
                IdDaysInMonth = fixedPriceHourId
            };

            var powerPriceElement = new PriceElement
            {
                Id = powerPriceId,
                IdDaysInMonth = powerPriceHourId
            };

            var hourSeasonIndex = new HourSeasonIndex
            {
                FixedPriceValue = fixedPriceElement,
                PowerPriceValue = powerPriceElement
            };

            var hour = _tariffQueryService.ToHour(startTime, expireAt, hourSeasonIndex, energyInformation, isPublicHoliday);
            Assert.Equal(startTime, hour.StartTime);
            Assert.Equal(expireAt, hour.ExpiredAt);
            Assert.Equal(fixePriceId, hour.FixedPrice.Id);
            Assert.Equal(fixedPriceHourId, hour.FixedPrice.HourId);
            Assert.Equal(powerPriceId, hour.PowerPrice.Id);
            Assert.Equal(powerPriceHourId, hour.PowerPrice.HourId);

            Assert.Equal(energyPriceId, hour.EnergyPrice.Id);
            Assert.Equal((double)energyPriceTotal, hour.EnergyPrice.Total, 4);
            Assert.Equal((double)energyPriceTotalExVat, hour.EnergyPrice.TotalExVat, 4);
            Assert.Equal(isPublicHoliday, hour.IsPublicHoliday);
            Assert.Equal(expectedShortName, hour.ShortName);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        [InlineData("c")]
        [InlineData(null)]

        public void GenerateOverrideEnergyPricesDataTest(string level)
        {
            Setup();
            var priceLevelA = new Models.Digin.EnergyPrices() { Level = "a" };
            var priceLevelB = new Models.Digin.EnergyPrices() { Level = "b" };
            var priceLevelC = new Models.Digin.EnergyPrices() { Level = "c" };

            var priceInfo = new Models.Digin.PriceInfo() { EnergyPrices = new List<Models.Digin.EnergyPrices>() };
            priceInfo.EnergyPrices.Add(priceLevelA);
            priceInfo.EnergyPrices.Add(priceLevelB);
            priceInfo.EnergyPrices.Add(priceLevelC);

            var retVal = _tariffQueryService.GenerateOverrideEnergyPricesData(priceInfo, level);
            if (String.IsNullOrEmpty(level))
            {
                Assert.Null(retVal);
            }
            else
            {
                foreach (var hour in retVal.HourArray)
                {
                    Assert.Equal(level, hour.Level);
                }
            }
        }

        [Theory]
        [InlineData(false, false, 1)]
        [InlineData(false, true, 100)]
        [InlineData(true, false, 10)]
        [InlineData(true, true, 10)]
        public async Task DecideEneryInformationTest(bool isPublicHoliday, bool isWeekend, int numExpectedElements)
        {
            Setup();
            var hourSeasonIndex = new HourSeasonIndex
            {
                EnergyInformation = new EnergyInformation()
                {
                    HourArray = new Models.Digin.EnergyPrices[1]
                },
                EnergyInformationHoliday = new EnergyInformation()
                {
                    HourArray = new Models.Digin.EnergyPrices[10]
                },
                EnergyInformationWeekend = new EnergyInformation()
                {
                    HourArray = new Models.Digin.EnergyPrices[100]
                }
            };

            var retVal = await _tariffQueryService.DecideEneryInformation(hourSeasonIndex, isPublicHoliday, isWeekend);
            Assert.Equal(numExpectedElements, retVal.HourArray.Length);
        }

        [Theory]
        [InlineData("03/12/2021 22:00", false)]
        [InlineData("03/12/2021 23:00", true)]
        [InlineData("04/12/2021 22:00", true)]
        [InlineData("04/12/2021 23:00", true)]
        [InlineData("05/12/2021 22:00", true)]
        [InlineData("05/12/2021 23:00", false)]
        [InlineData("07/05/2021 21:00", false)]
        [InlineData("07/05/2021 22:00", true)]
        [InlineData("08/05/2021 21:00", true)]
        [InlineData("09/05/2021 22:00", false)]

        public void IsWeekendTest(string queryDateAsUtc, bool expectedVal)
        {
            var parseDateTimeAsUtc = DateTime.SpecifyKind(DateTime.ParseExact(queryDateAsUtc, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), DateTimeKind.Utc);
            Setup();
            var isWeekend = _tariffQueryService.IsWeekend(parseDateTimeAsUtc);
            Assert.Equal(expectedVal, isWeekend);
        }

        [Theory]
        [InlineData("02/12/2021 00:00", false, "03/12/2021 00:00")]
        [InlineData("02/12/2021 22:00", false, "03/12/2021 00:00")]
        [InlineData("02/12/2021 23:00", true, "03/12/2021 00:00")]
        [InlineData("03/12/2021 22:00", true, "03/12/2021 00:00")]
        [InlineData("03/12/2021 23:00", false, "03/12/2021 00:00")]
        [InlineData("04/12/2021 00:00", false, "03/12/2021 00:00")]

        [InlineData("16/05/2021 00:00", false, "17/05/2021 00:00")]
        [InlineData("16/05/2021 21:00", false, "17/05/2021 00:00")]
        [InlineData("16/05/2021 22:00", true, "17/05/2021 00:00")]
        [InlineData("17/05/2021 21:00", true, "17/05/2021 00:00")]
        [InlineData("17/05/2021 22:00", false, "17/05/2021 00:00")]
        [InlineData("18/05/2021 00:00", false, "17/05/2021 00:00")]

        public void IsPublicHolidayTest(string queryDateAsUtc, bool expectedVal, string holidayAsUtc)
        {
            Setup();

            var holidayUtc = DateTime.SpecifyKind(DateTime.ParseExact(holidayAsUtc, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), DateTimeKind.Utc);
            var holidayLocaled = _serviceHelper.GetTimeZonedDateTime(holidayUtc.Date);
            var holidays = new List<Holiday>
            {
                new Holiday(holidayLocaled, String.Empty)
            };

            var parseDateTimeAsUtc = DateTime.SpecifyKind(DateTime.ParseExact(queryDateAsUtc, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), DateTimeKind.Utc);
            var isPublicHoliday = _tariffQueryService.IsPublicHoliday(holidays, parseDateTimeAsUtc);
            Assert.Equal(expectedVal, isPublicHoliday);
        }

        [Fact]
        public void FilterFixedTaxesByDate()
        {

            Setup();
            DateTimeOffset date1 = new DateTimeOffset(new DateTime(2020, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date1Inside = new DateTimeOffset(new DateTime(2020, 02, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date2 = new DateTimeOffset(new DateTime(2020, 06, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date2Inside = new DateTimeOffset(new DateTime(2020, 07, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date3 = new DateTimeOffset(new DateTime(2020, 08, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date4 = new DateTimeOffset(new DateTime(2020, 12, 01, 0, 0, 0, DateTimeKind.Utc));

            FixedPriceTax tax1 = new FixedPriceTax(date1, date2,
                "tax1", 0, string.Empty, string.Empty);
            FixedPriceTax tax2 = new FixedPriceTax(date2, date3,
                "tax2", 0, string.Empty, string.Empty);
            FixedPriceTax tax3 = new FixedPriceTax(date3, date4,
                "tax3", 0, string.Empty, string.Empty);

            var taxes = new List<Models.PriceStructure.FixedPriceTax>
            {
                tax1,
                tax2,
                tax3
            };

            Assert.Equal(0, _tariffQueryService.FilterFixedPricesTaxByDate(taxes, DateTimeOffset.MinValue, date1).Count);
            Assert.Equal(0, _tariffQueryService.FilterFixedPricesTaxByDate(taxes, date4, DateTimeOffset.MaxValue).Count);
            Assert.Equal(2, _tariffQueryService.FilterFixedPricesTaxByDate(taxes, DateTimeOffset.MinValue, date3).Count);
            Assert.Null(_tariffQueryService.FilterFixedPricesTaxByDate(null, DateTimeOffset.MinValue, DateTimeOffset.MinValue));

            var endDateResult = _tariffQueryService.FilterFixedPricesTaxByDate(taxes, DateTimeOffset.MinValue, date3);
            Assert.Equal(2, endDateResult.Count);
            Assert.Empty(endDateResult.Where(x => x.TaxType == "tax3"));

            var startDateResult = _tariffQueryService.FilterFixedPricesTaxByDate(taxes, date2, DateTimeOffset.MaxValue);
            Assert.Equal(2, startDateResult.Count);
            Assert.Empty(startDateResult.Where(x => x.TaxType == "tax1"));

            Assert.Equal(1, _tariffQueryService.FilterFixedPricesTaxByDate(taxes, date1, date1Inside).Count);
            Assert.Equal(1, _tariffQueryService.FilterFixedPricesTaxByDate(taxes, date1Inside, date2).Count);
            Assert.Equal(2, _tariffQueryService.FilterFixedPricesTaxByDate(taxes, date1Inside, date2Inside).Count);
        }

        [Fact]
        public void FilterPowerPriceTaxesByDate()
        {

            Setup();
            DateTimeOffset date1 = new DateTimeOffset(new DateTime(2020, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date1Inside = new DateTimeOffset(new DateTime(2020, 02, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date2 = new DateTimeOffset(new DateTime(2020, 06, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date2Inside = new DateTimeOffset(new DateTime(2020, 07, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date3 = new DateTimeOffset(new DateTime(2020, 08, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date4 = new DateTimeOffset(new DateTime(2020, 12, 01, 0, 0, 0, DateTimeKind.Utc));

            PowerPriceTax tax1 = new PowerPriceTax(date1, date2,
                "tax1", 0, string.Empty, string.Empty);
            PowerPriceTax tax2 = new PowerPriceTax(date2, date3,
                "tax2", 0, string.Empty, string.Empty);
            PowerPriceTax tax3 = new PowerPriceTax(date3, date4,
                "tax3", 0, string.Empty, string.Empty);

            var taxes = new List<Models.PriceStructure.PowerPriceTax>
            {
                tax1,
                tax2,
                tax3
            };

            Assert.Equal(0, _tariffQueryService.FilterPowePriceTaxesByDate(taxes, DateTimeOffset.MinValue, date1).Count);
            Assert.Equal(0, _tariffQueryService.FilterPowePriceTaxesByDate(taxes, date4, DateTimeOffset.MaxValue).Count);
            Assert.Equal(2, _tariffQueryService.FilterPowePriceTaxesByDate(taxes, DateTimeOffset.MinValue, date3).Count);
            Assert.Null(_tariffQueryService.FilterPowePriceTaxesByDate(null, DateTimeOffset.MinValue, DateTimeOffset.MinValue));

            var endDateResult = _tariffQueryService.FilterPowePriceTaxesByDate(taxes, DateTimeOffset.MinValue, date3);
            Assert.Equal(2, endDateResult.Count);
            Assert.Empty(endDateResult.Where(x => x.TaxType == "tax3"));

            var startDateResult = _tariffQueryService.FilterPowePriceTaxesByDate(taxes, date2, DateTimeOffset.MaxValue);
            Assert.Equal(2, startDateResult.Count);
            Assert.Empty(startDateResult.Where(x => x.TaxType == "tax1"));

            Assert.Equal(1, _tariffQueryService.FilterPowePriceTaxesByDate(taxes, date1, date1Inside).Count);
            Assert.Equal(1, _tariffQueryService.FilterPowePriceTaxesByDate(taxes, date1Inside, date2).Count);
            Assert.Equal(2, _tariffQueryService.FilterPowePriceTaxesByDate(taxes, date1Inside, date2Inside).Count);
        }

        [Fact]
        public void FilterEnergyPriceTaxesByDate()
        {

            Setup();
            DateTimeOffset date1 = new DateTimeOffset(new DateTime(2020, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date1Inside = new DateTimeOffset(new DateTime(2020, 02, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date2 = new DateTimeOffset(new DateTime(2020, 06, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date2Inside = new DateTimeOffset(new DateTime(2020, 07, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date3 = new DateTimeOffset(new DateTime(2020, 08, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset date4 = new DateTimeOffset(new DateTime(2020, 12, 01, 0, 0, 0, DateTimeKind.Utc));

            EnergyPriceTax tax1 = new EnergyPriceTax(date1, date2,
                "tax1", 0, string.Empty, string.Empty);
            EnergyPriceTax tax2 = new EnergyPriceTax(date2, date3,
                "tax2", 0, string.Empty, string.Empty);
            EnergyPriceTax tax3 = new EnergyPriceTax(date3, date4,
                "tax3", 0, string.Empty, string.Empty);

            var taxes = new List<Models.PriceStructure.EnergyPriceTax>
            {
                tax1,
                tax2,
                tax3
            };

            Assert.Equal(0, _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, DateTimeOffset.MinValue, date1).Count);
            Assert.Equal(0, _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, date4, DateTimeOffset.MaxValue).Count);
            Assert.Equal(2, _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, DateTimeOffset.MinValue, date3).Count);
            Assert.Null(_tariffQueryService.FilterEnergyPriceTaxesByDate(null, DateTimeOffset.MinValue, DateTimeOffset.MinValue));

            var endDateResult = _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, DateTimeOffset.MinValue, date3);
            Assert.Equal(2, endDateResult.Count);
            Assert.Empty(endDateResult.Where(x => x.TaxType == "tax3"));

            var startDateResult = _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, date2, DateTimeOffset.MaxValue);
            Assert.Equal(2, startDateResult.Count);
            Assert.Empty(startDateResult.Where(x => x.TaxType == "tax1"));

            Assert.Equal(1, _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, date1, date1Inside).Count);
            Assert.Equal(1, _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, date1Inside, date2).Count);
            Assert.Equal(2, _tariffQueryService.FilterEnergyPriceTaxesByDate(taxes, date1Inside, date2Inside).Count);
        }


        [Fact]
        public void GetFixedPriceMonthsTest()
        {
            Setup();
            DateTimeOffset dateYearStart = new DateTimeOffset(new DateTime(2022, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateJanuarMiddle = new DateTimeOffset(new DateTime(2022, 01, 15, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateJanuarEnd = new DateTimeOffset(new DateTime(2022, 01, 31, 23, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateFebruaryMiddle = new DateTimeOffset(new DateTime(2022, 02, 15, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateYearEnd = new DateTimeOffset(new DateTime(2022, 12, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateLeapYearStart = new DateTimeOffset(new DateTime(2020, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateLeapYearEnd = new DateTimeOffset(new DateTime(2020, 12, 01, 0, 0, 0, DateTimeKind.Utc));

            var yearMonths = _tariffQueryService.GetDistinctFixedPriceMonths(dateYearStart, dateYearEnd);
            Assert.Equal(3, yearMonths.Count);
            Assert.Contains(28, yearMonths);
            Assert.Contains(30, yearMonths);
            Assert.Contains(31, yearMonths);

            var leapYearMonths = _tariffQueryService.GetDistinctFixedPriceMonths(dateLeapYearStart, dateLeapYearEnd);
            Assert.Equal(3, leapYearMonths.Count);
            Assert.Contains(29, leapYearMonths);
            Assert.Contains(30, leapYearMonths);
            Assert.Contains(31, leapYearMonths);

            var insideMonth = _tariffQueryService.GetDistinctFixedPriceMonths(dateJanuarMiddle, dateFebruaryMiddle);
            Assert.Equal(2, insideMonth.Count);
            Assert.Contains(31, insideMonth);
            Assert.Contains(28, insideMonth);

            var endOfMonth = _tariffQueryService.GetDistinctFixedPriceMonths(dateJanuarMiddle, dateJanuarEnd);
            Assert.Single(endOfMonth);
            Assert.Contains(31, endOfMonth);

        }

        [Fact]
        public void GenerateFixedPricesTopLevelTest()
        {
            Setup();

            DateTimeOffset dateYearStart = new DateTimeOffset(new DateTime(2022, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateYearEnd = new DateTimeOffset(new DateTime(2022, 12, 01, 0, 0, 0, DateTimeKind.Utc));
            var fixedPrices = new Models.PriceStructure.FixedPrices("a", new List<FixedPriceLevel>());

            var fixedPrice = _tariffQueryService.GenerateFixedPrices(dateYearStart, dateYearEnd, fixedPrices, null);

            Assert.True(fixedPrice.Id.Length > 0);
            Assert.Equal(dateYearStart, fixedPrice.StartDate);
            Assert.Equal(dateYearEnd, fixedPrice.EndDate);
            Assert.True(fixedPrice.PriceLevels != null);
            Assert.Empty(fixedPrice.PriceLevels);
        }

        [Fact]
        public void GenerateFixedPricesTest()
        {
            Setup();

            DateTimeOffset dateYearStart = new DateTimeOffset(new DateTime(2022, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dateYearEnd = new DateTimeOffset(new DateTime(2022, 12, 01, 0, 0, 0, DateTimeKind.Utc));

            var fixedPriceLevel1 = new FixedPriceLevel("fixedPriceLevel1", 0, 0, String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty);
            var fixedPriceLevel2 = new FixedPriceLevel("fixedPriceLevel2", 0, 0, String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty);
            var fixedPriceLevel3 = new FixedPriceLevel("fixedPriceLevel3", 0, 0, String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty);

            var fixedPrices = new Models.PriceStructure.FixedPrices("a", new List<FixedPriceLevel>() {
                fixedPriceLevel1,
                fixedPriceLevel2,
                fixedPriceLevel3 });

            var fixedPriceTaxes = new List<Models.PriceStructure.FixedPriceTax>
            {
                new FixedPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", 25, "", "")
            };

            var fixedPrice = _tariffQueryService.GenerateFixedPrices(dateYearStart, dateYearEnd, fixedPrices, fixedPriceTaxes);
            Assert.True(fixedPrice != null);
            Assert.True(fixedPrice.PriceLevels != null);
            Assert.Equal(3, fixedPrice.PriceLevels.Count);

            foreach (var fixedPriceLevel in fixedPrice.PriceLevels)
            {
                Assert.True(fixedPriceLevel.HourPrices != null);
                Assert.Equal(3, fixedPriceLevel.HourPrices.Count);
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 31));
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 28));
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 30));
            }
        }


        [Fact]
        public void CheckPriceLevelForMeteringPointsWithoutLevelLimits()
        {
            Setup();
            var meteringPointInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("a", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("b", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("c", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("d", "",0, null)
            };

            var fixedPrices = new Models.Digin.FixedPrices
            {
                Id = System.Guid.NewGuid().ToString()
            };
            var fixedPriceLevel = new Models.Digin.FixedPriceLevel() { Id = "pricelevelid" };

            var retVal = _tariffQueryService.MeteringPointsAndPriceLevelsMatchingConsumption(fixedPrices.Id, fixedPriceLevel, meteringPointInformations);
            Assert.NotNull(retVal);
        }

        [Fact]
        public void CheckPriceLevelForMeteringPointsWithLevelLimits()
        {
            Setup();
            var meteringPointInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("a", "",null, DateTimeOffset.MaxValue),
                new MeteringPointInformation("b", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("c", "",12, DateTimeOffset.MaxValue),
                new MeteringPointInformation("d", "",0, null)
            };
            var fixedPrices = new Models.Digin.FixedPrices
            {
                Id = System.Guid.NewGuid().ToString()
            };
            var fixedPriceLevel = new Models.Digin.FixedPriceLevel() { Id = "pricelevelid", ValueMin = 0, ValueMax = 13 };

            var retVal = _tariffQueryService.MeteringPointsAndPriceLevelsMatchingConsumption(fixedPrices.Id, fixedPriceLevel, meteringPointInformations);
            Assert.NotNull(retVal);
        }


        [Fact]
        public void AppendFixedPriceLevelsTest()
        {
            Setup();

            var fixedPrices = new Models.Digin.FixedPrices
            {
                PriceLevels = new List<Models.Digin.FixedPriceLevel>()
            };

            var fixedPriceLevel1 = new FixedPriceLevel("fixedPriceLevel1", 0, 0, String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty);
            var fixedPriceLevel2 = new FixedPriceLevel("fixedPriceLevel2", 0, 0, String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty);
            var fixedPriceLevel3 = new FixedPriceLevel("fixedPriceLevel3", 0, 0, String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty);

            var fixedPricePrices = new Models.PriceStructure.FixedPrices("a", new List<FixedPriceLevel>() {
                fixedPriceLevel1,
                fixedPriceLevel2,
                fixedPriceLevel3 });

            var fixedPriceTaxes = new List<Models.PriceStructure.FixedPriceTax>
            {
                new FixedPriceTax(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, "vat", 25, "", "")
            };

            //initialize pricelevel and add one monthday
            _tariffQueryService.AppendFixedPriceLevels(fixedPrices, fixedPricePrices, fixedPriceTaxes, 31);
            Assert.True(fixedPrices.PriceLevels != null);
            Assert.Equal(3, fixedPrices.PriceLevels.Count);
            foreach (var fixedPriceLevel in fixedPrices.PriceLevels)
            {
                Assert.True(fixedPriceLevel.HourPrices != null);
                Assert.Equal(1, fixedPriceLevel.HourPrices.Count);
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 31));
            }

            //no duplicate monthday when adding monthday already existing
            _tariffQueryService.AppendFixedPriceLevels(fixedPrices, fixedPricePrices, fixedPriceTaxes, 31);
            Assert.True(fixedPrices.PriceLevels != null);
            Assert.Equal(3, fixedPrices.PriceLevels.Count);
            foreach (var fixedPriceLevel in fixedPrices.PriceLevels)
            {
                Assert.True(fixedPriceLevel.HourPrices != null);
                Assert.Equal(1, fixedPriceLevel.HourPrices.Count);
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 31));
            }

            //add new monthday
            _tariffQueryService.AppendFixedPriceLevels(fixedPrices, fixedPricePrices, fixedPriceTaxes, 30);
            Assert.True(fixedPrices.PriceLevels != null);
            Assert.Equal(3, fixedPrices.PriceLevels.Count);
            foreach (var fixedPriceLevel in fixedPrices.PriceLevels)
            {
                Assert.True(fixedPriceLevel.HourPrices != null);
                Assert.Equal(2, fixedPriceLevel.HourPrices.Count);
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 31));
                Assert.Single(fixedPriceLevel.HourPrices.Where(a => a.NumberOfDaysInMonth == 30));
            }
        }

        [Fact]
        public void MeteringPointsToPriceLevelTests()
        {
            const string fixedPriceId = "fixedPriceId";
            const string fixedPriceLevelId = "fixedPriceLevelId";
            Setup();
            var mpInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("a", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("b", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("c", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("d", "",0, null)
            };

            var meteringPointsAndPriceLevels = _tariffQueryService.MeteringPointsToPriceLevel(fixedPriceId, fixedPriceLevelId, mpInformations);
            Assert.NotNull(meteringPointsAndPriceLevels);
            Assert.NotNull(meteringPointsAndPriceLevels.MeteringPoints);
            Assert.Equal(4, meteringPointsAndPriceLevels.MeteringPoints.Count);

            Assert.Equal(1, meteringPointsAndPriceLevels.MeteringPoints.Count(x => x.MeteringPointId == "a"));
            Assert.Equal(1, meteringPointsAndPriceLevels.MeteringPoints.Count(x => x.MeteringPointId == "b"));
            Assert.Equal(1, meteringPointsAndPriceLevels.MeteringPoints.Count(x => x.MeteringPointId == "c"));
            Assert.Equal(1, meteringPointsAndPriceLevels.MeteringPoints.Count(x => x.MeteringPointId == "d"));

            Assert.NotNull(meteringPointsAndPriceLevels.MeteringPoints.FirstOrDefault(x => x.MeteringPointId == "a").LastUpdated);
            Assert.Null(meteringPointsAndPriceLevels.MeteringPoints.FirstOrDefault(x => x.MeteringPointId == "d").LastUpdated);

            Assert.Equal(fixedPriceId, meteringPointsAndPriceLevels.CurrentFixedPriceLevel.Id);
            Assert.Equal(fixedPriceLevelId, meteringPointsAndPriceLevels.CurrentFixedPriceLevel.LevelId);
        }

        [Theory]
        [InlineData(null, null, false, 4)]
        [InlineData(200, null, true, 0)]
        [InlineData(99, null, false, 1)]
        [InlineData(-1, 2, false, 1)]
        [InlineData(3, 30, false, 2)]
        [InlineData(30, 3, true, 0)]

        public void CheckPriceLevelForMeteringPointsTests(double? fixedPriceLevelValueMin, double? fixedPriceLevelValueMax, bool expectingRetValNull, int numExpected)
        {
            Setup();

            var fixedPriceLevel = new Models.Digin.FixedPriceLevel
            {
                ValueMin = fixedPriceLevelValueMin,
                ValueMax = fixedPriceLevelValueMax
            };

            var mpInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("a", "", 0,DateTimeOffset.MaxValue),
                new MeteringPointInformation("b", "", 5,DateTimeOffset.MaxValue),
                new MeteringPointInformation("c", "", 15,DateTimeOffset.MaxValue),
                new MeteringPointInformation("d", "", 100,DateTimeOffset.MaxValue)
            };
            var retVal = _tariffQueryService.MeteringPointsAndPriceLevelsMatchingConsumption(String.Empty, fixedPriceLevel, mpInformations);
            if (expectingRetValNull)
            {
                Assert.Null(retVal);
            }
            else
            {
                Assert.NotNull(retVal);
                Assert.Equal(numExpected, retVal.MeteringPoints.Count);
            }
        }

        [Fact]
        public void AppendMeteringPointsToPriceLevelsWithoutPriceLevelTests()
        {
            Setup();

            var fixedPrices = new Models.Digin.FixedPrices
            {
                Id = System.Guid.NewGuid().ToString(),
                PriceLevels = new List<Models.Digin.FixedPriceLevel>
            {
                new Models.Digin.FixedPriceLevel()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    ValueMin = null,
                    ValueMax = 20
                },
                new Models.Digin.FixedPriceLevel()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    ValueMin = null,
                    ValueMax = 20
                }
            }
            };

            var retVal = _tariffQueryService.AppendMeteringPointsToPriceLevels(new List<MeteringPointInformation>(), fixedPrices);
            Assert.NotNull(retVal);
            Assert.Empty(retVal);

            var meteringPointInformations = new List<MeteringPointInformation>()
                {
                    new MeteringPointInformation("a", "", null,DateTimeOffset.MaxValue),
                    new MeteringPointInformation("b", "", null,DateTimeOffset.MaxValue),
                    new MeteringPointInformation("c", "", null,DateTimeOffset.MaxValue),
                    new MeteringPointInformation("d", "", null,null)
                };

            var retVal2 = _tariffQueryService.AppendMeteringPointsToPriceLevels(meteringPointInformations, fixedPrices);
            Assert.NotNull(retVal2);
            Assert.Single(retVal2);
            var meteringPointsAndPriceLevels = retVal2.First();
            Assert.NotNull(meteringPointsAndPriceLevels.CurrentFixedPriceLevel);
            Assert.Equal(fixedPrices.Id, meteringPointsAndPriceLevels.CurrentFixedPriceLevel.Id);
            Assert.Null(meteringPointsAndPriceLevels.CurrentFixedPriceLevel.LevelId);
            Assert.Equal(4, meteringPointsAndPriceLevels.MeteringPoints.Count);
            Assert.Equal(3, meteringPointsAndPriceLevels.MeteringPoints.Where(x => x.LastUpdated != null).ToList().Count);
            Assert.Equal("d", meteringPointsAndPriceLevels.MeteringPoints.FirstOrDefault(x => x.LastUpdated == null).MeteringPointId);
        }


        [Fact]
        public void AppendMeteringPointsToPriceLevelsWithPriceLevelTests()
        {
            Setup();

            var fixedPrices = new Models.Digin.FixedPrices
            {
                Id = System.Guid.NewGuid().ToString(),
                PriceLevels = new List<Models.Digin.FixedPriceLevel>()
            };
            fixedPrices.PriceLevels.Add(new Models.Digin.FixedPriceLevel()
            {
                Id = System.Guid.NewGuid().ToString(),
                ValueMin = null,
                ValueMax = 20
            });
            fixedPrices.PriceLevels.Add(new Models.Digin.FixedPriceLevel()
            {
                Id = System.Guid.NewGuid().ToString(),
                ValueMin = 30,
                ValueMax = 50
            });

            var retVal = _tariffQueryService.AppendMeteringPointsToPriceLevels(new List<MeteringPointInformation>(), fixedPrices);
            Assert.NotNull(retVal);
            Assert.Empty(retVal);

            var meteringPointInformations = new List<MeteringPointInformation>()
                {
                    new MeteringPointInformation("a", "", 4,DateTimeOffset.MaxValue),
                    new MeteringPointInformation("b", "", 8,DateTimeOffset.MaxValue),
                    new MeteringPointInformation("c", "", 12,DateTimeOffset.MaxValue),
                    new MeteringPointInformation("d", "", 21,null)
                };

            var retVal2 = _tariffQueryService.AppendMeteringPointsToPriceLevels(meteringPointInformations, fixedPrices);
            Assert.NotNull(retVal2);
            Assert.True(0 < retVal2.Count);
        }

        [Fact]
        public async Task QueryMeteringPointsTariffsAsyncTests()
        {
            Setup();
            var meteringPoints = new List<String>
            {
                "mp_a",
                "mp_b",
                "mp_c"
            };

            var mockRetVal = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("mp_a", "standard", 0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("mp_b", "standard", 0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("mp_b", "fobar", 0, DateTimeOffset.MaxValue)
            };

            var tariffPriceCache = new Mock<ITariffPriceCache>();
            tariffPriceCache
                .Setup(x => x.GetMeteringPointInformationsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, It.IsAny<List<String>>()))
                .Returns(Task.FromResult(mockRetVal));

            var gridTariffCollectionStandard = new Models.Digin.GridTariffCollection() { GridTariff = new Models.Digin.GridTariff() { TariffType = new Models.Digin.TariffType() { TariffKey = "standard" } } };
            var gridTariffCollectionFobar = new Models.Digin.GridTariffCollection() { GridTariff = new Models.Digin.GridTariff() { TariffType = new Models.Digin.TariffType() { TariffKey = "fobar" } } };

            var mock = new Mock<TariffQueryService>(tariffPriceCache.Object, (IObjectConversionHelper)null, _serviceHelper);
            mock.Setup(x => x.QueryTariffAsyncUsingProductKey("standard", DateTimeOffset.MinValue, DateTimeOffset.MaxValue)).Returns(Task.FromResult(gridTariffCollectionStandard));
            mock.Setup(x => x.QueryTariffAsyncUsingProductKey("fobar", DateTimeOffset.MinValue, DateTimeOffset.MaxValue)).Returns(Task.FromResult(gridTariffCollectionFobar));
            mock.Setup(x => x.GenerateTariffAndAppendMeteringPointsAsync(It.IsAny<String>(), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, It.IsAny<List<MeteringPointInformation>>()))
                .Returns(Task.FromResult(new Models.Digin.GridTariffCollection()));

            var retVal = await mock.Object.QueryMeteringPointsTariffsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, meteringPoints);
            mock.Verify(x => x.GenerateTariffAndAppendMeteringPointsAsync("standard", DateTimeOffset.MinValue, DateTimeOffset.MaxValue, It.IsAny<List<MeteringPointInformation>>()), Times.Once);
            mock.Verify(x => x.GenerateTariffAndAppendMeteringPointsAsync("fobar", DateTimeOffset.MinValue, DateTimeOffset.MaxValue, It.IsAny<List<MeteringPointInformation>>()), Times.Once);
            mock.Verify(x => x.GenerateTariffAndAppendMeteringPointsAsync(It.IsAny<String>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<List<MeteringPointInformation>>()), Times.Exactly(2));

            Assert.NotNull(retVal);
            Assert.NotNull(retVal.GridTariffCollections);
            Assert.Equal(2, retVal.GridTariffCollections.Count);
        }
        [Fact]
        public async Task QueryMeteringPointsTariffsAsyncTodayMissingTariffTests()
        {
            Setup();
            var meteringPointId = "mp_a";

            var meteringPointInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("mp_a", null, null, null)
            };
            var mockRetVal = new List<MeteringPointInformation>
            {
                new MeteringPointInformation(meteringPointId, null, 0, DateTimeOffset.MaxValue)
            };

            var tariffPriceCache = new Mock<ITariffPriceCache>();
            tariffPriceCache
                .Setup(x => x.GetMeteringPointInformationsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, It.IsAny<List<String>>()))
                .Returns(Task.FromResult(mockRetVal));

            var gridTariffCollectionStandard = new Models.Digin.GridTariffCollection() { GridTariff = new Models.Digin.GridTariff()};
            var tariffQueryServiceMock = new Mock<TariffQueryService>(tariffPriceCache.Object, (IObjectConversionHelper)null, _serviceHelper)
            {
                CallBase = true
            };
            tariffQueryServiceMock.Setup(x => x.QueryTariffAsyncUsingProductKey(It.IsAny<String>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(gridTariffCollectionStandard));

            string tariffKey = null;
            var fromDate = DateTimeOffset.UtcNow.Date.AddHours(3);
            var toDate = DateTimeOffset.UtcNow.Date.AddHours(4);

            var retVal = await tariffQueryServiceMock.Object.GenerateTariffAndAppendMeteringPointsAsync(tariffKey, fromDate, toDate, meteringPointInformations);
            Assert.NotNull(retVal);
            Assert.Single(retVal.MeteringPointsAndPriceLevels);
            var meteringPointsAndPriceLevel = retVal.MeteringPointsAndPriceLevels.First();
            Assert.NotNull(meteringPointsAndPriceLevel.CurrentFixedPriceLevel);

            var currentFixedPriceLevel = meteringPointsAndPriceLevel.CurrentFixedPriceLevel;
            Assert.True(String.IsNullOrEmpty(currentFixedPriceLevel.Id));
            Assert.True(String.IsNullOrEmpty(currentFixedPriceLevel.LevelId));

            Assert.NotNull(meteringPointsAndPriceLevel.MeteringPoints);
            var meteringPoints = meteringPointsAndPriceLevel.MeteringPoints;
            Assert.Single(meteringPoints);
            Assert.Equal(1, meteringPoints.Count(x => x.MeteringPointId == meteringPointId));
        }
        [Fact]
        public async Task GenerateTariffAndAppendMeteringPointsIncludingLocaleTodayTests()
        {
            Setup();
            var tariffPriceCache = new Mock<ITariffPriceCache>();
            var gridTariffCollectionStandard = new Models.Digin.GridTariffCollection() { GridTariff = new Models.Digin.GridTariff() { TariffType = new Models.Digin.TariffType() { TariffKey = "standard" } } };
            gridTariffCollectionStandard.GridTariff.TariffPrice = new Models.Digin.TariffPrice
            {
                PriceInfo = new Models.Digin.PriceInfo()
            };
            gridTariffCollectionStandard.GridTariff.TariffPrice.PriceInfo.FixedPrices = new List<Models.Digin.FixedPrices>();

            var fixedPrices = new Models.Digin.FixedPrices()
            {
                StartDate = DateTimeOffset.UtcNow.AddMonths(-1),
                EndDate = DateTimeOffset.UtcNow.AddMonths(1),
                PriceLevels = new List<Models.Digin.FixedPriceLevel>() { new Models.Digin.FixedPriceLevel() }
            };
            gridTariffCollectionStandard.GridTariff.TariffPrice.PriceInfo.FixedPrices.Add(fixedPrices);


            var meteringPointInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation("a", "",null, DateTimeOffset.MaxValue),
                new MeteringPointInformation("b", "",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation("c", "",12, DateTimeOffset.MaxValue),
                new MeteringPointInformation("d", "",0, null)
            };

            var serviceHelperMock = new Mock<ServiceHelper>(new GridTariffApiConfig());
            serviceHelperMock.Setup(x => x.TimePeriodIsIncludingLocaleToday(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(true);

            var tariffQueryServiceMock = new Mock<TariffQueryService>(tariffPriceCache.Object, (IObjectConversionHelper)null, serviceHelperMock.Object)
            {
                CallBase = true
            };
            tariffQueryServiceMock.Setup(x => x.QueryTariffAsyncUsingProductKey(It.IsAny<String>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(gridTariffCollectionStandard));
            tariffQueryServiceMock.Setup(x => x.AppendMeteringPointsToPriceLevels(It.IsAny<List<MeteringPointInformation>>(), It.IsAny<Models.Digin.FixedPrices>()));
            tariffQueryServiceMock.Setup(x => x.GetFixedPricesValidToday(It.IsAny < List <Models.Digin.FixedPrices>>()));

            var retVal = await tariffQueryServiceMock.Object.GenerateTariffAndAppendMeteringPointsAsync(String.Empty, DateTimeOffset.UtcNow.AddDays(-2), DateTimeOffset.UtcNow.AddDays(1), meteringPointInformations);
            tariffQueryServiceMock.Verify(x => x.QueryTariffAsyncUsingProductKey(It.IsAny<String>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.Once);
            serviceHelperMock.Verify(x => x.TimePeriodIsIncludingLocaleToday(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.Exactly(2));
            tariffQueryServiceMock.Verify(x => x.GetFixedPricesValidToday(It.IsAny<List<Models.Digin.FixedPrices>>()), Times.Once);
            tariffQueryServiceMock.Verify(x => x.AppendMeteringPointsToPriceLevels(It.IsAny<List<MeteringPointInformation>>(), It.IsAny<Models.Digin.FixedPrices>()), Times.Once);

            Assert.NotNull(retVal);
            Assert.NotNull(retVal.MeteringPointsAndPriceLevels);
            Assert.Single(retVal.MeteringPointsAndPriceLevels);
            Assert.Equal(meteringPointInformations.Count, retVal.MeteringPointsAndPriceLevels.FirstOrDefault().MeteringPoints.Count);
        }


        [Fact]
        public async Task GenerateTariffAndAppendMeteringPointsExcludingLocaleTodayTests()
        {
            Setup();
            var tariffPriceCache = new Mock<ITariffPriceCache>();
            var gridTariffCollectionStandard = new Models.Digin.GridTariffCollection() { GridTariff = new Models.Digin.GridTariff() { TariffType = new Models.Digin.TariffType() { TariffKey = "standard" } } };
            gridTariffCollectionStandard.GridTariff.TariffPrice = new Models.Digin.TariffPrice
            {
                PriceInfo = new Models.Digin.PriceInfo()
            };
            gridTariffCollectionStandard.GridTariff.TariffPrice.PriceInfo.FixedPrices = new List<Models.Digin.FixedPrices>();

            var fixedPrices = new Models.Digin.FixedPrices()
            {
                StartDate = DateTimeOffset.UtcNow.AddMonths(-1),
                EndDate = DateTimeOffset.UtcNow.AddMonths(1),
                PriceLevels = new List<Models.Digin.FixedPriceLevel>() { new Models.Digin.FixedPriceLevel() }
            };
            gridTariffCollectionStandard.GridTariff.TariffPrice.PriceInfo.FixedPrices.Add(fixedPrices);


            var meteringPointInformations = new List<MeteringPointInformation>
            {
                new MeteringPointInformation(String.Empty, "a",null, DateTimeOffset.MaxValue),
                new MeteringPointInformation(String.Empty, "b",0, DateTimeOffset.MaxValue),
                new MeteringPointInformation(String.Empty, "c",12, DateTimeOffset.MaxValue),
                new MeteringPointInformation(String.Empty, "d",0, null)
            };

            var serviceHelperMock = new Mock<ServiceHelper>(new GridTariffApiConfig());
            serviceHelperMock.Setup(x => x.TimePeriodIsIncludingLocaleToday(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(false);

            var tariffQueryServiceMock = new Mock<TariffQueryService>(tariffPriceCache.Object, (IObjectConversionHelper)null, serviceHelperMock.Object)
            {
                CallBase = true
            };
            tariffQueryServiceMock.Setup(x => x.QueryTariffAsyncUsingProductKey(It.IsAny<String>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(gridTariffCollectionStandard));
            tariffQueryServiceMock.Setup(x => x.AppendMeteringPointsToPriceLevels(It.IsAny<List<MeteringPointInformation>>(), It.IsAny<Models.Digin.FixedPrices>()));
            tariffQueryServiceMock.Setup(x => x.GetFixedPricesValidToday(It.IsAny<List<Models.Digin.FixedPrices>>()));
            tariffQueryServiceMock.Setup(x => x.MeteringPointsToPriceLevel(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<List<MeteringPointInformation>>()));

            var retVal = await tariffQueryServiceMock.Object.GenerateTariffAndAppendMeteringPointsAsync(String.Empty, DateTimeOffset.UtcNow.AddDays(-2), DateTimeOffset.UtcNow.AddDays(1), meteringPointInformations);
            tariffQueryServiceMock.Verify(x => x.QueryTariffAsyncUsingProductKey(It.IsAny<String>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.Once);
            serviceHelperMock.Verify(x => x.TimePeriodIsIncludingLocaleToday(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.Once);
            tariffQueryServiceMock.Verify(x => x.GetFixedPricesValidToday(It.IsAny<List<Models.Digin.FixedPrices>>()), Times.Never);
            tariffQueryServiceMock.Verify(x => x.AppendMeteringPointsToPriceLevels(It.IsAny<List<MeteringPointInformation>>(), It.IsAny<Models.Digin.FixedPrices>()), Times.Never);
            tariffQueryServiceMock.Verify(x => x.MeteringPointsToPriceLevel(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<List<MeteringPointInformation>>()), Times.Once);

            Assert.NotNull(retVal);
            Assert.NotNull(retVal.MeteringPointsAndPriceLevels);
            Assert.Single(retVal.MeteringPointsAndPriceLevels);
            Assert.Equal(meteringPointInformations.Count, retVal.MeteringPointsAndPriceLevels.FirstOrDefault().MeteringPoints.Count);
        }



        [Fact]
        public void GetFixedPricesValidTodayTests()
        {
            Setup();
            var endDateWithinToday = DateTimeOffset.UtcNow;

            Assert.Null(_tariffQueryService.GetFixedPricesValidToday(null));

            var fixedPrices = new List<Models.Digin.FixedPrices>();
            Assert.Null(_tariffQueryService.GetFixedPricesValidToday(fixedPrices));

            //without valid
            fixedPrices.Add(new Models.Digin.FixedPrices()
            {
                StartDate = DateTimeOffset.UtcNow.AddDays(-2),
                EndDate = DateTimeOffset.UtcNow.AddDays(-1),
            });
            Assert.Null(_tariffQueryService.GetFixedPricesValidToday(fixedPrices));

            //with valid at end
            fixedPrices.Add(new Models.Digin.FixedPrices()
            {
                StartDate = DateTimeOffset.UtcNow.AddDays(-2),
                EndDate = endDateWithinToday,
            });
            var retval1 = _tariffQueryService.GetFixedPricesValidToday(fixedPrices);
            Assert.NotNull(retval1);
            Assert.Equal(endDateWithinToday, retval1.EndDate);

            //with valid in between
            fixedPrices.Add(new Models.Digin.FixedPrices()
            {
                StartDate = DateTimeOffset.UtcNow.AddDays(1),
                EndDate = DateTimeOffset.UtcNow.AddDays(2),
            });
            var retval2 = _tariffQueryService.GetFixedPricesValidToday(fixedPrices);
            Assert.NotNull(retval2);
            Assert.Equal(endDateWithinToday, retval2.EndDate);
        }

        [Fact]
        public async Task QueryTariffAsyncUsingTariffKeyMissTests()
        {
            Setup();

            var utcNow = DateTimeOffset.UtcNow;
            var tariffKey = String.Empty;

            var tariffPriceCache = new Mock<ITariffPriceCache>();
            tariffPriceCache.Setup(x => x.GetTariffsAsync()).Returns(Task.FromResult((IReadOnlyList<TariffType>)null));

            var tariffQueryServiceMock = new Mock<TariffQueryService>(tariffPriceCache.Object, (IObjectConversionHelper)null, (ServiceHelper)null)
            {
                CallBase = true
            };

            var retVal = await tariffQueryServiceMock.Object.QueryTariffAsyncUsingTariffKey(tariffKey, utcNow, utcNow);
            tariffQueryServiceMock.Verify(x => x.QueryTariffAsyncUsingProductKey(tariffKey, utcNow, utcNow), Times.Once);
            Assert.NotNull(retVal);
        }

        [Fact]
        public async Task QueryTariffAsyncUsingTariffKeyHitTests()
        {
            Setup();

            var utcNow = DateTimeOffset.UtcNow;
            var tariffKey = "TariffKey";
            var productKey = "ProductKey";

            var tariffs = new List<TariffType>
            {
                new TariffType("TariffKey", "ProductKey", String.Empty, String.Empty, String.Empty, String.Empty, false, DateTimeOffset.UtcNow, false, null, 0, null, null)
            };

            var tariffPriceCache = new Mock<ITariffPriceCache>();
            tariffPriceCache.Setup(x => x.GetTariffsAsync()).Returns(Task.FromResult((IReadOnlyList < TariffType > )tariffs.AsReadOnly()));

            var tariffQueryServiceMock = new Mock<TariffQueryService>(tariffPriceCache.Object, (IObjectConversionHelper)null, (ServiceHelper)null);
            tariffQueryServiceMock.Setup(x => x.QueryTariffAsyncUsingProductKey(productKey, utcNow, utcNow)).Returns(Task.FromResult(new Models.Digin.GridTariffCollection()));
            tariffQueryServiceMock.CallBase = true;

            var retVal = await tariffQueryServiceMock.Object.QueryTariffAsyncUsingTariffKey(tariffKey, utcNow, utcNow);
            tariffQueryServiceMock.Verify(x => x.QueryTariffAsyncUsingProductKey(productKey, utcNow, utcNow), Times.Once);
            Assert.NotNull(retVal);
        }
    }
}