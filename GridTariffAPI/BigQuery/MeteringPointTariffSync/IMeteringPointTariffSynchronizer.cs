using GridTariffApi.Database;
using GridTariffApi.Model;
using System;
using System.Threading.Tasks;

namespace GridTariffApi.BigQuery.MeteringPointTariffSync
{
    public interface IMeteringPointTariffSynchronizer
    {
        Task SynchronizeMeteringPointsAsync(ElviaDbContext elviaDbContext, IBigQueryReader bigQueryReader, Company elviaCompany, DateTimeOffset timeStamp);
    }
}