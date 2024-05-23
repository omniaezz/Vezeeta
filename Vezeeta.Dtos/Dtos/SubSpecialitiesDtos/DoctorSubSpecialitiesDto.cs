using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models;

namespace Vezeeta.Dtos.Dtos.SubSpecialitiesDtos
{
    public class DoctorSubSpecialitiesDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int SubSpecialtiesId { get; set; }
    }
}
