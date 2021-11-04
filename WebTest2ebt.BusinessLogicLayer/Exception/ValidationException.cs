using System.Runtime.Serialization;

namespace WebTest2ebt.BusinessLogicLayer.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
