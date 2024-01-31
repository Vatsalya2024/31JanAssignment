using System;
namespace ClinicAPI.Exceptions
{
	public class NoSuchDoctorException:Exception
	{
		string message;
		public NoSuchDoctorException()
		{
			message = "No doctor with given id";
		}
        public override string Message => message;
    }
}

