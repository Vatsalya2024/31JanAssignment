using System;
using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
	public interface IDoctorAdminService:IDoctorUserService
	{
		public Task<List<Doctor>> GetDoctorsListAsync();
		public Task<Doctor> AddDoctor(Doctor doctor);
		public Task<Doctor> ChangeDoctorExpererienceAsync(int id, string experience);
        public Task<Doctor> DeleteDoctorAsync(int id);

    }
}

