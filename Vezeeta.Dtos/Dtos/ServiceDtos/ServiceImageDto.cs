using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Dtos.Dtos.ServiceDtos
{
    public class ServiceImageDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ServiceId { get; set; }
    }
}
