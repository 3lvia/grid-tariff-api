using GridTariffApi.Lib.Models.V2.PriceStructure;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.V2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace GridTariffApi.Lib.Tests.Services.V2
{
    public class TariffQueryServiceTests
    {
        private TariffQueryService _tariffQueryService;
        private void Setup()
        {

            _tariffQueryService = new TariffQueryService(null, null, null);

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
    }
}