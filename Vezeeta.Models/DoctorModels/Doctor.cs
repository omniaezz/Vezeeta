using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.CountryModels;
using Vezeeta.Models.SpecialtyModels;
using Vezeeta.Models.UserModels;

namespace Vezeeta.Models.DoctorModels
{
    public enum Gender
    {
        male,
        female,
    }
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AboutDoctor { get; set; }
        public string? DoctorImage { get; set; }
        public string PhoneNumber { get; set; }
        public string SSN { get; set; }
        public decimal Fees { get; set; }
        public int WaitingTime { get; set; }
        public int? AppointmentDurationMinutes { get; set; }
        public Gender Gender { get; set; }

        [ForeignKey("Countries")]
        public int CountryId { get; set; }
        public Countries Countries { get; set; }

        [ForeignKey("Specialty")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public ICollection<DoctorWorkingPlace> DoctorWorkingPlaces { get; set; }
        public ICollection<DoctorReviews> Reviews { get; set; }
        public ICollection<Visits> Visits { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }
        public ICollection<UserTeleAppointments> UserTeleAppointments { get; set; }
        public ICollection<DoctorAppointments> DoctorAppointments { get; set; }
        public ICollection<DoctorTeleAppointments> DoctorTeleAppointments { get; set; }
        public ICollection<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
    }
}
