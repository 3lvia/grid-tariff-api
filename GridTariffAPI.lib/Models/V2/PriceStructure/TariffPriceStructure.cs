using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.V2.PriceStructure
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Company
    {
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("companyOrgNo")]
        public string CompanyOrgNo { get; set; }
    }

    public class FixedPriceConfiguration
    {
        [JsonProperty("basis")]
        public string Basis { get; set; }

        [JsonProperty("maxhoursPerDay")]
        public object MaxhoursPerDay { get; set; }

        [JsonProperty("daysPerMonth")]
        public object DaysPerMonth { get; set; }

        [JsonProperty("allDaysPerMonth")]
        public object AllDaysPerMonth { get; set; }

        [JsonProperty("maxhoursPerMonth")]
        public int? MaxhoursPerMonth { get; set; }

        [JsonProperty("months")]
        public int? Months { get; set; }

        [JsonProperty("monthsOffset")]
        public int? MonthsOffset { get; set; }
    }

    public class FixedPriceTax
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("taxType")]
        public string TaxType { get; set; }

        [JsonProperty("taxValue")]
        public double TaxValue { get; set; }

        [JsonProperty("taxUom")]
        public string TaxUom { get; set; }

        [JsonProperty("taxTypeDescription")]
        public string TaxTypeDescription { get; set; }
    }

    public class EnergyPriceTax
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("taxType")]
        public string TaxType { get; set; }

        [JsonProperty("taxValue")]
        public double TaxValue { get; set; }

        [JsonProperty("taxUom")]
        public string TaxUom { get; set; }

        [JsonProperty("taxTypeDescription")]
        public string TaxTypeDescription { get; set; }
    }

    public class PowerPriceTax
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("taxType")]
        public string TaxType { get; set; }

        [JsonProperty("taxValue")]
        public double TaxValue { get; set; }

        [JsonProperty("taxUom")]
        public string TaxUom { get; set; }

        [JsonProperty("taxTypeDescription")]
        public string TaxTypeDescription { get; set; }
    }

    public class Taxes
    {
        [JsonProperty("fixedPriceTaxes")]
        public List<FixedPriceTax> FixedPriceTaxes { get; set; }

        [JsonProperty("energyPriceTaxes")]
        public List<EnergyPriceTax> EnergyPriceTaxes { get; set; }

        [JsonProperty("powerPriceTaxes")]
        public List<PowerPriceTax> PowerPriceTaxes { get; set; }
    }

    public class FixedPriceLevel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("valueMin")]
        public double ValueMin { get; set; }

        [JsonProperty("valueMax")]
        public double? ValueMax { get; set; }

        [JsonProperty("nextIdDown")]
        public string NextIdDown { get; set; }

        [JsonProperty("nextIdUp")]
        public string NextIdUp { get; set; }

        [JsonProperty("valueUnitOfMeasure")]
        public string ValueUnitOfMeasure { get; set; }

        [JsonProperty("monthlyTotalExVat")]
        public double MonthlyTotalExVat { get; set; }

        [JsonProperty("monthlyUnitOfMeasure")]
        public string MonthlyUnitOfMeasure { get; set; }

        [JsonProperty("levelInfo")]
        public string LevelInfo { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; set; }
    }

    public class FixedPrices
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fixedPriceLevel")]
        public List<FixedPriceLevel> FixedPriceLevel { get; set; }
    }

    public class EnergyPriceLevel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("hours")]
        public List<int> Hours { get; set; }

        [JsonProperty("totalExVat")]
        public double? TotalExVat { get; set; }
    }

    public class EnergyPrice
    {
        [JsonProperty("energyPriceLevel")]
        public List<EnergyPriceLevel> EnergyPriceLevel { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; set; }
    }

    public class PowerPriceLevel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("valueMin")]
        public double? ValueMin { get; set; }

        [JsonProperty("valueMax")]
        public double? ValueMax { get; set; }

        [JsonProperty("nextIdDown")]
        public string NextIdDown { get; set; }

        [JsonProperty("nextIdUp")]
        public string NextIdUp { get; set; }

        [JsonProperty("valueUnitOfMeasure")]
        public string ValueUnitOfMeasure { get; set; }

        [JsonProperty("monthlyActivePowerTotalExVat")]
        public double MonthlyActivePowerTotalExVat { get; set; }

        [JsonProperty("monthlyReactivePowerTotalExVat")]
        public double MonthlyReactivePowerTotalExVat { get; set; }

        [JsonProperty("monthlyUnitOfMeasure")]
        public string MonthlyUnitOfMeasure { get; set; }

        [JsonProperty("levelInfo")]
        public string LevelInfo { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; set; }
    }

    public class PowerPrices
    {
        [JsonProperty("powerPriceLevel")]
        public List<PowerPriceLevel> PowerPriceLevel { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Season
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("months")]
        public List<int> Months { get; set; }

        [JsonProperty("fixedPrices")]
        public FixedPrices FixedPrices { get; set; }

        [JsonProperty("energyPrice")]
        public EnergyPrice EnergyPrice { get; set; }

        [JsonProperty("powerPrices")]
        public PowerPrices PowerPrices { get; set; }
    }

    public class TariffPrice
    {
        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("taxes")]
        public Taxes Taxes { get; set; }

        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }

    public class PowerPriceConfiguration
    {
        [JsonProperty("reactivePowerPricing")]
        public bool ReactivePowerPricing { get; set; }

        [JsonProperty("powerFactorPercentage")]
        public double PowerFactorPercentage { get; set; }
    }

    public class TariffType
    {
        [JsonProperty("tariffKey")]
        public string TariffKey { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("usePublicHolidayOverride")]
        public string UsePublicHolidayOverride { get; set; }

        [JsonProperty("useWeekendPriceOverride")]
        public string UseWeekendPriceOverride { get; set; }

        [JsonProperty("consumptionFlag")]
        public bool ConsumptionFlag { get; set; }

        [JsonProperty("usePowerPriceConfiguration")]
        public bool UsePowerPriceConfiguration { get; set; }

        [JsonProperty("resolution")]
        public int Resolution { get; set; }

        [JsonProperty("fixedPriceConfiguration")]
        public FixedPriceConfiguration FixedPriceConfiguration { get; set; }

        [JsonProperty("tariffPrices")]
        public List<TariffPrice> TariffPrices { get; set; }

        [JsonProperty("powerPriceConfiguration")]
        public PowerPriceConfiguration PowerPriceConfiguration { get; set; }
    }

    public class GridTariff
    {
        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("tariffTypes")]
        public List<TariffType> TariffTypes { get; set; }
    }

    public class GridTariffPriceConfiguration
    {
        [JsonProperty("gridTariff")]
        public GridTariff GridTariff { get; set; }
    }

    public class TariffPriceStructureRoot
    {
        [JsonProperty("gridTariffPriceConfiguration")]
        public GridTariffPriceConfiguration GridTariffPriceConfiguration { get; set; }
    }
}

