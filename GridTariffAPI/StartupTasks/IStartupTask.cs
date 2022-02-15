using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.StartupTasks
{
    public interface IStartupTask
    {
        Task Execute();
    }
}
