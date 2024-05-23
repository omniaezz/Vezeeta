using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.PaymentModels;
using Vezeeta.Models.ServicesModels;

namespace Vezeeta.Models.UserModels
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<DoctorReviews> DoctorReviews { get; set; }
        public ICollection<ServiceReviews> ServiceReviews { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<UserServicesAppointment> UserServicesAppointments { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }
        public ICollection<UserTeleAppointments> UserTeleAppointments { get; set; }
    }
}
