using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<ServicesAppointment> ServicesAppointments { get; set; }
        public ICollection<TeleAppointment> TeleAppointments { get; set; }
    }
}
