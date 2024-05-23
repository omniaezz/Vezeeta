using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.AppointmentModels;

namespace Vezeeta.Models.ServicesModels
{
    public class ServicesAppointment : BaseEntity
    {
        [ForeignKey("Services")]
        public int ServiceId { get; set; }
        public Service Services { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
