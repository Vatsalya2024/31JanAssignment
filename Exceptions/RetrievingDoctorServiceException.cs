using System.Runtime.Serialization;

namespace ClinicAPI.Services
{
    [Serializable]
    internal class RetrievingDoctorServiceException : Exception
    {
        public RetrievingDoctorServiceException()
        {
        }

        public RetrievingDoctorServiceException(string? message) : base(message)
        {
        }

        public RetrievingDoctorServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RetrievingDoctorServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}