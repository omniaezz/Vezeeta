using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.UserModels;

namespace Vezeeta.Models.ServicesModels
{
    public class Service : BaseEntity
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int DiscountValue { get; set; }
        public decimal DiscountedPrice => ServicePrice - ServicePrice * DiscountValue / 100;
        public string ServicePlaceName { get; set; }
        public string ServicePlaceAddress { get; set; }
        public string ServicePlaceImage { get; set; }
        public ICollection<ServicesImages> ServicesImages { get; set; }
        public ICollection<ServiceReviews> ServiceReviews { get; set; }
        public ICollection<UserServicesAppointment> UserServicesAppointments { get; set; }
        public ICollection<ServicesAppointment> ServicesAppointments { get; set; }
    }
}
