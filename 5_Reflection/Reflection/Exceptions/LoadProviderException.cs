using System;
using System.Runtime.Serialization;

namespace Reflection.Exceptions
{
    [Serializable]
    public class LoadProviderException : Exception
    {
        public LoadProviderException()
        {
        }

        public LoadProviderException(string message) : base(message)
        {
        }

        public LoadProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LoadProviderException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
