using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using ClinicAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorAdminService _doctorAdminService;


        
        public DoctorController(IDoctorAdminService doctorAdminService)
        {
            _doctorAdminService = doctorAdminService;
        }
        [HttpGet]
        public async Task<List<Doctor>> GetDoctors()
        {
            var doctors = await _doctorAdminService.GetDoctorsListAsync();
            return doctors;
        }
        [HttpPost]
        public async Task<Doctor>Post(Doctor doctor)
        {
            doctor = await _doctorAdminService.AddDoctor(doctor);
            return doctor;
        }
        [Route("[controller]/ChangeExperience")]
        [HttpPut]
        public async Task<Doctor> UpdateExperience(DoctorExperienceDTO doctorExpereieceDTO)
        {
            var doctor = await _doctorAdminService.ChangeDoctorExpererienceAsync(doctorExpereieceDTO.Id, doctorExpereieceDTO.Experience);
            return doctor;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            var doctor = await _doctorAdminService.DeleteDoctorAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }
    }
}
