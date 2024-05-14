using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public enum TeleAppointmentStatus
    {
        Scheduled,
        Confirmed,
        Completed,
        Canceled
    }
    public class TeleAppointment : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey("TelehealthConsultation")]
        public int TelehealthConsultationId { get; set; }
        public TelehealthConsultation TelehealthConsultation { get; set; }
        public DateTime? UserChoosedTime { get; set; }
        public TeleAppointmentStatus Status { get; set; }
    }
}
