using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.AppointmentDtos;
using Vezeeta.Dtos.Dtos.ReviewDtos;

namespace Vezeeta.Dtos.Dtos.ServiceDtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int DiscountValue { get; set; }
        public decimal DiscountedPrice => ServicePrice - (ServicePrice * DiscountValue / 100);
        public string ServicePlaceName { get; set; }
        public string ServicePlaceAddress { get; set; }
        public string ServicePlaceImage { get; set; }
        public ICollection<ServiceImageDto> ServiceImageDtos { get; set; }
        public ICollection<AppointmentsDto> ServiceAppointmentDtos { get; set; }
        
    }
}
