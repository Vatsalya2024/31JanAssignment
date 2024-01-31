using System;
using System.Numerics;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;

namespace ClinicAPI.Services
{
	public class PatientServices:IPatientAdminService
	{
        private IRepository<int, Patient> _repo;
        public PatientServices(IRepository<int, Patient> repo)
        {
            _repo = repo;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            patient = await _repo.Add(patient);
            return patient;
        }

        public async Task<Patient> DeletePatientAsync(int id)
        {
            var patient = await _repo.GetAsync(id);
            if (patient != null)
            {
                _repo.Delete(id);
                return patient;
            }
            return null;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _repo.GetAsync(id);
            return patient;
        }

        public async Task<List<Patient>> GetPatientsListAsync()
        {
            var patients = await _repo.GetAsync();
            return patients;
        }
    }
}

