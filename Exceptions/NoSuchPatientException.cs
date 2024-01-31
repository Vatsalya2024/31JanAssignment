using System;
namespace ClinicAPI.Exceptions
{
	public class NoSuchPatientException:Exception
	{
        string message;
        public NoSuchPatientException()
        {
            message = "No patient with given id";
        }
        public override string Message => message;

    }
}

