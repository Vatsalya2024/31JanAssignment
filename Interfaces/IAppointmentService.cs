using System;
using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
	public interface IAppointmentService
	{
		
		
         public   Task<Appointment> GetAppointment(int id);
        public Task<List<Appointment>> GetAppointmentsListAsync();
        public Task<Appointment> AddPatient(Appointment appointment);

        public Task<Appointment> DeleteAppointmentAsync(int id);


    }
}

