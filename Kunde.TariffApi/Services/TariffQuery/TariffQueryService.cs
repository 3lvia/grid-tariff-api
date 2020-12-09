using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models.TariffQuery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kunde.TariffApi.Services.TariffQuery
{
    public class TariffQueryService : ITariffQueryService
    {
        private readonly TariffContext _tariffContext;

        private readonly int _fixedPriceUnitOfMeasureId = 4;
        private static string _lowTariffHours = "0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23";

        public TariffQueryService(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public TariffQueryResult QueryTariff(string tariffKey, DateTime paramFromDate, DateTime paramToDate)
        {
            DateTime dbQueryFromDate = paramFromDate.Date;
            DateTime dbQueryToDate = paramToDate.Date.AddDays(1).AddMinutes(-1);

            String fixedPriceUnitOfMeasure = _tariffContext.Uom.Where(u => u.Id == _fixedPriceUnitOfMeasureId).FirstOrDefault().Unit;
            Tarifftype tariffType = _tariffContext.Tarifftype.Where(t => t.Tariffkey.Equals(tariffKey)).Include(t => t.Company).FirstOrDefault();
            Dictionary<DateTime, String> publicHolidays = _tariffContext.Publicholiday.Where(
                p => p.Holidaydate >= dbQueryFromDate
                && p.Holidaydate <= dbQueryToDate)
                .ToDictionary(p => p.Holidaydate, p => p.Description);

            TariffQueryResult tariffQueryResult = InitTariffQueryResult(tariffType);
            tariffQueryResult = ProcessTimePeriodÅerDay(paramFromDate, paramToDate, tariffType.Id, fixedPriceUnitOfMeasure, publicHolidays, tariffQueryResult);
            return tariffQueryResult;
        }

        private TariffQueryResult ProcessTimePeriodÅerDay(DateTime paramFromDate, 
            DateTime paramToDate, 
            int tariffTypeId,
            string fixedPriceUnitOfMeasure,
            Dictionary<DateTime, String> publicHolidays,
            TariffQueryResult tariffQueryResult)
        {
            int currMonth = -1;
            Dictionary<int, Fixedpriceconfig> currFixedPrices = null;
            Dictionary<int, Variablepriceconfig> currVariablePrices = null;
            List<FixedPrices> currentFixedPrices = null;
            String currSeason = String.Empty;

            while (paramFromDate <= paramToDate)
            {
                DateTime queryToDate = GetNextToDate(paramFromDate, paramToDate);
                bool isPublicHoliday = publicHolidays.ContainsKey(paramFromDate.Date);

                if (currMonth != paramFromDate.Month)   //new month, find appropiate tariffs/season, calculate fixed tariffs
                {
                    currFixedPrices = GetFixedPricesForGivenMonth(paramFromDate, queryToDate, tariffTypeId);
                    currVariablePrices = GetVariablePricesForGivenMonth(paramFromDate, queryToDate, tariffTypeId);
                    currentFixedPrices = CalculateFixedPricesForGivenMonth(ref currFixedPrices, paramFromDate.Year, paramFromDate.Month, fixedPriceUnitOfMeasure);
                    currSeason = currFixedPrices.First().Value.Season.Season1;
                    currMonth = paramFromDate.Month;
                }
                tariffQueryResult.GridTariff.TariffPrice.PriceInfo.AddRange(
                    ProcessDay(paramFromDate,
                        queryToDate,
                        isPublicHoliday,
                        ref currentFixedPrices,
                        ref currVariablePrices,
                        currSeason));

                paramFromDate = paramFromDate.AddDays(1).Date;
            }
            return tariffQueryResult;
        }

        private static TariffQueryResult InitTariffQueryResult(Tarifftype tariffType)
        {
            return new TariffQueryResult()
            {
                GridTariff = new GridTariff
                {
                    TariffType = new Models.TariffQuery.TariffType()
                    {
                        Company = tariffType.Company.CompanyName,
                        CustomerType = tariffType.Customertype,
                        Title = tariffType.Title,
                        Resolution = tariffType.Resolution,
                        Description = tariffType.Description,
                    },
                    TariffPrice = new TariffPrice()
                    {
                        PriceInfo = new List<PriceInfo>()
                    }
                }
            };
        }

        private static DateTime GetNextToDate(DateTime queryFromDate, DateTime paramToDate )
        {
            if (queryFromDate.Date == paramToDate.Date)     //last day to process, limit to hhmmdd as in request
            {
                return paramToDate;
            }
            return queryFromDate.Date.AddDays(1).AddMinutes(-1); //not last day to process, process to end of day
        }

        private Dictionary<int, Variablepriceconfig> GetVariablePricesForGivenMonth(DateTime queryFromDate, DateTime queryToDate, int tariffTypeId)
        {
            return _tariffContext.Variablepriceconfig.Where(v => v.Tarifftypeid == tariffTypeId
                && v.Monthno == queryFromDate.Month
                && v.Pricefromdate.Date <= queryToDate.Date
                && v.Pricetodate.Date >= queryFromDate.Date)
                .Include(v => v.Uom)
                .Include(v => v.Pricelevel)
                .ToDictionary(v => v.Id, v => v);
        }

        private Dictionary<int, Fixedpriceconfig> GetFixedPricesForGivenMonth(DateTime queryFromDate, DateTime queryToDate, int tariffTypeId)
        {
            return _tariffContext.Fixedpriceconfig.Where(f => f.Tarifftypeid == tariffTypeId
                && f.Monthno == queryFromDate.Month
                && f.Pricefromdate.Date <= queryToDate.Date
                && f.Pricetodate.Date >= queryFromDate.Date)
                .Include(f => f.Pricelevel)
                .Include(f => f.Uom)
                .Include(f => f.Season)
                .ToDictionary(f => f.Id, f => f);
        }

        private List<PriceInfo> ProcessDay(DateTime fromTime,
            DateTime toTime,
            bool isPublicHoliday,
            ref List<FixedPrices> fixedPrices,
            ref Dictionary<int, Variablepriceconfig> variablePrices,
            String season)
        {
            var priceInfos = new List<PriceInfo>();
            Dictionary<int, VariablePrice> calculatedVariablePrices = null;

            int fromHour = fromTime.Hour;
            int toHour = toTime.Hour;
            bool isLowTariff = isPublicHoliday || fromTime.DayOfWeek == DayOfWeek.Saturday || fromTime.DayOfWeek == DayOfWeek.Sunday;

            calculatedVariablePrices = CalcVariablePricesDay(ref variablePrices, fromHour, toHour, isLowTariff);

            fromTime = fromTime.Date;
            while (fromHour <= toHour)
            {
                var priceInfo = new PriceInfo()
                {
                    StartTime = fromTime.AddHours(fromHour),
                    ExpiredAt = fromTime.AddHours(fromHour + 1),
                    HoursShortName = $"{fromHour.ToString().PadLeft(2, '0')}-{(fromHour + 1).ToString().PadLeft(2, '0')}",
                    Season = season,
                    PublicHoliday = isPublicHoliday
                };
                priceInfo.FixedPrices = fixedPrices;
                priceInfo.VariablePrice = calculatedVariablePrices[fromHour];
                priceInfos.Add(priceInfo);
                fromHour++;
            }
            return priceInfos;
        }

        private Dictionary<int, VariablePrice> CalcVariablePricesDay(ref Dictionary<int, Variablepriceconfig> variablePrices, int fromHour, int toHour, bool isLowTariff)
        {
            if (isLowTariff)
            {
                var calculatedVariablePrices = new Dictionary<int, VariablePrice>();
                IEnumerable<int> configHours = from hour in _lowTariffHours.Split(';') select int.Parse(hour);

                Variablepriceconfig lowTariffVariablePriceConfig = variablePrices.OrderBy(v => v.Value.Pricelevel.Sortorder).FirstOrDefault().Value;
                CalcVariablePricesDay(fromHour, toHour, ref calculatedVariablePrices, lowTariffVariablePriceConfig, configHours);
                return calculatedVariablePrices;
            }
            return CalcVariablePricesDay(fromHour, toHour, ref variablePrices);
        }

        Dictionary<int, VariablePrice> CalcVariablePricesDay(int fromHour, int toHour, ref Dictionary<int, Variablepriceconfig> variablepriceconfigs)
        {
            Dictionary<int, VariablePrice> variablePrices = new Dictionary<int, VariablePrice>();
            foreach (Variablepriceconfig variablePriceConfig in variablepriceconfigs.Values)
            {
                IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);
                CalcVariablePricesDay(fromHour, toHour, ref variablePrices, variablePriceConfig, configHours);
            }
            return variablePrices;
        }

        private void CalcVariablePricesDay(int fromHour, int toHour, ref Dictionary<int, VariablePrice> variablePrices, Variablepriceconfig variablePriceConfig, IEnumerable<int> configHours)
        {
            IEnumerable<int> matchedHours = configHours.Where(h => fromHour <= h && h <= toHour);
            foreach (int matchedHour in matchedHours)
            {
                variablePrices.Add(matchedHour,
                new VariablePrice()
                {
                    Total = variablePriceConfig.Total,
                    Energy = variablePriceConfig.Energy,
                    Power = variablePriceConfig.Power,
                    Taxes = variablePriceConfig.Taxmva + variablePriceConfig.Taxenova + variablePriceConfig.Taxenergy,
                    Level = variablePriceConfig.Pricelevel.PricelevelDescription,
                    Currency = variablePriceConfig.Uom.Currency,
                    Uom = variablePriceConfig.Uom.Unit
                });
            }
        }

        private List<FixedPrices> CalculateFixedPricesForGivenMonth(ref Dictionary<int, Fixedpriceconfig> fixedpriceconfigs, int year, int month, string unitOfMeasure)
        {
            const int hoursInDay = 24;
            var fixedPrices = new List<FixedPrices>();
            int daysInMonth = DateTime.DaysInMonth(year, month);

            foreach (Fixedpriceconfig fixedPriceConfig in fixedpriceconfigs.Values)
            {
                var fixedPriceConfigContainer = new FixedPrices() { PriceLevel = new List<PriceLevel>() };
                var priceLevel = new PriceLevel()
                {
                    Level = fixedPriceConfig.Pricelevel.Pricelevel,
                    LevelInfo = fixedPriceConfig.Pricelevel.Levelinfo,
                    Taxes = Decimal.Round((fixedPriceConfig.Taxes / (daysInMonth * hoursInDay)), 4),
                    Fixed = Decimal.Round((fixedPriceConfig.Fixed / (daysInMonth * hoursInDay)), 4),
                    Currency = fixedPriceConfig.Uom.Currency,
                    Uom = unitOfMeasure
                };
                priceLevel.Total = priceLevel.Taxes + priceLevel.Fixed;
                fixedPriceConfigContainer.PriceLevel.Add(priceLevel);
                fixedPrices.Add(fixedPriceConfigContainer);
            }
            return fixedPrices;
        }
    }
}
