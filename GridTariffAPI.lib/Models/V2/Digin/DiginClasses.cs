using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public System.DateTimeOffset? StartTime { get; set; }

        /// <summary>End timestamp for the time range. Inclusive AND with startTime. Exclusive OR with range. Example 2021-09-18T00:00:00+02:00</summary>
        [Newtonsoft.Json.JsonProperty("endTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? EndTime { get; set; }

        /// <summary>List of meteringpoint-ids you are the registered owner of as a private person or your company has e legal reason to request in a customer/provider relationship. Example 707057500000000001</summary>
        [Newtonsoft.Json.JsonProperty("meteringPointIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> MeteringPointIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool hasRange = !String.IsNullOrEmpty(Range);
            bool hasStart = StartTime.HasValue;
            bool hasEnd = EndTime.HasValue;
            if (!hasRange && !(hasStart || hasEnd))
            {
                yield return new ValidationResult(
                              $"Neither range nor StartTime/Endtime specified",
                              new[] { nameof(Range), nameof(StartTime), nameof(EndTime) });
            }
            if (hasRange)
            {
                if (hasStart || hasEnd)
                {
                    yield return new ValidationResult(
                      $"Both range and StartTime/Endtime specified",
                      new[] { nameof(Range), nameof(StartTime), nameof(EndTime) });
                }
            }
            else
            {
                if (!hasStart)
                {
                    yield return new ValidationResult(
                      $"StartTime Not specified",
                      new[] { nameof(StartTime) });
                }
                if (!hasEnd)
                {
                    yield return new ValidationResult(
                      $"Endtime Not specified",
                      new[] { nameof(EndTime) });

                }
                if (StartTime > EndTime)
                {
                    yield return new ValidationResult(
                      $"StartTime greather than EndTime",
                      new[] { nameof(StartTime), nameof(EndTime) });
                }
            }
            if (MeteringPointIds == null)
            {
                yield return new ValidationResult(
                  $"No meteringpoints in request");
            }
        }
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

        [Newtonsoft.Json.JsonProperty("meteringPointsAndPriceLevels", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<MeteringPointsAndPriceLevels> MeteringPointsAndPriceLevels { get; set; }


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

        /// <summary>The time of when the prices were last updated on the server side. No need to get prices if you already fetched the latest ones? Ex. 2021-11-05T00:00:00+01:00</summary>
        [Newtonsoft.Json.JsonProperty("lastUpdated", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset LastUpdated { get; set; }

        /// <summary>True if the grid tariff use the lowest prices during public holidays.</summary>
        [Newtonsoft.Json.JsonProperty("usePublicHolidayPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UsePublicHolidayPrices { get; set; }

        /// <summary>True if the grid tariff use the lowest prices during public weekends(Saturday and/or Sunday)</summary>
        [Newtonsoft.Json.JsonProperty("useWeekendPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseWeekendPrices { get; set; }

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

        /// <summary>Only for dailymax tariff. Flag to indicate if a dailymax tariff uses all days per month as basis. True = all days per month is used. False = not all days per month are used or basis != dailymax. If false, then daysPerMonth must not be null.</summary>
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

        /// <summary>The power factor is used to trigger invoicing of reactive power. Ex. a power factor of 0.9 equals a power factor percentage of 50, meaning invoicing starts when reactive power is more than 50% of active power. Pricing applies to exceeding value above 50%. Ex. 50.0000</summary>
        [Newtonsoft.Json.JsonProperty("powerFactorPercentage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double PowerFactorPercentage { get; set; }

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
        [Newtonsoft.Json.JsonProperty("hours", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<Hours> Hours { get; set; }

        [Newtonsoft.Json.JsonProperty("priceInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PriceInfo PriceInfo { get; set; }


    }

    /// <summary>The time series with prices per resolution period.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Hours
    {
        /// <summary>The start time of this resolution period. Ex. 2021-09-17T00:00:00+02:00</summary>
        [Newtonsoft.Json.JsonProperty("startTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartTime { get; set; }

        /// <summary>The time when this resolution period is expired. Ex. 2021-09-17T01:00:00+02:00</summary>
        [Newtonsoft.Json.JsonProperty("expiredAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ExpiredAt { get; set; }

        /// <summary>Short name for this resolution period. Ex. 0000-0100</summary>
        [Newtonsoft.Json.JsonProperty("shortName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ShortName { get; set; }

        /// <summary>Indicate if this is a public holiday true=public holiday</summary>
        [Newtonsoft.Json.JsonProperty("isPublicHoliday", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsPublicHoliday { get; set; }

        /// <summary>Object with id references to fixed prices</summary>
        [Newtonsoft.Json.JsonProperty("fixedPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FixedPrice FixedPrice { get; set; }

        /// <summary>Object with id references to power prices</summary>
        [Newtonsoft.Json.JsonProperty("powerPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PowerPrice PowerPrice { get; set; }

        /// <summary>Object with id references to energy prices and the hourly energy price included taxes</summary>
        [Newtonsoft.Json.JsonProperty("energyPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public EnergyPrice EnergyPrice { get; set; }


    }

    /// <summary>The price object with the price details</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PriceInfo
    {
        /// <summary>Object with list of fixed prices</summary>
        [Newtonsoft.Json.JsonProperty("fixedPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<FixedPrices> FixedPrices { get; set; }

        /// <summary>Object with list of power prices</summary>
        [Newtonsoft.Json.JsonProperty("powerPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<PowerPrices> PowerPrices { get; set; }

        /// <summary>Object with list of energy prices</summary>
        [Newtonsoft.Json.JsonProperty("energyPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<EnergyPrices> EnergyPrices { get; set; }


    }

    /// <summary>Fixed prices object containing priceLevel list</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class FixedPrices
    {
        /// <summary>Unique id for this fixed price (decided by the start and end time of the price). Ex. 216783ff-5dda-4c38-b491-d6f0fcee9a9b</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Start date for when this fixed price is valid from, limited to the latest of either the fixed price start date or the request startTime date. Ex. 2021-01-01</summary>
        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartDate { get; set; }

        /// <summary>End date is when this fixed price has expired, limited to the earliest of either the fixed price end date or the request endTime date. Ex. 2021-12-31</summary>
        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty("priceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<FixedPriceLevel> PriceLevel { get; set; }


    }

    /// <summary>The fixed prices and attributes for this price level for the resolution period. Ex. hour 00-01</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class FixedPriceLevel
    {
        /// <summary>Unique fixed price component level id. Ex. edcf53ce-70d3-4fa0-8bfb-e79918335ab7</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Minimum value the level is based on. Included on this level for monthlymax and dailymax models(Ex. 0.0000 kWh/h). Included for fusesize based(Ex. 50 A). Null if this is the lowest level.</summary>
        [Newtonsoft.Json.JsonProperty("valueMin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ValueMin { get; set; }

        /// <summary>Maximum value the level is based on. Excluded on this level for monthlymax and dailymax models(Ex. 2.0000 kWh/h which is the next level start value). Included for fusesize based(Ex. 50 A). Null if this is the highest level.</summary>
        [Newtonsoft.Json.JsonProperty("valueMax", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ValueMax { get; set; }

        /// <summary>Level id of the level below the current. Ex. null if this is the lowest level</summary>
        [Newtonsoft.Json.JsonProperty("nextIdDown", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NextIdDown { get; set; }

        /// <summary>Level id of the level above the current. Ex. a920b2af-a43f-4de4-aa86-33ea874bdbc4</summary>
        [Newtonsoft.Json.JsonProperty("nextIdUp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NextIdUp { get; set; }

        /// <summary>Unit of measure for the valueMin and Max. Ex. kWh/h</summary>
        [Newtonsoft.Json.JsonProperty("valueUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ValueUnitOfMeasure { get; set; }

        /// <summary>Total monthly fixed price for this level included taxes. Ex 100.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyTotal { get; set; }

        /// <summary>Monthly fixed price including all taxes except VAT. Ex 80.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyTotalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyTotalExVat { get; set; }

        /// <summary>Monthly fixed price exluded all taxes. Ex 80.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyExTaxes { get; set; }

        /// <summary>Monthly total for all taxes including VAT for fixed price. Ex 20.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyTaxes { get; set; }

        /// <summary>Unit of measure for the monthlyTotal fixed price. Ex. kr/month</summary>
        [Newtonsoft.Json.JsonProperty("monthlyUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonthlyUnitOfMeasure { get; set; }

        /// <summary>List of hourly prices for months with 31,30,29 and 28 days for this fixed price level.</summary>
        [Newtonsoft.Json.JsonProperty("hourPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HourFixedPrices> HourPrices { get; set; }

        /// <summary>Information about this fixed price level. Ex. Power consumption: 8-12 kWh/h</summary>
        [Newtonsoft.Json.JsonProperty("levelInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelInfo { get; set; }

        /// <summary>The currency for all monetary units of measures. Ex. NOK</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>Unit of measure for the hourPrices. Ex. kr/hour</summary>
        [Newtonsoft.Json.JsonProperty("monetaryUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonetaryUnitOfMeasure { get; set; }


    }

    /// <summary>Price per hour for fixed prices, with a unique id</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class HourFixedPrices
    {
        /// <summary>Unique id. Ex. 884d57a8-c8ac-462c-a04e-7554f3fc9c7a</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>The number of days the total fixed price is divided by to find the hourly price. Valid values: 31|30|29|28. Ex. 30</summary>
        [Newtonsoft.Json.JsonProperty("numberOfDaysInMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumberOfDaysInMonth { get; set; }

        /// <summary>Total price of fixed component for this resolution period included taxes. Calculated by monthlyTotal/(number of days in the month)/24 hours. Ex. 0.1388</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Total { get; set; }

        /// <summary>Total price of fixed component for this resolution period included all taxes except VAT. Calculated by monthlyTotalExVat/(number of days in the month)/24 hours. Ex. 0.1388</summary>
        [Newtonsoft.Json.JsonProperty("totalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TotalExVat { get; set; }


    }

    /// <summary>Power price object containing properties for power price.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PowerPrices
    {
        /// <summary>Unique id for this power price (decided by the start and end time of the price). Ex. f122e3e7-3e0c-43ca-a3ce-051ec0339b98</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Start date for when this power price is valid from, limited to the latest of either the power price start date or the request startTime date. Ex. 2021-01-01</summary>
        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartDate { get; set; }

        /// <summary>End date is when this power price has expired, limited to the earliest of either the power price end date or the request endTime date. Ex. 2021-12-31</summary>
        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty("priceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PowerPriceLevel> PriceLevel { get; set; }


    }

    /// <summary>The fixed prices and attributes for this price level for the resolution period. Ex. hour 00-01</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PowerPriceLevel
    {
        /// <summary>Unique fixed price component level id. Ex. edcf53ce-70d3-4fa0-8bfb-e79918335ab7</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Minimum value the level is based on. Included on this level for monthlymax and dailymax models(Ex. 0.0000 kWh/h). Included for fusesize based(Ex. 50 A). Null if this is the lowest level.</summary>
        [Newtonsoft.Json.JsonProperty("valueMin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ValueMin { get; set; }

        /// <summary>Maximum value the level is based on. Excluded on this level for monthlymax and dailymax models(Ex. 2.0000 kWh/h which is the next level start value). Included for fusesize based(Ex. 50 A). Null if this is the highest level.</summary>
        [Newtonsoft.Json.JsonProperty("valueMax", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ValueMax { get; set; }

        /// <summary>Level id of the level below the current. Ex. null if this is the lowest level</summary>
        [Newtonsoft.Json.JsonProperty("nextIdDown", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NextIdDown { get; set; }

        /// <summary>Level id of the level above the current. Ex. a920b2af-a43f-4de4-aa86-33ea874bdbc4</summary>
        [Newtonsoft.Json.JsonProperty("nextIdUp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NextIdUp { get; set; }

        /// <summary>Unit of measure for the valueMin and Max. Ex. kWh/h</summary>
        [Newtonsoft.Json.JsonProperty("valueUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ValueUnitOfMeasure { get; set; }

        /// <summary>Total monthly active power price. To be multiplied with the number of kW (specifically kWh/h) on the maximum hour of the month. Ex. 27.500</summary>
        [Newtonsoft.Json.JsonProperty("monthlyActivePowerTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyActivePowerTotal { get; set; }

        /// <summary>Monthly active power price including all taxes except VAT. Ex 80.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyActivePowerTotalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyActivePowerTotalExVat { get; set; }

        /// <summary>Monthly active power price excluded taxes. To be multiplied with the number of kW (specifically kWh/h) on the maximum hour of the month. Ex. 22.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyActivePowerExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyActivePowerExTaxes { get; set; }

        /// <summary>Monthly active power taxes. To be multiplied with the number of kW (specifically kWh/h) on the maximum hour of the month. Ex. 5.5000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyActivePowerTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyActivePowerTaxes { get; set; }

        /// <summary>Total monthly reactive power price. May be multiplied with the number of kW (specifically kWh/h) which exceeds the powerFactorPercentage on the maximum hour of the month. Ex. 13.2625</summary>
        [Newtonsoft.Json.JsonProperty("monthlyReactivePowerTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyReactivePowerTotal { get; set; }

        /// <summary>Monthly reactive power price including all taxes except VAT. Ex 80.0000</summary>
        [Newtonsoft.Json.JsonProperty("monthlyReactivePowerTotalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyReactivePowerTotalExVat { get; set; }

        /// <summary>Monthly reactive power price excluded taxes. May be multiplied with the number of kW (specifically kWh/h) which exceeds the powerFactorPercentage on the maximum hour of the month. Ex. 10.6100</summary>
        [Newtonsoft.Json.JsonProperty("monthlyReactivePowerExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyReactivePowerExTaxes { get; set; }

        /// <summary>Monthly reactive power taxes. May be multiplied with the number of kW (specifically kWh/h) which exceeds the powerFactorPercentage on the maximum hour of the month. ONLY USED FOR POWER PRICE. Ex. 2.6525</summary>
        [Newtonsoft.Json.JsonProperty("monthlyReactivePowerTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MonthlyReactivePowerTaxes { get; set; }

        /// <summary>Unit of measure for the monthlyTotal power price. Ex. kr/month</summary>
        [Newtonsoft.Json.JsonProperty("monthlyUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonthlyUnitOfMeasure { get; set; }

        /// <summary>List of hourly prices for months with 31,30,29 and 28 days for this power price level.</summary>
        [Newtonsoft.Json.JsonProperty("hourPrices", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HourPowerPrices> HourPrices { get; set; }

        /// <summary>Information about this fixed price level. Ex. Power consumption: 8-12 kWh/h</summary>
        [Newtonsoft.Json.JsonProperty("levelInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelInfo { get; set; }

        /// <summary>The currency for all monetary units of measures. Ex. NOK</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>Unit of measure for the hourPrices. Ex. kr/hour</summary>
        [Newtonsoft.Json.JsonProperty("monetaryUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonetaryUnitOfMeasure { get; set; }


    }

    /// <summary>Price per hour for power prices, with a unique id</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class HourPowerPrices
    {
        /// <summary>Unique id. Ex. 884d57a8-c8ac-462c-a04e-7554f3fc9c7a</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>The number of days the total power price is divided by to find the hourly price. Valid values: 31|30|29|28. Ex. 30</summary>
        [Newtonsoft.Json.JsonProperty("numberOfDaysInMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumberOfDaysInMonth { get; set; }

        /// <summary>Total price of active power for the power component for this resolution period included taxes. Calculated by monthlyActivePowerTotal/(number of days in the month)/24 hours. Ex. 0.0381</summary>
        [Newtonsoft.Json.JsonProperty("activeTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ActiveTotal { get; set; }

        /// <summary>Total price of active power for the power component for this resolution period included all taxes except VAT. Calculated by monthlyActivePowerTotalExVat/(number of days in the month)/24 hours. Ex. 0.0381</summary>
        [Newtonsoft.Json.JsonProperty("activeTotalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ActiveTotalExVat { get; set; }

        /// <summary>Total price of reactive power for the power component for this resolution period included taxes. Calculated by monthlyReactivePowerTotal/(number of days in the month)/24 hours. Ex. 0.0184</summary>
        [Newtonsoft.Json.JsonProperty("reactiveTotal", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ReactiveTotal { get; set; }

        /// <summary>Total price of reactive power for the power component for this resolution period included all taxes except VAT. Calculated by monthlyReactivePowerTotalExVat/(number of days in the month)/24 hours. Ex. 0.0184</summary>
        [Newtonsoft.Json.JsonProperty("reactiveTotalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ReactiveTotalExVat { get; set; }


    }

    /// <summary>Energy price object containing properties for energy price. The total can be multiplied by consumption in this resolution period to get cost of energy price</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EnergyPrices
    {
        /// <summary>Unique id for this energy price (decided by the start and end time of the price). Ex. ba446e00-24be-4850-b212-fdc9f20cfef0</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Start date for when this energy price is valid from, limited to the latest of either the energy price start date or the request startTime date. Ex. 2021-01-01</summary>
        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartDate { get; set; }

        /// <summary>End date is when this energy price has expired, limited to the earliest of either the energy price end date or the request endTime date. Ex. 2021-12-31</summary>
        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset EndDate { get; set; }

        /// <summary>Season for this resolution period. Ex. summer</summary>
        [Newtonsoft.Json.JsonProperty("season", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"summer|winter|year")]
        public string Season { get; set; }

        /// <summary>Short name for the price level for this resolution period. Ex. CHEAP</summary>
        [Newtonsoft.Json.JsonProperty("level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"VERY_CHEAP|CHEAP|NORMAL|EXPENSIVE|VERY_EXPENSIVE")]
        public string Level { get; set; }

        /// <summary>Total price of energy component for this resolution period. Ex. 0.2585</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Total { get; set; }

        /// <summary>Total price of energy component for this resolution period included all taxes except VAT. Ex. 0.2068</summary>
        [Newtonsoft.Json.JsonProperty("totalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TotalExVat { get; set; }

        /// <summary>Price of energy component excluded taxes for this resolution period. Ex. 0.0299</summary>
        [Newtonsoft.Json.JsonProperty("energyExTaxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double EnergyExTaxes { get; set; }

        /// <summary>Taxes for the energy component for this resolution period. Ex. 0.2286</summary>
        [Newtonsoft.Json.JsonProperty("taxes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Taxes { get; set; }

        /// <summary>Currency. Ex. NOK</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>Unit of measure for the energy prices. Ex. kr/kWh</summary>
        [Newtonsoft.Json.JsonProperty("monetaryUnitOfMeasure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonetaryUnitOfMeasure { get; set; }


    }

    /// <summary>The response object with the grid tariff object and the meteringpointid object</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MeteringPointsAndPriceLevels
    {
        [Newtonsoft.Json.JsonProperty("currentFixedPriceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurrentFixedPriceLevel CurrentFixedPriceLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("meteringPointIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MeteringPointIds MeteringPointIds { get; set; }


    }

    /// <summary>The last known fixed price level the MPID is placed in based on fuse size or max hour measurement</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CurrentFixedPriceLevel
    {
        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.fixedPrices.id. Ex. 216783ff-5dda-4c38-b491-d6f0fcee9a9b</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.fixedPrices.priceLevel.id. Ex. edcf53ce-70d3-4fa0-8bfb-e79918335ab7</summary>
        [Newtonsoft.Json.JsonProperty("levelId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LevelId { get; set; }

        /// <summary>Value of the max hour setting the level of fixedprice. NOT IN USE YET AS IT REQUIRES A HIGHER LEVEL OF AUTHENTICATION AND AUTHORIZATION. Ex. 9.0000</summary>
        [Newtonsoft.Json.JsonProperty("levelValue", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? LevelValue { get; set; }

        /// <summary>Time of when the last metervalues were received from the meters to calculate basis for the fixed level. Ex. 2021-09-17T02:00:00+02:00</summary>
        [Newtonsoft.Json.JsonProperty("lastUpdated", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset LastUpdated { get; set; }


    }

    /// <summary>List of meteringpoint-ids that has this tariff type at the time of the api call. Ex. 707057500000000002</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MeteringPointIds : System.Collections.ObjectModel.Collection<string>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class FixedPrice
    {
        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.fixedPrices.id. Ex. 216783ff-5dda-4c38-b491-d6f0fcee9a9b</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.fixedPrices.priceLevel.hourPrices.id Ex. a4afa37ae2ec41048e2b5153c35af1c5</summary>
        [Newtonsoft.Json.JsonProperty("hourId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HourId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PowerPrice
    {
        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.powerPrices.id. Ex. f122e3e7-3e0c-43ca-a3ce-051ec0339b98</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.powerPrices.priceLevel.hourPrices.id Ex. 27134fc2-514d-479e-aedb-f13fc4f087d1</summary>
        [Newtonsoft.Json.JsonProperty("hourId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HourId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EnergyPrice
    {
        /// <summary>Unique id referencing gridTariffCollections.gridTariff.tariffPrice.priceInfo.energyPrices.id. Ex. 0852242b-90a9-4f71-9903-e881d55194f9</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>Total price of energy component for this resolution period. This is for easier access to the hourly energy price. Ex. 0.2850</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Total { get; set; }

        /// <summary>Total price of energy component for this resolution period included all taxes except VAT. This is for easier access to the hourly energy price. Ex. 0.2280</summary>
        [Newtonsoft.Json.JsonProperty("totalExVat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TotalExVat { get; set; }
    }

    public class TariffQueryRequest : IValidatableObject
    {
        /// <summary>
        /// TariffKey dictates which tariff will be queried
        /// </summary>
        /// <example>standard</example>

        [StringLength(100)]
        public String TariffKey { get; set; }

        /// <summary>
        /// Internal product code or name to be used internally at the grid company. Exclusive OR with TariffKey
        /// </summary>
        /// <example>HN ELHA avr</example>

        [StringLength(100)]
        public String Product { get; set; }


        /// <summary>
        /// Mutual exclusive with startTime/EndTime.  Valid values: yesterday,today,tomorrow. 
        /// </summary>
        /// <example>tomorrow</example>
        [StringLength(10)]
        [RegularExpression("yesterday|today|tomorrow", ErrorMessage = "Valid values is 'yesterday','today','tomorrow'")]
        public String Range { get; set; }

        /// <summary>
        /// Mutual exclusive with Range. Used together with EndTime. Sample value: 2020-11-09T00:00:00.000Z
        /// </summary>
        /// <example>2020-11-09T00:00:00.000Z</example>
        [DataType(DataType.DateTime)]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Mutual exclusive with Range. Used together with StartTime. Sample value: 2020-12-31T00:00:00.000Z
        /// </summary>
        /// <example>2020-12-31T00:00:00.000Z</example>
        [DataType(DataType.DateTime)]
        public DateTimeOffset? EndTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool hasRange = !String.IsNullOrEmpty(Range);
            bool hasStart = StartTime.HasValue;
            bool hasEnd = EndTime.HasValue;
            if (!hasRange && !(hasStart || hasEnd))
            {
                yield return new ValidationResult(
                              $"Neither range nor StartTime/Endtime specified",
                              new[] { nameof(Range), nameof(StartTime), nameof(EndTime) });
            }
            if (hasRange)
            {
                if (hasStart || hasEnd)
                {
                    yield return new ValidationResult(
                      $"Both range and StartTime/Endtime specified",
                      new[] { nameof(Range), nameof(StartTime), nameof(EndTime) });
                }
            }
            else
            {
                if (!hasStart)
                {
                    yield return new ValidationResult(
                      $"StartTime Not specified",
                      new[] { nameof(StartTime) });
                }
                if (!hasEnd)
                {
                    yield return new ValidationResult(
                      $"Endtime Not specified",
                      new[] { nameof(EndTime) });

                }
                if (StartTime > EndTime)
                {
                    yield return new ValidationResult(
                      $"StartTime greather than EndTime",
                      new[] { nameof(StartTime), nameof(EndTime) });
                }
            }
        }
    }

}
