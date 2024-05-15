using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public class Subspecialties : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("Specialty")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        public ICollection<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
    }
}
