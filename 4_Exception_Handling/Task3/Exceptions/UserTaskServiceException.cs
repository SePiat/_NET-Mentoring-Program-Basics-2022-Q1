using System;
using System.Runtime.Serialization;

namespace Task3.Exceptions
{
    [Serializable]
    public class UserTaskServiceException : Exception
    {
        public UserTaskServiceException()
        {
        }

        public UserTaskServiceException(string message) : base(message)
        {
        }

        public UserTaskServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserTaskServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
