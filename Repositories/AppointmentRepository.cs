using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly RequestTakerContext _context;
        public AppointmentRepository(RequestTakerContext context)
        {
            _context = context;
        }

        public async Task<Appointment> Add(Appointment item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Appointment> Delete(int key)
        {
            var appointment = await _context.Appointments.FindAsync(key);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            return appointment;
        }

        public async Task<Appointment> GetAsync(int key)
        {
            var appointment = await _context.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(a => a.AppointmentId == key);

            return appointment;
        }

        public async Task<List<Appointment>> GetAsync()
        {
            var appointments = await _context.Appointments
                                   .Include(p => p.Patient)
                                   .Include(d => d.Doctor)
                                   .ToListAsync();
            return appointments;
        }

        public async Task<Appointment> Update(Appointment item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
