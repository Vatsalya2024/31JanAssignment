using System;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.Extensions.Logging; 
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicAPI.Exceptions; 

namespace ClinicAPI.Services
{
    public class PatientServices : IPatientAdminService
    {
        private readonly IRepository<int, Patient> _repo;
        private readonly ILogger<PatientServices> _logger;

        public PatientServices(IRepository<int, Patient> repo, ILogger<PatientServices> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            try
            {
                patient = await _repo.Add(patient);
                return patient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a patient");
                throw new RetrievingPatientServiceException("Error occurred while adding a patient", ex);
            }
        }

        public async Task<Patient> DeletePatientAsync(int id)
        {
            try
            {
                var patient = await _repo.GetAsync(id);
                if (patient != null)
                {
                    _repo.Delete(id);
                    return patient;
                }
                else
                {
                    throw new NoSuchPatientException();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting patient with id {id}");
                throw new RetrievingPatientServiceException($"Error occurred while deleting patient with id {id}", ex);
            }
        }

        public async Task<Patient> GetPatient(int id)
        {
            try
            {
                var patient = await _repo.GetAsync(id);
                return patient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving patient with id {id}");
                throw new RetrievingPatientServiceException($"Error occurred while retrieving patient with id {id}", ex);
            }
        }

        public async Task<List<Patient>> GetPatientsListAsync()
        {
            try
            {
                var patients = await _repo.GetAsync();
                return patients;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving the list of patients");
                throw new RetrievingPatientServiceException("Error occurred while retrieving the list of patients", ex);
            }
        }
    }

   
}
