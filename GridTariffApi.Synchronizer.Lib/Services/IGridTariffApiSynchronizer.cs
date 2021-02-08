using System.Threading.Tasks;

namespace GridTariffApi.Synchronizer.Lib.Services
{
    public interface IGridTariffApiSynchronizer
    {
        Task SynchronizeMeteringPointsAsync();
    }
}