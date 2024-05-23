using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.AppointmentModels;
using Vezeeta.Models.ServicesModels;

namespace Vezeeta.Models.UserModels
{
    public class UserServicesAppointment : BaseEntity
    {
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey("Services")]
        public int ServiceId { get; set; }
        public Service Services { get; set; }

        public DateTime? UserChoosedTime { get; set; }
        public UserAppointmentStatus Status { get; set; }
    }
}
