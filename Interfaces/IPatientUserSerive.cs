using System;
using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
	public interface IPatientUserSerive
	{
        public Task<Patient> GetPatient(int id);
    }
}

