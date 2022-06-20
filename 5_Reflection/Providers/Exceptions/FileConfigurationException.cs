using System;
using System.Runtime.Serialization;

namespace Reflection.Exceptions
{
    [Serializable]
    public class FileConfigurationException : Exception
    {
        public FileConfigurationException()
        {
        }

        public FileConfigurationException(string message) : base(message)
        {
        }

        public FileConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}