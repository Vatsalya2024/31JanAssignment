using System;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.Extensions.Logging; 
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicAPI.Exceptions;

namespace ClinicAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Appointment> _repo;
        private readonly ILogger<AppointmentService> _logger;

        public AppointmentService(IRepository<int, Appointment> repo, ILogger<AppointmentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            try
            {
                appointment = await _repo.Add(appointment);
                return appointment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding an appointment");
                throw new CustomAppointmentServiceException("Error occurred while adding an appointment", ex);
            }
        }

        public Task<Appointment> AddPatient(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> DeleteAppointmentAsync(int id)
        {
            try
            {
                var appointment = await _repo.GetAsync(id);
                if (appointment != null)
                {
                    _repo.Delete(id);
                    return appointment;
                }
                else
                {
                    throw new NoSuchAppointmentException();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting appointment with id {id}");
                throw new CustomAppointmentServiceException($"Error occurred while deleting appointment with id {id}", ex);
            }
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            try
            {
                var appointment = await _repo.GetAsync(id);
                return appointment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving appointment with id {id}");
                throw new CustomAppointmentServiceException($"Error occurred while retrieving appointment with id {id}", ex);
            }
        }

        public async Task<List<Appointment>> GetAppointmentsListAsync()
        {
            try
            {
                var appointments = await _repo.GetAsync();
                return appointments;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving the list of appointments");
                throw new CustomAppointmentServiceException("Error occurred while retrieving the list of appointments", ex);
            }
        }
    }

    

    
}
