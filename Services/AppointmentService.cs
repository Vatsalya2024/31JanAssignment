using System;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;

namespace ClinicAPI.Services
{
	public class AppointmentService:IAppointmentService
	{
        private IRepository<int, Appointment> _repo;
        public AppointmentService(IRepository<int, Appointment> repo)
        {
            _repo = repo;
        }

        public async Task<Appointment> AddPatient(Appointment appointment)
        {
            appointment = await _repo.Add(appointment);
            return appointment;
        }

        public async Task<Appointment> DeleteAppointmentAsync(int id)
        {
            var appointment= await _repo.GetAsync(id);
            if (appointment != null)
            {
                _repo.Delete(id);
                return appointment;
            }
            return null;
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            var appointment = await _repo.GetAsync(id);
            return appointment;
        }

        public async Task<List<Appointment>> GetAppointmentsListAsync()
        {
            var appointments = await _repo.GetAsync();
            return appointments;
        }
    }
}

