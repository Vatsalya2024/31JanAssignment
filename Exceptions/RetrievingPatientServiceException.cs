using System.Runtime.Serialization;

namespace ClinicAPI.Services
{
    [Serializable]
    internal class RetrievingPatientServiceException : Exception
    {
        public RetrievingPatientServiceException()
        {
        }

        public RetrievingPatientServiceException(string? message) : base(message)
        {
        }

        public RetrievingPatientServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RetrievingPatientServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}