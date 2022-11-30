using System.Runtime.Serialization;

namespace OuvICEx.API.Domain.Exceptions
{
    [Serializable]
    public class PublicationNotFoundException : Exception
    {
        protected PublicationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public PublicationNotFoundException(string message) : base(message) { }
    }
}
