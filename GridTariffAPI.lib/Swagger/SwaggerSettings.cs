#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System;

namespace GridTariffApi.Lib.Swagger
{
    public class SwaggerSettings
    {
        public bool? UseSwaggerUI { get; set; }

        public string PathPrefix { get; set; }

        public string Title => "Grid Tariff API";

        public string Description => "Provides private grid tariffs. For external and internal use.";

        public string Version => "v1";

        public string RelativeUrl => string.IsNullOrEmpty(PathPrefix) ? "/" : PathPrefix;

        public void EnsureValid()
        {
            if (!UseSwaggerUI.HasValue)
            {
                throw new ArgumentNullException($"{nameof(UseSwaggerUI)} must be either true or false");
            }
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member