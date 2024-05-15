using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
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
        public decimal Fees { get; set; }
        public int WaitingTime {  get; set; } 
        public Gender Gender { get; set; }

        [ForeignKey("Countries")]
        public int CountryId { get; set; }
        public Countries Countries { get; set; }
        public ICollection<WorkingPlace> WorkingPlaces { get; set;}
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Subspecialties> Subspecialties { get; set; }
        public ICollection<Visits> Visits { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }
        public ICollection<UserTeleAppointments> UserTeleAppointments { get; set; }
        public ICollection<DoctorAppointments> DoctorAppointments { get; set; }
        public ICollection<DoctorTeleAppointments> DoctorTeleAppointments { get; set; }
    }
}
