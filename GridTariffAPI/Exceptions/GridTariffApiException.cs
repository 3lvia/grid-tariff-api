using System;

namespace GridTariffApi.Exceptions
{
    public class GridTariffApiException : Exception
    {
        public GridTariffApiException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
