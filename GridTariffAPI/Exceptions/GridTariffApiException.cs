using System;
using System.Runtime.Serialization;

namespace GridTariffApi.Exceptions
{
    [Serializable]
    public class GridTariffApiException : Exception
    {
        public GridTariffApiException()
        {
        }

        public GridTariffApiException(string message, Exception inner = null)
            : base(message, inner)
        {
        }

        protected GridTariffApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
