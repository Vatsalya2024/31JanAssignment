using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
    }
}
