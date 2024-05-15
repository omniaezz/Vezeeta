using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models;

namespace Vezeeta.Context
{
    public class VezeetaContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicImages> ClinicImages { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<CountriesImages> CountriesImages { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ServicesImages> ServicesImages { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Subspecialties> Subspecialties { get; set; }
        public DbSet<WorkingPlace> WorkingPlaces { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public DbSet<DoctorAppointments> DoctorAppointments { get; set; }
        public DbSet<DoctorTeleAppointments> DoctorTeleAppointments { get; set; }
        public DbSet<UserAppointment> UserAppointments { get; set; }
        public DbSet<UserTeleAppointments> UserTeleAppointments { get; set; }
        public DbSet<ServicesAppointment> ServicesAppointments { get; set; }

        public VezeetaContext(DbContextOptions options) : base(options) { }

       
    }
}
