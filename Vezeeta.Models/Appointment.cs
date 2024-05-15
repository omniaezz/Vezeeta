using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public class Appointment : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? AppointmentDurationMinutes { get; set; }
        public ICollection<UserServicesAppointment> UserServicesAppointments { get; set; }
        public ICollection<ServicesAppointment> ServicesAppointments { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }
        public ICollection<UserTeleAppointments> UserTeleAppointments { get; set; }
        public ICollection<DoctorAppointments> DoctorAppointments { get; set; }
        public ICollection<DoctorTeleAppointments> DoctorTeleAppointments { get; set; }
    }
}
