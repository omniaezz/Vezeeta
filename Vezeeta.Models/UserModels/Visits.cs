using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Models.UserModels
{
    public class Visits : BaseEntity
    {
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string Specialty { get; set; }
        public string Governorate { get; set; }
        public string Region { get; set; }

        [ForeignKey("user")]
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
