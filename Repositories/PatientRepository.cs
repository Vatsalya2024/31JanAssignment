using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly RequestTakerContext _context;
        public PatientRepository(RequestTakerContext context)
        {
            _context = context;
        }
        public async Task<Patient> Add(Patient item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Patient> Delete(int key)
        {
            var patient = await GetAsync(key);
            _context?.Patients.Remove(patient);
            _context.SaveChanges();
            return patient;
        }

        public async Task<Patient> GetAsync(int key)
        {
            var patients = await GetAsync();
            var patient = patients.FirstOrDefault(p => p.PatientId == key);
            if (patient != null)
                return patient;
            throw new NoSuchPatientException();
        }

        public async Task<List<Patient>> GetAsync()
        {
            var patients = _context.Patients.ToList();
            return patients;
        }

        public async Task<Patient> Update(Patient item)
        {
            var patient = await GetAsync(item.PatientId);
            _context.Entry<Patient>(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
