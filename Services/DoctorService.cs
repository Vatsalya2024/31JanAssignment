using System;
using ClinicAPI.Models;
using ClinicAPI.Interfaces;

namespace ClinicAPI.Services
{
	public class DoctorService:IDoctorAdminService
	{
		private IRepository<int, Doctor> _repo;
		public DoctorService(IRepository<int,Doctor> repo)
		{
			_repo = repo;
		}

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            doctor = await _repo.Add(doctor);
            return doctor;
        }

        public async Task<Doctor> ChangeDoctorExpererienceAsync(int id, string experience)
        {
            var doctor = await _repo.GetAsync(id);
            if (doctor != null)
            {
                doctor.Experience = experience;
                doctor = await _repo.Update(doctor);
                return doctor;
            }
            return null;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doctor = await _repo.GetAsync(id);
            return doctor;
        }

        public async Task<List<Doctor>> GetDoctorsListAsync()
        {
            var doctors = await _repo.GetAsync();
            return doctors;
        }
        public async Task<Doctor> DeleteDoctorAsync(int id)
        {
            var doctor = await _repo.GetAsync(id);
            if (doctor != null)
            {
                _repo.Delete(id);
                return doctor;
            }
            return null;
        }
    }
}

