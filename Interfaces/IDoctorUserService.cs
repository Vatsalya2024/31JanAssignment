using System;
using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
	public interface IDoctorUserService
	{
		public Task<Doctor> GetDoctor(int id);
	}
}

