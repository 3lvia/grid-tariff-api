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
            var tariffQueryResult = new TariffQueryResult();
            DateTime queryFromDate = paramFromDate.Date;
            DateTime queryToDate = paramToDate.Date.AddDays(1).AddMinutes(-1);

            Tarifftype tariffType = _tariffContext.Tarifftype.Where(t => t.Tariffkey.Equals(tariffKey)).Include(t => t.Company).FirstOrDefault();
            UnitofMeasure fixedPriceUnitOfMeasure = _tariffContext.Uom.Where(u => u.Id == _fixedPriceUnitOfMeasureId).FirstOrDefault();
            Dictionary<DateTime, String> publicHolidays = _tariffContext.Publicholiday.Where(
                p => p.Holidaydate >= queryFromDate
                && p.Holidaydate <= queryToDate)
                .ToDictionary(p => p.Holidaydate, p => p.Description);

            InitResultObject(tariffQueryResult, tariffType);

            IDictionary<int, Fixedpriceconfig> currFixedPrices = null;
            IDictionary<int, Variablepriceconfig> currVariablePrices = null;
            Season currSeason = null;
            int currMonth = -1;
            queryFromDate = paramFromDate;
            List<FixedPrices> currentFixedPrices = null;
            while (queryFromDate <= paramToDate)
            {
                queryToDate = GetNextToDate(queryFromDate, paramToDate);

                if (currMonth != queryFromDate.Month)   //new month, find appropiate tariffs/season, calculate fixed tariffs
                {
                    currFixedPrices = GetFixedPricesForGivenMonth(queryFromDate, queryToDate, tariffType);
                    currVariablePrices = GetVariablePricesForGivenMonth(queryFromDate, queryToDate, tariffType);
                    currentFixedPrices = CalculateFixedPrices(ref currFixedPrices, queryFromDate.Year, queryFromDate.Month, fixedPriceUnitOfMeasure);
                    currSeason = currFixedPrices.First().Value.Season;
                    currMonth = queryFromDate.Month;
                }
                tariffQueryResult.GridTariff.TariffPrice.PriceInfo.AddRange(
                    ProcessDay(queryFromDate,
                        queryToDate,
                        ref publicHolidays,
                        ref currentFixedPrices,
                        ref currVariablePrices,
                        ref currSeason));
                queryFromDate = queryFromDate.AddDays(1).Date;
            }
            return tariffQueryResult;
        }

        private static void InitResultObject(TariffQueryResult tariffQueryResult, Tarifftype tariffType)
        {
            tariffQueryResult.GridTariff = new GridTariff
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

        private IDictionary<int, Variablepriceconfig> GetVariablePricesForGivenMonth(DateTime queryFromDate, DateTime queryToDate, Tarifftype tariffType)
        {
            return _tariffContext.Variablepriceconfig.Where(v => v.Tarifftypeid == tariffType.Id
                && v.Monthno == queryFromDate.Month
                && v.Pricefromdate.Date <= queryToDate.Date
                && v.Pricetodate.Date >= queryFromDate.Date)
                .Include(v => v.Uom)
                .Include(v => v.Pricelevel)
                .ToDictionary(v => v.Id, v => v);
        }

        private IDictionary<int, Fixedpriceconfig> GetFixedPricesForGivenMonth(DateTime queryFromDate, DateTime queryToDate, Tarifftype tariffType)
        {
            return _tariffContext.Fixedpriceconfig.Where(f => f.Tarifftypeid == tariffType.Id
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
            ref Dictionary<DateTime, String> publicHolidays,
            ref List<FixedPrices> fixedPrices,
            ref IDictionary<int, Variablepriceconfig> variablePrices,
            ref Season season)
        {
            var priceInfos = new List<PriceInfo>();
            IDictionary<int, VariablePrice> calculatedVariablePrices = null;

            int fromHour = fromTime.Hour;
            int toHour = toTime.Hour;
            bool isPublicHoliday = publicHolidays.ContainsKey(fromTime.Date);
            bool isLowTariff = isPublicHoliday || fromTime.DayOfWeek == DayOfWeek.Saturday || fromTime.DayOfWeek == DayOfWeek.Sunday;

            if (isLowTariff)
            {
                Variablepriceconfig lowTariffVariablePriceConfig = null;
                foreach (Variablepriceconfig variablepriceconfig in variablePrices.Values)
                {
                    if (lowTariffVariablePriceConfig == null || variablepriceconfig.Pricelevel.Sortorder < lowTariffVariablePriceConfig.Pricelevel.Sortorder)
                    {
                        lowTariffVariablePriceConfig = variablepriceconfig;
                    }
                }
                calculatedVariablePrices = new Dictionary<int, VariablePrice>();
                IEnumerable<int> configHours = from hour in _lowTariffHours.Split(';') select int.Parse(hour);
                CalcVariablePricesDay(fromHour, toHour, ref calculatedVariablePrices, lowTariffVariablePriceConfig, configHours);
            }
            else
            {
                calculatedVariablePrices = CalcVariablePricesDay(fromHour, toHour, ref variablePrices);
            }

            fromTime = fromTime.Date;
            while (fromHour <= toHour)
            {
                var priceInfo = new PriceInfo()
                {
                    StartTime = fromTime.AddHours(fromHour),
                    ExpiredAt = fromTime.AddHours(fromHour + 1),
                    HoursShortName = $"{fromHour.ToString().PadLeft(2, '0')}-{(fromHour + 1).ToString().PadLeft(2, '0')}",
                    Season = season.Season1,
                    PublicHoliday = isPublicHoliday
                };
                priceInfo.FixedPrices = fixedPrices;
                priceInfo.VariablePrice = calculatedVariablePrices[fromHour];
                priceInfos.Add(priceInfo);
                fromHour++;
            }
            return priceInfos;
        }

        IDictionary<int, VariablePrice> CalcVariablePricesDay(int fromHour, int toHour, ref IDictionary<int, Variablepriceconfig> variablepriceconfigs)
        {
            IDictionary<int, VariablePrice> variablePrices = new Dictionary<int, VariablePrice>();
            foreach (Variablepriceconfig variablePriceConfig in variablepriceconfigs.Values)
            {
                IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);
                CalcVariablePricesDay(fromHour, toHour, ref variablePrices, variablePriceConfig, configHours);
            }
            return variablePrices;
        }

        private void CalcVariablePricesDay(int fromHour, int toHour, ref IDictionary<int, VariablePrice> variablePrices, Variablepriceconfig variablePriceConfig, IEnumerable<int> configHours)
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

        private List<FixedPrices> CalculateFixedPrices(ref IDictionary<int, Fixedpriceconfig> fixedpriceconfigs, int year, int month, UnitofMeasure unitOfMeasure)
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
                    Uom = unitOfMeasure.Unit
                };
                priceLevel.Total = priceLevel.Taxes + priceLevel.Fixed;
                fixedPriceConfigContainer.PriceLevel.Add(priceLevel);
                fixedPrices.Add(fixedPriceConfigContainer);
            }
            return fixedPrices;
        }
    }
}
