using System.Numerics;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientAdminService _patientAdminService;



        public PatientController(IPatientAdminService patientAdminService)
        {
            _patientAdminService = patientAdminService;
        }
        [HttpGet]
        public async Task<List<Patient>> GetPatients()
        {
            var patients = await _patientAdminService.GetPatientsListAsync();
            return patients;
        }
        [HttpPost]
        public async Task<Patient> Post(Patient patient )
        {
            patient = await _patientAdminService.AddPatient(patient);
            return patient;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> Deletepatient(int id)
        {
            var patient = await _patientAdminService.DeletePatientAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

    }
}
