using System;
using ClinicAPI.Models;
using ClinicAPI.Interfaces;
using Microsoft.Extensions.Logging; 
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicAPI.Exceptions;

namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorAdminService
    {
        private readonly IRepository<int, Doctor> _repo;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(IRepository<int, Doctor> repo, ILogger<DoctorService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            try
            {
                doctor = await _repo.Add(doctor);
                return doctor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a doctor");
                throw new RetrievingDoctorServiceException("Error occurred while adding a doctor", ex);
            }
        }

       

        public async Task<Doctor> GetDoctor(int id)
        {
            try
            {
                var doctor = await _repo.GetAsync(id);
                return doctor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving doctor with id {id}");
                throw new RetrievingDoctorServiceException($"Error occurred while retrieving doctor with id {id}", ex);
            }
        }

        public async Task<List<Doctor>> GetDoctorsListAsync()
        {
            try
            {
                var doctors = await _repo.GetAsync();
                return doctors;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving the list of doctors");
                throw new RetrievingDoctorServiceException("Error occurred while retrieving the list of doctors", ex);
            }
        }

        public async Task<Doctor> DeleteDoctorAsync(int id)
        {
            try
            {
                var doctor = await _repo.GetAsync(id);
                if (doctor != null)
                {
                    _repo.Delete(id);
                    return doctor;
                }
                else
                {
                    throw new NoSuchDoctorException();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting doctor with id {id}");
                throw new RetrievingDoctorServiceException($"Error occurred while deleting doctor with id {id}", ex);
            }
        }

        public async Task<Doctor> ChangeDoctorExpererienceAsync(int id, string experience)
        {
            try
            {
                var doctor = await _repo.GetAsync(id);
                if (doctor != null)
                {
                    doctor.Experience = experience;
                    doctor = await _repo.Update(doctor);
                    return doctor;
                }
                else
                {
                    throw new NoSuchDoctorException();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while changing doctor experience");
                throw new RetrievingDoctorServiceException("Error occurred while changing doctor experience", ex);
            }
        }
    }

   
}
