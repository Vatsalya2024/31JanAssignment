using System.Runtime.Serialization;

namespace ClinicAPI.Services
{
    [Serializable]
    internal class CustomAppointmentServiceException : Exception
    {
        public CustomAppointmentServiceException()
        {
        }

        public CustomAppointmentServiceException(string? message) : base(message)
        {
        }

        public CustomAppointmentServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CustomAppointmentServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}