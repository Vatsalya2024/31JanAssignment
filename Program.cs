using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using ClinicAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RequestTakerContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("requestTrackerConnection"));
            });

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
            builder.Services.AddScoped<IRepository<int, Patient>, PatientRepository>();
            builder.Services.AddScoped<IRepository<int, Appointment>, AppointmentRepository>();
            builder.Services.AddScoped<IDoctorAdminService, DoctorService>();
            builder.Services.AddScoped<IDoctorUserService, DoctorService>();
            builder.Services.AddScoped<IPatientAdminService, PatientServices>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
