using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.V2.Digin
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TariffQueryRequestMeteringPointsResult
    {
        [Newtonsoft.Json.JsonProperty("gridTariffCollections", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GridTariffCollection> GridTariffCollections { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TariffQueryRequestMeteringPoints
    {
        /// <summary>A keyword for the from-to time range. Exclusive OR with startTime/endTime. Yesterday = hour 0 through hour 23 yesterday etc.</summary>
        [Newtonsoft.Json.JsonProperty("range", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"yesterday|today|tomorrow")]
        public string Range { get; set; }

        /// <summary>Start timestamp for the time range. Inclusive AND with endTime. Exclusive OR with range. Example 2021-09-17T00:00:00+02:00</summary>
        [Newtonsoft.Json.JsonProperty("startTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartTime { get; set; }

        /// <summary>End timestamp for the time range. Inclusive AND with startTime. Exclusive OR with range. Example 2021-09-18T00:00:00+02:00</summary>
        [Newtonsoft.Json.JsonProperty("endTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset EndTime { get; set; }

        /// <summary>List of meteringpoint-ids you are the registered owner of as a private person or your company has e legal reason to request in a customer/provider relationship. Example 707057500000000001</summary>
        [Newtonsoft.Json.JsonProperty("meteringPointIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> MeteringPointIds { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TariffQueryResult
    {
        [Newtonsoft.Json.JsonProperty("gridTariff", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridTariff GridTariff { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TariffTypeContainer
    {
        [Newtonsoft.Json.JsonProperty("tariffTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TariffType> TariffTypes { get; set; }


    }

    /// <summary>The response object with the grid tariff object and the meteringpointid object</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class GridTariffCollection
    {
        [Newtonsoft.Json.JsonProperty("gridTariff", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridTariff GridTariff { get; set; }

        [Newtonsoft.Json.JsonProperty("meteringPointIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> MeteringPointIds { get; set; }


    }

    /// <summary>The grid tariff object with the tariff type object and the tariff price object</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class GridTariff
    {
        [Newtonsoft.Json.JsonProperty("tariffType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TariffType TariffType { get; set; }

        [Newtonsoft.Json.JsonProperty("tariffPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TariffPrice TariffPrice { get; set; }


    }

    /// <summary>Information about the tariff type</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TariffType
    {
        /// <summary>A keyword for this grid tariff in this grid company. Ex. private_tou_daynight.</summary>
        [Newtonsoft.Json.JsonProperty("tariffKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TariffKey { get; set; }

        /// <summary>Name of the grid company product, for grid company internal use.</summary>
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }

        /// <summary>Name of the grid company. Ex. Elvia AS</summary>
        [Newtonsoft.Json.JsonProperty("companyName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        /// <summary>Organization number of the grid company. Ex. 980489698</summary>
        [Newtonsoft.Json.JsonProperty("companyOrgNo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompanyOrgNo { get; set; }

        /// <summary>Name of the grid tariff type. Ex. Nettleie under 100MWh</summary>
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>Indicates if this is a tariff for consumption or production. True = consumption</summary>
        [Newtonsoft.Json.JsonProperty("consumptionFlag", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ConsumptionFlag { get; set; }

        [Newtonsoft.Json.JsonProperty("fixedPriceConfiguration", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FixedPriceConfiguration FixedPriceConfiguration { get; set; }

        [Newtonsoft.Json.JsonProperty("powerPriceConfiguration", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PowerPriceConfiguration PowerPriceConfiguration { get; set; }

        [Newtonsoft.Json.JsonProperty("resolution", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Resolution { get; set; }

        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }


    }

    /// <summary>Parameters to visualize how the fixed price component is calculated. Ex. if months &gt; 1, then the average of the maxhoursPerMonth for x months is the basis for the fixed price etc. Weighting is not supported in this version.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class FixedPriceConfiguration
    {
        /// <summary>Description of fixed price basis. Values: monthlymax|dailymax|fusesize|fixed.</summary>
        [Newtonsoft.Json.JsonProperty("basis", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"monthlymax|dailymax|fusesize|fixed")]
        public string Basis { get; set; }

        /// <summary>Only for dailymax tariff. Number of hours per day. Null if not dailymax tariff. Ex. value is 1 if 1 hour per day is used as basis</summary>
        [Newtonsoft.Json.JsonProperty("maxhoursPerDay", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MaxhoursPerDay { get; set; }

        /// <summary>Only for dailymax tariff. Number of days per month. Null if not dailymax tariff or if allDaysPerMonth is true. Ex. value is 1 if 1 day per month is used as basis</summary>
        [Newtonsoft.Json.JsonProperty("daysPerMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DaysPerMonth { get; set; }

        /// <summary>Only for dailymax tariff. Flag to indicate if a dailymax tariff uses all days per month as basis. Null if not dailymax tariff. Ex. True = all days per month is used. False = not all days per month are used. If false, then daysPerMonth must not be null.</summary>
        [Newtonsoft.Json.JsonProperty("allDaysPerMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AllDaysPerMonth { get; set; }

        /// <summary>Only for monthlymax tariff. Number of hours per month. Null if not monthlymax tariff.</summary>
        [Newtonsoft.Json.JsonProperty("maxhoursPerMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MaxhoursPerMonth { get; set; }

        /// <summary>For dailymax and monthlymax tariffs. Number of months maxhours are measured(averaged). Null if not dailymax or monthlymax tariff.</summary>
        [Newtonsoft.Json.JsonProperty("months", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Months { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>Parameters to visualize how the fixed price component is calculated. Ex. if months &gt; 1, then the average of the maxhoursPerMonth for x months is the basis for the fixed price etc. Weighting is not supported in this version.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PowerPriceConfiguration
    {
        /// <summary>True = reactive power prices applies and powerFactor indicates triggering point. False = reactive power prices does not apply.</summary>
        [Newtonsoft.Json.JsonProperty("reactivePowerPricing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ReactivePowerPricing { get; set; }

        /// <summary>This factor is used to trigger invoicing of reactive power. Ex. a power factor of 0.9 equals a power factor percentage of 50, meaning invoicing starts when reactive power is more than 50% of active power. Pricing applies to exceeding value above 50%</summary>
        [Newtonsoft.Json.JsonProperty("powerFactorPercentage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PowerFactorPercentage { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The tariff price object with the prices</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TariffPrice
    {
        [Newtonsoft.Json.JsonProperty("priceInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PriceInfo> PriceInfo { get; set; }


    }

    /// <summary>The price object with the price details</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PriceInfo
    {
        /// <summary>The start time of this resolution period. Ex. 2021-09-17T00:00:00.000Z</summary>
        [Newtonsoft.Json.JsonProperty("startTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartTime { get; set; }

        /// <summary>The time when this resolution period is expired. Ex. 2021-09-17T01:00:00.000Z</summary>
        [Newtonsoft.Json.JsonProperty("expiredAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ExpiredAt { get; set; }

        /// <summary>Short name for this resolution period. Ex. 00-01</summary>
        [Newtonsoft.Json.JsonProperty("hoursShortName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HoursShortName { get; set; }

        /// <summary>Season name for this resolution period. summer/winter</summary>
        [Newtonsoft.Json.JsonProperty("season", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"summer|winter")]
        public string Season { get; set; }

        /// <summary>Indicate if this is a public holiday true=public holiday</summary>
        [Newtonsoft.Json.JsonProperty("publicHoliday", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool PublicHoliday { get; set; }

        /// <summary>Object with list of fixed prices</summary>
        [Newtonsoft.Json.JsonProperty("fixedPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<FixedPrices> FixedPrices { get; set; }

        /// <summary>Object with variable prices</summary>
        [Newtonsoft.Json.JsonProperty("variablePrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public VariablePrices VariablePrices { get; set; }


    }

    /// <summary>Fixed prices object containing priceLevel list and currentPriceLevel(if applicable)</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class FixedPrices
    {
        [Newtonsoft.Json.JsonProperty("priceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PriceLevel> PriceLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("currentPriceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurrentPriceLevel CurrentPriceLevel { get; set; }


    }

    /// <summary>The fixed prices and attributes for this price level for the resolution period. Ex. hour 00-01</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PriceLevel
    {
        /// <summary>Fixed price component level id/number. Ex. 1</summary>
        [Newtonsoft.Json.JsonProperty("levelId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LevelId { get; set; }

        /// <summary>Minimum value the level is based on. Included on this level for monthlymax and dailymax models(Ex. 0.0000 kWh/h). Included for fusesize based(Ex. 50 A). Null if this is the lowest level.</summary>
        [Newtonsoft.Json.JsonProperty("levelValueMin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double LevelValueMin { get; set; }

        /// <summary>Maximum value the level is based on. Excluded on this level for monthlymax and dailymax models(Ex. 2.0000 kWh/h which is the next level start value). Included for fusesize based(Ex. 50 A). Null if this is the highest level.</summary>
        [Newtonsoft.Json.JsonProperty("levelValueMax", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double LevelValueMax { get; set; }

        /// <summary>Level id of the level below the current. Ex. 1</summary>
        [Newtonsoft.Json.JsonProperty("nextLevelIdDown", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NextLevelIdDown { get; set; }

        /// <summary>Level id of the level above the current. Ex. 3</summary>
        [Newtonsoft.Json.JsonProperty("nextLevelIdUp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NextLevelIdUp { get; set; }

        /// <summary>Unit of measure for the levelValueMin and Max. Ex. kWh/h</summary>
        [Newtonsoft.Json.JsonProperty("levelValueUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelValueUnitOfMeasure { get; set; }

        /// <summary>Total monthly fixed price for this level. Ex 170.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyTotal { get; set; }

        /// <summary>Unit of measure for the monthlyTotal fixed price. Ex. kr/month</summary>
        [Newtonsoft.Json.JsonProperty("monthlyTotalUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyTotalUnitOfMeasure { get; set; }

        /// <summary>Information about this fixed price level. Ex. Power consumption: 8-12 kWh/h</summary>
        [Newtonsoft.Json.JsonProperty("levelInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelInfo { get; set; }

        /// <summary>Total price for this resolution period. Ex. 0.2361</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Total { get; set; }

        /// <summary>Price excluded taxes for this resolution period. Ex. 0.1889</summary>
        [Newtonsoft.Json.JsonProperty("fixedExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double FixedExTaxes { get; set; }

        /// <summary>Taxes for this resolution period. Ex. 0.0472</summary>
        [Newtonsoft.Json.JsonProperty("taxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Taxes { get; set; }

        /// <summary>The currency for all monetary units of measures. Ex. NOK</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>Unit of measure for the total, fixedExTaxes and taxes prices. Ex. kr/hour</summary>
        [Newtonsoft.Json.JsonProperty("monetaryUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonetaryUnitOfMeasure { get; set; }


    }

    /// <summary>The last known fixed price level the MPID is placed in based on fuse size or max hour measurement</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CurrentPriceLevel
    {
        /// <summary>Fixed price component level id/number. Ex. 2</summary>
        [Newtonsoft.Json.JsonProperty("currentLevelId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CurrentLevelId { get; set; }

        /// <summary>The value of the fuse size or max hour measurement. Ex. 3.456 (kWh/h). Not in use for v0_8 as this is information that needs a higher level of authentication and/or authorization to expose</summary>
        [Newtonsoft.Json.JsonProperty("currentLevelValue", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double CurrentLevelValue { get; set; }


    }

    /// <summary>Variable prices object containing energyPrice and powerPrice(if applicable)</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class VariablePrices
    {
        [Newtonsoft.Json.JsonProperty("energyPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public EnergyPrice EnergyPrice { get; set; }

        [Newtonsoft.Json.JsonProperty("powerPriceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PowerPrice> PowerPriceLevel { get; set; }


    }

    /// <summary>Energy price object containing properties for energy price(ex. total can be multiplied by consumption in this resolution period to get cost of energy price)</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EnergyPrice
    {
        /// <summary>Total price of energy component for this resolution period. Ex. 0.2585</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Total { get; set; }

        /// <summary>Price of energy component excluded taxes for this resolution period. Ex. 0.0299</summary>
        [Newtonsoft.Json.JsonProperty("energyExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double EnergyExTaxes { get; set; }

        /// <summary>Taxes for the energy component for this resolution period. Ex. 0.2286</summary>
        [Newtonsoft.Json.JsonProperty("taxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Taxes { get; set; }

        /// <summary>Short name for the price level for this resolution period. Ex. CHEAP</summary>
        [Newtonsoft.Json.JsonProperty("level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"VERY_CHEAP|CHEAP|NORMAL|EXPENSIVE|VERY_EXPENSIVE")]
        public string Level { get; set; }

        /// <summary>Currency. Ex. NOK</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>Unit of measure for the energy prices. Ex. kr/kWh</summary>
        [Newtonsoft.Json.JsonProperty("monetaryUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonetaryUnitOfMeasure { get; set; }


    }

    /// <summary>Power price object containing properties for power price(ex. total can be multiplied by the month maximum hour(Ex. 10 kWh/h) to get the power component cost)</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PowerPrice
    {
        /// <summary>Power price component level id/number. Ex. 1</summary>
        [Newtonsoft.Json.JsonProperty("levelId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LevelId { get; set; }

        /// <summary>Minimum value the level is based on. Null if only one level or this is the lowest level. Ex. 0 (kW)</summary>
        [Newtonsoft.Json.JsonProperty("levelValueMin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double LevelValueMin { get; set; }

        /// <summary>Maximum value the level is based on. Null if only one level or this is the highest level. Ex. 100 (kW)</summary>
        [Newtonsoft.Json.JsonProperty("levelValueMax", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double LevelValueMax { get; set; }

        /// <summary>Level id of the level below the current. Null if this is the lowest level. Ex. 1</summary>
        [Newtonsoft.Json.JsonProperty("nextLevelIdDown", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NextLevelIdDown { get; set; }

        /// <summary>Level id of the level above the current. Null if this is the highest level. Ex. 3</summary>
        [Newtonsoft.Json.JsonProperty("nextLevelIdUp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NextLevelIdUp { get; set; }

        /// <summary>Unit of measure for the levelValueMin and Max. Ex. kW</summary>
        [Newtonsoft.Json.JsonProperty("levelValueUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelValueUnitOfMeasure { get; set; }

        /// <summary>Total monthly active power price. To be multiplied with the number of kW (specifically kWh/h) on the maximum hour of the month. Ex. 27.500</summary>
        [Newtonsoft.Json.JsonProperty("monthlyActivePowerTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyActivePowerTotal { get; set; }

        /// <summary>Total monthly reactive power price. To be multiplied with the number of kW (specifically kWh/h) on the maximum hour of the month. Ex. 27.500</summary>
        [Newtonsoft.Json.JsonProperty("monthlyReactivePowerTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyReactivePowerTotal { get; set; }

        /// <summary>Unit of measure for total monthly power price. Ex. kr/kW/month (specifically kr/kWh/h/month).</summary>
        [Newtonsoft.Json.JsonProperty("monthlyTotalUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyTotalUnitOfMeasure { get; set; }

        /// <summary>Information about this power price level. Ex. 0-100 kW</summary>
        [Newtonsoft.Json.JsonProperty("levelInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelInfo { get; set; }

        /// <summary>Total price of active power component for this resolution period. Total is calculated by ex. (monthly active power price)/(no of days this month)/24 hours. Ex. 0.0381</summary>
        [Newtonsoft.Json.JsonProperty("activeTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ActiveTotal { get; set; }

        /// <summary>Price of active power component for this resolution period excluded taxes. Ex. 0.102</summary>
        [Newtonsoft.Json.JsonProperty("activePowerExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ActivePowerExTaxes { get; set; }

        /// <summary>Taxes for the active power component for this resolution period. Ex. 0.100</summary>
        [Newtonsoft.Json.JsonProperty("activeTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ActiveTaxes { get; set; }

        /// <summary>Total price of reactive power component for this resolution period. Total is calculated by ex. (monthly reactive power price)/(no of days this month)/24 hours. Ex. 0.0184</summary>
        [Newtonsoft.Json.JsonProperty("reactiveTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ReactiveTotal { get; set; }

        /// <summary>Price of reactive power component for this resolution period excluded taxes. Ex. 0.102</summary>
        [Newtonsoft.Json.JsonProperty("reactivePowerExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ReactivePowerExTaxes { get; set; }

        /// <summary>Taxes for the reactive power component for this resolution period. Ex. 0.100</summary>
        [Newtonsoft.Json.JsonProperty("reactiveTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ReactiveTaxes { get; set; }

        /// <summary>Currency. Ex. NOK</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>Unit of measure for the power prices. Ex. kr/kW</summary>
        [Newtonsoft.Json.JsonProperty("monetaryUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonetaryUnitOfMeasure { get; set; }


    }
}
