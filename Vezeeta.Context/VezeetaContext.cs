using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.AppointmentModels;
using Vezeeta.Models.CountryModels;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.PaymentModels;
using Vezeeta.Models.ServicesModels;
using Vezeeta.Models.SpecialtyModels;
using Vezeeta.Models.SubSpecialtiesModels;
using Vezeeta.Models.UserModels;
using Vezeeta.Models.WorkingPlacesModels;

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
        public DbSet<DoctorReviews> DoctorReviews { get; set; }
        public DbSet<ServiceReviews> ServiceReviews { get; set; }
        public DbSet<Service> Services { get; set; }
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
        public DbSet<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
        public DbSet<DoctorWorkingPlace> DoctorWorkingPlaces { get; set; }

        public VezeetaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subspecialties>()
                .HasOne(ss => ss.Specialty)
                .WithMany(s => s.Subspecialties)
                .HasForeignKey(ss => ss.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorSubSpecialties>()
                .HasOne(dss => dss.Doctor)
                .WithMany(d => d.DoctorSubSpecialties)
                .HasForeignKey(dss => dss.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DoctorSubSpecialties>()
                .HasOne(dss => dss.Subspecialties)
                .WithMany(d => d.DoctorSubSpecialties)
                .HasForeignKey(dss => dss.SubSpecialtiesId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
