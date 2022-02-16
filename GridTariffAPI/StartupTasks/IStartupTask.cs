using System.Threading.Tasks;

namespace GridTariffApi.StartupTasks
{
    public interface IStartupTask
    {
        Task Execute();

        int GetExecutionPriority();
    }
}
