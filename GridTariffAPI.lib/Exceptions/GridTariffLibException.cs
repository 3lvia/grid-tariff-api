using System;
using System.Runtime.Serialization;

namespace GridTariffApi.Lib.Exceptions
{
    [Serializable]
    public class GridTariffLibException : Exception
    {
        public GridTariffLibException()
        {
        }

        public GridTariffLibException(string message, Exception inner = null)
            : base(message, inner)
        {
        }

        protected GridTariffLibException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}