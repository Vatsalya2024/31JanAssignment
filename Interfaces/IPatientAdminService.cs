using System;
using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
	public interface IPatientAdminService:IPatientUserSerive
	{
        public Task<List<Patient>> GetPatientsListAsync();
        public Task<Patient> AddPatient(Patient patient);
        
        public Task<Patient> DeletePatientAsync(int id);

    }
}

