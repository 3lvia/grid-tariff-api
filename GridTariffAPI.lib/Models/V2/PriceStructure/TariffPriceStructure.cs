using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.V2.PriceStructure
{
    public class Company
    {
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("companyOrgNo")]
        public string CompanyOrgNo { get; set; }

        [JsonProperty("resolution")]
        public int Resolution { get; set; }
    }

    public class FixedPriceConfiguration
    {
        [JsonProperty("basis")]
        public string Basis { get; set; }

        [JsonProperty("maxhoursPerDay")]
        public int? MaxhoursPerDay { get; set; }

        [JsonProperty("daysPerMonth")]
        public int? DaysPerMonth { get; set; }

        [JsonProperty("allDaysPerMonth")]
        public bool? AllDaysPerMonth { get; set; }

        [JsonProperty("maxhoursPerMonth")]
        public int? MaxhoursPerMonth { get; set; }

        [JsonProperty("months")]
        public int? Months { get; set; }

        [JsonProperty("monthsOffset")]
        public int? MonthsOffset { get; set; }
    }

    public class FixedPriceTax
    {
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

        [JsonProperty("powerPriceTaxes")]
        public List<PowerPriceTax> PowerPriceTaxes { get; set; }

        [JsonProperty("energyPriceTaxes")]
        public List<EnergyPriceTax> EnergyPriceTaxes { get; set; }
    }

    public class PriceLevel
    {
        [JsonProperty("levelId")]
        public int LevelId { get; set; }

        [JsonProperty("levelValueMin")]
        public double? LevelValueMin { get; set; }

        [JsonProperty("levelValueMax")]
        public double? LevelValueMax { get; set; }

        [JsonProperty("nextLevelIdDown")]
        public int? NextLevelIdDown { get; set; }

        [JsonProperty("nextLevelIdUp")]
        public int? NextLevelIdUp { get; set; }

        [JsonProperty("levelValueUnitOfMeasure")]
        public string LevelValueUnitOfMeasure { get; set; }

        [JsonProperty("monthlyTotal")]
        public double MonthlyTotal { get; set; }

        [JsonProperty("monthlyTotalUnitOfMeasure")]
        public string MonthlyTotalUnitOfMeasure { get; set; }

        [JsonProperty("levelInfo")]
        public string LevelInfo { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; set; }

        [JsonProperty("levelValueUom")]
        public string LevelValueUom { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("hours")]
        public List<int> Hours { get; set; }

        [JsonProperty("monthlyActivePowerTotal")]
        public double MonthlyActivePowerTotal { get; set; }

        [JsonProperty("monthlyReactivePowerTotal")]
        public double MonthlyReactivePowerTotal { get; set; }
    }

    public class FixedPrices
    {
        [JsonProperty("priceLevel")]
        public List<PriceLevel> PriceLevel { get; set; }
    }

    public class EnergyPrice
    {
        [JsonProperty("priceLevel")]
        public List<PriceLevel> PriceLevel { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; set; }
    }

    public class PowerPrices
    {
        [JsonProperty("priceLevel")]
        public List<PriceLevel> PriceLevel { get; set; }
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

        [JsonProperty("fixedPriceConfiguration")]
        public FixedPriceConfiguration FixedPriceConfiguration { get; set; }

        [JsonProperty("tariffPrices")]
        public List<TariffPrice> TariffPrices { get; set; }

        [JsonProperty("usePublicHolidayPrices")]
        public bool? UsePublicHolidayPrices { get; set; }

        [JsonProperty("useWeekendPrices")]
        public bool? UseWeekendPrices { get; set; }

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

