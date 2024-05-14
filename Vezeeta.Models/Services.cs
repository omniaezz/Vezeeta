using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public class Services : BaseEntity
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int DiscountValue { get; set; }
        public decimal DiscountedPrice => ServicePrice - (ServicePrice * DiscountValue / 100);
        public string ServicePlaceName { get; set; }
        public string ServicePlaceAddress { get; set; }
        public string ServicePlaceImage { get; set; }
        public ICollection<ServicesImages> ServicesImages { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<ServicesAppointment> ServicesAppointments { get; set; }
    }
}
