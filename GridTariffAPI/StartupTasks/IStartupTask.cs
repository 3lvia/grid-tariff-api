using System.Threading.Tasks;

namespace GridTariffApi.StartupTasks
{
    public interface IStartupTask
    {
        /// <summary>
        /// Indicates order of execution relattive to other IStartupTask.
        /// Lower value = higher priority
        /// </summary>
        /// <returns></returns>
        int GetExecutionOrder();

        /// <summary>
        ///Executes StartupTask
        /// </summary>
        /// <returns></returns>
        Task Execute();
    }
}
