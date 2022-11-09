using System.Runtime.Serialization;

namespace OuvICEx.API.Domain.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public BadRequestException(string message) : base(message) { }
    }
}
