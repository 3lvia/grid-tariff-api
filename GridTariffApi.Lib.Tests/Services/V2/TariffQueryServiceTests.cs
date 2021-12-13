﻿using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.Internal;

using GridTariffApi.Lib.Models.V2.PriceStructure;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.V2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;


namespace GridTariffApi.Lib.Tests.Services.V2
{
    public class TariffQueryServiceTests
    {
        private TariffQueryService _tariffQueryService;
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
            var serviceHelper = new ServiceHelper(gridTariffApIConfig);

            _tariffQueryService = new TariffQueryService(null, null, serviceHelper);

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
            var taxes = new List<FixedPriceTax>();
            taxes.Add(vatTax);
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
            var taxes = new List<PowerPriceTax>();
            taxes.Add(vatTax);

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
            Assert.Equal(totalExVat, (decimal)energyPrices.TotalExVat,4);
            Assert.Equal(total, (decimal)energyPrices.Total,4);
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
            var taxes = new List<FixedPriceTax>();
            taxes.Add(vatTax);
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

            Assert.Equal(monthlyPriceExAllTaxes, fixedPriceLevel.MonthlyExTaxes,4);
            Assert.Equal(MonthlyTotalExVat, (decimal)fixedPriceLevel.MonthlyExTaxes,4);
            Assert.Equal(monthlyTaxes, (decimal)fixedPriceLevel.MonthlyTaxes,4);
            Assert.Equal(monthlyTotal, (decimal)fixedPriceLevel.MonthlyTotal,4);

        }

        [Theory]
        [InlineData(25, "1", null, 2, "2", "3", "4", 11, 5.61,"5", "6", "7", "8", 11,11,13.75,2.75, 5.61,5.61,7.0125,1.4025)]
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
            var taxes = new List<PowerPriceTax>();
            taxes.Add(vatTax);
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
        [InlineData("31/12/2021 23:00", false, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0000-0100",60)]
        [InlineData("31/12/2021 23:00", true, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0000-0100",60)]
        [InlineData("31/05/2021 22:00", false, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0000-0100",60)]
        [InlineData("28/03/2021 00:00", false, 1, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0100-0300",60)]
        [InlineData("31/10/2021 00:00", false, 2, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0200-0200",60)]
        [InlineData("31/12/2021 23:15", false, 0, "energyPriceId", 5, 4, "fixePriceId", "fixedPriceHourId", "powerPriceId", "powerPriceHourId", "0015-0030",15)]

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

            var startTime = DateTimeOffset.ParseExact(startTimeStr,"dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture);
            var expireAt = startTime.AddMinutes(minutesToAdd);

            var energyInformation = new EnergyInformation();
            energyInformation.HourArray = new Models.V2.Digin.EnergyPrices[25];
            energyInformation.HourArray[localedHour] = new Models.V2.Digin.EnergyPrices();
            energyInformation.HourArray[localedHour].Id = energyPriceId;
            energyInformation.HourArray[localedHour].Total = (double)energyPriceTotal;
            energyInformation.HourArray[localedHour].TotalExVat = (double)energyPriceTotalExVat;


            var fixedPriceElement = new PriceElement
            {
                Id = fixePriceId,
                IdDaysInMonth = fixedPriceHourId
            };

            var powerPriceElement = new PriceElement();
            powerPriceElement.Id = powerPriceId;
            powerPriceElement.IdDaysInMonth = powerPriceHourId;

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
            Assert.Equal((double)energyPriceTotal, hour.EnergyPrice.Total,4);
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
            var priceLevelA = new Models.V2.Digin.EnergyPrices() { Level = "a" };
            var priceLevelB = new Models.V2.Digin.EnergyPrices() { Level = "b" };
            var priceLevelC = new Models.V2.Digin.EnergyPrices() { Level = "c" };

            var priceInfo = new Models.V2.Digin.PriceInfo() { EnergyPrices = new List<Models.V2.Digin.EnergyPrices>() };
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
        [InlineData(false, false,1)]
        [InlineData(false, true,100)]
        [InlineData(true, false,10)]
        [InlineData(true, true,10)]
        public void DecideEneryInformationTest(bool isPublicHoliday, bool isWeekend, int numExpectedElements)
        {
            Setup();
            var hourSeasonIndex = new HourSeasonIndex();
            hourSeasonIndex.EnergyInformation = new EnergyInformation()
            {
                HourArray = new Models.V2.Digin.EnergyPrices[1]
            };
            hourSeasonIndex.EnergyInformationHoliday = new EnergyInformation()
            {
                HourArray = new Models.V2.Digin.EnergyPrices[10]
            };
            hourSeasonIndex.EnergyInformationWeekend = new EnergyInformation()
            {
                HourArray = new Models.V2.Digin.EnergyPrices[100]
            };

            var retVal = _tariffQueryService.DecideEneryInformation(hourSeasonIndex, isPublicHoliday, isWeekend);
            Assert.Equal(numExpectedElements, retVal.HourArray.Length);
        }
    }
}