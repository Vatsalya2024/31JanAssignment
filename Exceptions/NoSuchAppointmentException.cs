using System;
namespace ClinicAPI.Exceptions
{
    public class NoSuchAppointmentException : Exception
    {
        public NoSuchAppointmentException() : base("No appointment with the given id")
        {
        }
    }
}

