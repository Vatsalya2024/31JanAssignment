using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly RequestTakerContext _context;
        public DoctorRepository(RequestTakerContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await GetAsync(key);
            _context?.Doctors.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public async Task<Doctor> GetAsync(int key)
        {
            var doctors = await GetAsync();
            var doctor = doctors.FirstOrDefault(d => d.Id == key);
            if (doctor != null)
                return doctor;
            throw new NoSuchDoctorException();
        }

        public async Task<List<Doctor>> GetAsync()
        {
            var doctors = _context.Doctors.ToList();
            return doctors;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await GetAsync(item.Id);
            _context.Entry<Doctor>(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
