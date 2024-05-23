using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models;

namespace Vezeeta.Dtos.Dtos.AppointmentDtos
{
    public class ServiceAppointmentDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int AppointmentId { get; set; }
    }
}
