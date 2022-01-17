﻿using System;
using System.Threading.Tasks;
using GridTariffApi.Lib.Interfaces;

namespace GridTariffApi.Metrics
{
    public interface IElviaLoggingDataCollector : ILoggingDataCollector
    {
        // Elvia specific logging fields
        public double? MdmxElapsedSeconds { get; }
        public Task<T> MeasureMdmxElapsedTimeAsync<T>(Func<Task<T>> mdmxAction);
    }
}
