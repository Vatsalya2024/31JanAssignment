using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class RequestTakerContext : DbContext
    {
        public RequestTakerContext(DbContextOptions options):base(options)
        {
                
        }
        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }

}