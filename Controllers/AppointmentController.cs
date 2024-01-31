using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;



        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<List<Appointment>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointmentsListAsync();
            return appointments;
        }
        [HttpPost]
        public async Task<Appointment> Post(Appointment appointment)
        {
            appointment = await _appointmentService.AddPatient(appointment);
            return appointment;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.DeleteAppointmentAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }
    }
}
