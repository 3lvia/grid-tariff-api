using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.V2.PriceStructure
{
    public class Company
    {
        [JsonConstructor]
        public Company(
            [JsonProperty("companyName")] string companyName,
            [JsonProperty("companyOrgNo")] string companyOrgNo
        )
        {
            this.CompanyName = companyName;
            this.CompanyOrgNo = companyOrgNo;
        }

        [JsonProperty("companyName")]
        public string CompanyName { get; }

        [JsonProperty("companyOrgNo")]
        public string CompanyOrgNo { get; }
    }

    public class FixedPriceConfiguration
    {
        [JsonConstructor]
        public FixedPriceConfiguration(
            [JsonProperty("basis")] string basis,
            [JsonProperty("maxhoursPerDay")] int? maxhoursPerDay,
            [JsonProperty("daysPerMonth")] int? daysPerMonth,
            [JsonProperty("allDaysPerMonth")] bool? allDaysPerMonth,
            [JsonProperty("maxhoursPerMonth")] int? maxhoursPerMonth,
            [JsonProperty("months")] int? months,
            [JsonProperty("monthsOffset")] int? monthsOffset
        )
        {
            this.Basis = basis;
            this.MaxhoursPerDay = maxhoursPerDay;
            this.DaysPerMonth = daysPerMonth;
            this.AllDaysPerMonth = allDaysPerMonth;
            this.MaxhoursPerMonth = maxhoursPerMonth;
            this.Months = months;
            this.MonthsOffset = monthsOffset;
        }

        [JsonProperty("basis")]
        public string Basis { get; }

        [JsonProperty("maxhoursPerDay")]
        public int? MaxhoursPerDay { get; }

        [JsonProperty("daysPerMonth")]
        public int? DaysPerMonth { get; }

        [JsonProperty("allDaysPerMonth")]
        public bool? AllDaysPerMonth { get; }

        [JsonProperty("maxhoursPerMonth")]
        public int? MaxhoursPerMonth { get; }

        [JsonProperty("months")]
        public int? Months { get; }

        [JsonProperty("monthsOffset")]
        public int? MonthsOffset { get; }
    }

    public class FixedPriceLevel
    {
        [JsonConstructor]
#pragma warning disable S107 // Methods should not have too many parameters
        public FixedPriceLevel(
            [JsonProperty("id")] string id,
            [JsonProperty("valueMin")] double? valueMin,
            [JsonProperty("valueMax")] double? valueMax,
            [JsonProperty("nextIdDown")] string nextIdDown,
            [JsonProperty("nextIdUp")] string nextIdUp,
            [JsonProperty("valueUnitOfMeasure")] string valueUnitOfMeasure,
            [JsonProperty("monthlyFixedExTaxes")] double monthlyFixedExTaxes,
            [JsonProperty("monthlyUnitOfMeasure")] string monthlyUnitOfMeasure,
            [JsonProperty("levelInfo")] string levelInfo,
            [JsonProperty("currency")] string currency,
            [JsonProperty("monetaryUnitOfMeasure")] string monetaryUnitOfMeasure
        )
#pragma warning restore S107 // Methods should not have too many parameters

        {
            this.Id = id;
            this.ValueMin = valueMin;
            this.ValueMax = valueMax;
            this.NextIdDown = nextIdDown;
            this.NextIdUp = nextIdUp;
            this.ValueUnitOfMeasure = valueUnitOfMeasure;
            this.MonthlyFixedExTaxes = monthlyFixedExTaxes;
            this.MonthlyUnitOfMeasure = monthlyUnitOfMeasure;
            this.LevelInfo = levelInfo;
            this.Currency = currency;
            this.MonetaryUnitOfMeasure = monetaryUnitOfMeasure;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("valueMin")]
        public double? ValueMin { get; }

        [JsonProperty("valueMax")]
        public double? ValueMax { get; }

        [JsonProperty("nextIdDown")]
        public string NextIdDown { get; }

        [JsonProperty("nextIdUp")]
        public string NextIdUp { get; }

        [JsonProperty("valueUnitOfMeasure")]
        public string ValueUnitOfMeasure { get; }

        [JsonProperty("monthlyFixedExTaxes")]
        public double MonthlyFixedExTaxes { get; }

        [JsonProperty("monthlyUnitOfMeasure")]
        public string MonthlyUnitOfMeasure { get; }

        [JsonProperty("levelInfo")]
        public string LevelInfo { get; }

        [JsonProperty("currency")]
        public string Currency { get; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; }
    }

    public class FixedPrices
    {
        [JsonConstructor]
        public FixedPrices(
            [JsonProperty("id")] string id,
            [JsonProperty("fixedPriceLevel")] IReadOnlyList<FixedPriceLevel> fixedPriceLevel
        )
        {
            this.Id = id;
            this.FixedPriceLevel = fixedPriceLevel;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("fixedPriceLevel")]
        public IReadOnlyList<FixedPriceLevel> FixedPriceLevel { get; }
    }

    public class FixedPriceTax
    {
        [JsonConstructor]
        public FixedPriceTax(
            [JsonProperty("startDate")] DateTimeOffset startDate,
            [JsonProperty("endDate")] DateTimeOffset endDate,
            [JsonProperty("taxType")] string taxType,
            [JsonProperty("taxValue")] double taxValue,
            [JsonProperty("taxUom")] string taxUom,
            [JsonProperty("taxTypeDescription")] string taxTypeDescription
        )
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TaxType = taxType;
            this.TaxValue = taxValue;
            this.TaxUom = taxUom;
            this.TaxTypeDescription = taxTypeDescription;
        }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; }

        [JsonProperty("taxType")]
        public string TaxType { get; }

        [JsonProperty("taxValue")]
        public double TaxValue { get; }

        [JsonProperty("taxUom")]
        public string TaxUom { get; }

        [JsonProperty("taxTypeDescription")]
        public string TaxTypeDescription { get; }
    }

    public class EnergyPriceTax
    {
        [JsonConstructor]
        public EnergyPriceTax(
            [JsonProperty("startDate")] DateTimeOffset startDate,
            [JsonProperty("endDate")] DateTimeOffset endDate,
            [JsonProperty("taxType")] string taxType,
            [JsonProperty("taxValue")] double taxValue,
            [JsonProperty("taxUom")] string taxUom,
            [JsonProperty("taxTypeDescription")] string taxTypeDescription
        )
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TaxType = taxType;
            this.TaxValue = taxValue;
            this.TaxUom = taxUom;
            this.TaxTypeDescription = taxTypeDescription;
        }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; }

        [JsonProperty("taxType")]
        public string TaxType { get; }

        [JsonProperty("taxValue")]
        public double TaxValue { get; }

        [JsonProperty("taxUom")]
        public string TaxUom { get; }

        [JsonProperty("taxTypeDescription")]
        public string TaxTypeDescription { get; }
    }

    public class PowerPriceTax
    {
        [JsonConstructor]
        public PowerPriceTax(
            [JsonProperty("startDate")] DateTimeOffset startDate,
            [JsonProperty("endDate")] DateTimeOffset endDate,
            [JsonProperty("taxType")] string taxType,
            [JsonProperty("taxValue")] double taxValue,
            [JsonProperty("taxUom")] string taxUom,
            [JsonProperty("taxTypeDescription")] string taxTypeDescription
        )
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TaxType = taxType;
            this.TaxValue = taxValue;
            this.TaxUom = taxUom;
            this.TaxTypeDescription = taxTypeDescription;
        }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; }

        [JsonProperty("taxType")]
        public string TaxType { get; }

        [JsonProperty("taxValue")]
        public double TaxValue { get; }

        [JsonProperty("taxUom")]
        public string TaxUom { get; }

        [JsonProperty("taxTypeDescription")]
        public string TaxTypeDescription { get; }
    }

    public class Taxes
    {
        [JsonConstructor]
        public Taxes(
            [JsonProperty("fixedPriceTaxes")] IReadOnlyList<FixedPriceTax> fixedPriceTaxes,
            [JsonProperty("energyPriceTaxes")] IReadOnlyList<EnergyPriceTax> energyPriceTaxes,
            [JsonProperty("powerPriceTaxes")] IReadOnlyList<PowerPriceTax> powerPriceTaxes
        )
        {
            this.FixedPriceTaxes = fixedPriceTaxes;
            this.EnergyPriceTaxes = energyPriceTaxes;
            this.PowerPriceTaxes = powerPriceTaxes;
        }
        public Taxes()
        {

        }

        [JsonProperty("fixedPriceTaxes")]
        public IReadOnlyList<FixedPriceTax> FixedPriceTaxes { get; set; }

        [JsonProperty("energyPriceTaxes")]
        public IReadOnlyList<EnergyPriceTax> EnergyPriceTaxes { get; set; }

        [JsonProperty("powerPriceTaxes")]
        public IReadOnlyList<PowerPriceTax> PowerPriceTaxes { get; set; }
    }

    public class EnergyPriceLevel
    {
        [JsonConstructor]
        public EnergyPriceLevel(
            [JsonProperty("id")] string id,
            [JsonProperty("level")] string level,
            [JsonProperty("energyExTaxes")] double energyExTaxes,
            [JsonProperty("hours")] IReadOnlyList<int> hours
        )
        {
            this.Id = id;
            this.Level = level;
            this.EnergyExTaxes = energyExTaxes;
            this.Hours = hours;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("level")]
        public string Level { get; }

        [JsonProperty("energyExTaxes")]
        public double EnergyExTaxes { get; }

        [JsonProperty("hours")]
        public IReadOnlyList<int> Hours { get; }
    }

    public class EnergyPrice
    {
        [JsonConstructor]
        public EnergyPrice(
            [JsonProperty("energyPriceLevel")] List<EnergyPriceLevel> energyPriceLevel,
            [JsonProperty("currency")] string currency,
            [JsonProperty("monetaryUnitOfMeasure")] string monetaryUnitOfMeasure
        )
        {
            this.EnergyPriceLevel = energyPriceLevel;
            this.Currency = currency;
            this.MonetaryUnitOfMeasure = monetaryUnitOfMeasure;
        }

        [JsonProperty("energyPriceLevel")]
        public IReadOnlyList<EnergyPriceLevel> EnergyPriceLevel { get; }

        [JsonProperty("currency")]
        public string Currency { get; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; }
    }

    public class PowerPriceLevel
    {
        [JsonConstructor]
#pragma warning disable S107 // Methods should not have too many parameters
        public PowerPriceLevel(
            [JsonProperty("id")] string id,
            [JsonProperty("valueMin")] double? valueMin,
            [JsonProperty("valueMax")] double? valueMax,
            [JsonProperty("nextIdDown")] string nextIdDown,
            [JsonProperty("nextIdUp")] string nextIdUp,
            [JsonProperty("valueUnitOfMeasure")] string valueUnitOfMeasure,
            [JsonProperty("monthlyActivePowerExTaxes")] double monthlyActivePowerExTaxes,
            [JsonProperty("monthlyReactivePowerExTaxes")] double monthlyReactivePowerExTaxes,
            [JsonProperty("monthlyUnitOfMeasure")] string monthlyUnitOfMeasure,
            [JsonProperty("levelInfo")] string levelInfo,
            [JsonProperty("currency")] string currency,
            [JsonProperty("monetaryUnitOfMeasure")] string monetaryUnitOfMeasure
        )
#pragma warning restore S107 // Methods should not have too many parameters
        {
            this.Id = id;
            this.ValueMin = valueMin;
            this.ValueMax = valueMax;
            this.NextIdDown = nextIdDown;
            this.NextIdUp = nextIdUp;
            this.ValueUnitOfMeasure = valueUnitOfMeasure;
            this.MonthlyActivePowerExTaxes = monthlyActivePowerExTaxes;
            this.MonthlyReactivePowerExTaxes = monthlyReactivePowerExTaxes;
            this.MonthlyUnitOfMeasure = monthlyUnitOfMeasure;
            this.LevelInfo = levelInfo;
            this.Currency = currency;
            this.MonetaryUnitOfMeasure = monetaryUnitOfMeasure;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("valueMin")]
        public double? ValueMin { get; }

        [JsonProperty("valueMax")]
        public double? ValueMax { get; }

        [JsonProperty("nextIdDown")]
        public string NextIdDown { get; }

        [JsonProperty("nextIdUp")]
        public string NextIdUp { get; }

        [JsonProperty("valueUnitOfMeasure")]
        public string ValueUnitOfMeasure { get; }

        [JsonProperty("monthlyActivePowerExTaxes")]
        public double MonthlyActivePowerExTaxes { get; }

        [JsonProperty("monthlyReactivePowerExTaxes")]
        public double MonthlyReactivePowerExTaxes { get; }

        [JsonProperty("monthlyUnitOfMeasure")]
        public string MonthlyUnitOfMeasure { get; }

        [JsonProperty("levelInfo")]
        public string LevelInfo { get; }

        [JsonProperty("currency")]
        public string Currency { get; }

        [JsonProperty("monetaryUnitOfMeasure")]
        public string MonetaryUnitOfMeasure { get; }
    }

    public class PowerPrices
    {
        [JsonConstructor]
        public PowerPrices(
            [JsonProperty("powerPriceLevel")] List<PowerPriceLevel> powerPriceLevel,
            [JsonProperty("id")] string id
        )
        {
            this.PowerPriceLevel = powerPriceLevel;
            this.Id = id;
        }

        [JsonProperty("powerPriceLevel")]
        public IReadOnlyList<PowerPriceLevel> PowerPriceLevel { get; }

        [JsonProperty("id")]
        public string Id { get; }
    }

    public class Season
    {
        [JsonConstructor]
        public Season(
            [JsonProperty("name")] string name,
            [JsonProperty("months")] List<int> months,
            [JsonProperty("energyPrice")] EnergyPrice energyPrice,
            [JsonProperty("powerPrices")] PowerPrices powerPrices
        )
        {
            this.Name = name;
            this.Months = months;
            this.EnergyPrice = energyPrice;
            this.PowerPrices = powerPrices;
        }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("months")]
        public IReadOnlyList<int> Months { get; }

        [JsonProperty("energyPrice")]
        public EnergyPrice EnergyPrice { get; }

        [JsonProperty("powerPrices")]
        public PowerPrices PowerPrices { get; }
    }

    public class TariffPrice
    {
        [JsonConstructor]
        public TariffPrice(
            [JsonProperty("startDate")] DateTimeOffset startDate,
            [JsonProperty("endDate")] DateTimeOffset endDate,
            [JsonProperty("taxes")] Taxes taxes,
            [JsonProperty("seasons")] List<Season> seasons,
            [JsonProperty("fixedPrices")] FixedPrices fixedPrices
        )
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Taxes = taxes;
            this.Seasons = seasons;
            this.FixedPrices = fixedPrices;
        }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; }

        [JsonProperty("taxes")]
        public Taxes Taxes { get; }

        [JsonProperty("seasons")]
        public IReadOnlyList<Season> Seasons { get; }

        [JsonProperty("fixedPrices")]
        public FixedPrices FixedPrices { get; }
    }

    public class PowerPriceConfiguration
    {
        [JsonConstructor]
        public PowerPriceConfiguration(
            [JsonProperty("reactivePowerPricing")] bool reactivePowerPricing,
            [JsonProperty("powerFactorPercentage")] double powerFactorPercentage
        )
        {
            this.ReactivePowerPricing = reactivePowerPricing;
            this.PowerFactorPercentage = powerFactorPercentage;
        }

        [JsonProperty("reactivePowerPricing")]
        public bool ReactivePowerPricing { get; }

        [JsonProperty("powerFactorPercentage")]
        public double PowerFactorPercentage { get; }
    }

    public class TariffType
    {
        [JsonConstructor]
#pragma warning disable S107 // Methods should not have too many parameters
        public TariffType(
            [JsonProperty("tariffKey")] string tariffKey,
            [JsonProperty("product")] string product,
            [JsonProperty("title")] string title,
            [JsonProperty("description")] string description,
            [JsonProperty("usePublicHolidayOverride")] string usePublicHolidayOverride,
            [JsonProperty("useWeekendPriceOverride")] string useWeekendPriceOverride,
            [JsonProperty("consumptionFlag")] bool consumptionFlag,
            [JsonProperty("lastUpdated")] DateTimeOffset lastUpdated,
            [JsonProperty("usePowerPriceConfiguration")] bool usePowerPriceConfiguration,
            [JsonProperty("fixedPriceConfiguration")] FixedPriceConfiguration fixedPriceConfiguration,
            [JsonProperty("resolution")] int resolution,
            [JsonProperty("tariffPrices")] List<TariffPrice> tariffPrices,
            [JsonProperty("powerPriceConfiguration")] PowerPriceConfiguration powerPriceConfiguration
        )
#pragma warning restore S107 // Methods should not have too many parameters

        {
            this.TariffKey = tariffKey;
            this.Product = product;
            this.Title = title;
            this.Description = description;
            this.UsePublicHolidayOverride = usePublicHolidayOverride;
            this.UseWeekendPriceOverride = useWeekendPriceOverride;
            this.ConsumptionFlag = consumptionFlag;
            this.LastUpdated = lastUpdated;
            this.UsePowerPriceConfiguration = usePowerPriceConfiguration;
            this.FixedPriceConfiguration = fixedPriceConfiguration;
            this.Resolution = resolution;
            this.TariffPrices = tariffPrices;
            this.PowerPriceConfiguration = powerPriceConfiguration;
        }

        [JsonProperty("tariffKey")]
        public string TariffKey { get; }

        [JsonProperty("product")]
        public string Product { get; }

        [JsonProperty("title")]
        public string Title { get; }

        [JsonProperty("description")]
        public string Description { get; }

        [JsonProperty("usePublicHolidayOverride")]
        public string UsePublicHolidayOverride { get; }

        [JsonProperty("useWeekendPriceOverride")]
        public string UseWeekendPriceOverride { get; }

        [JsonProperty("consumptionFlag")]
        public bool ConsumptionFlag { get; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; }

        [JsonProperty("usePowerPriceConfiguration")]
        public bool UsePowerPriceConfiguration { get; }

        [JsonProperty("fixedPriceConfiguration")]
        public FixedPriceConfiguration FixedPriceConfiguration { get; }

        [JsonProperty("resolution")]
        public int Resolution { get; }

        [JsonProperty("tariffPrices")]
        public IReadOnlyList<TariffPrice> TariffPrices { get; }

        [JsonProperty("powerPriceConfiguration")]
        public PowerPriceConfiguration PowerPriceConfiguration { get; }
    }

    public class GridTariff
    {
        [JsonConstructor]
        public GridTariff(
            [JsonProperty("company")] Company company,
            [JsonProperty("tariffTypes")] List<TariffType> tariffTypes
        )
        {
            this.Company = company;
            this.TariffTypes = tariffTypes;
        }

        [JsonProperty("company")]
        public Company Company { get; }

        [JsonProperty("tariffTypes")]
        public IReadOnlyList<TariffType> TariffTypes { get; }
    }

    public class GridTariffPriceConfiguration
    {
        [JsonConstructor]
        public GridTariffPriceConfiguration(
            [JsonProperty("gridTariff")] GridTariff gridTariff
        )
        {
            this.GridTariff = gridTariff;
        }

        [JsonProperty("gridTariff")]
        public GridTariff GridTariff { get; }
    }

    public class TariffPriceStructureRoot
    {
        [JsonConstructor]
        public TariffPriceStructureRoot(
            [JsonProperty("gridTariffPriceConfiguration")] GridTariffPriceConfiguration gridTariffPriceConfiguration
        )
        {
            this.GridTariffPriceConfiguration = gridTariffPriceConfiguration;
        }

        [JsonProperty("gridTariffPriceConfiguration")]
        public GridTariffPriceConfiguration GridTariffPriceConfiguration { get; }
    }
}

