using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAPI.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
    }
}
