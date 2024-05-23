using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.SubSpecialtiesModels;

namespace Vezeeta.Models.SpecialtyModels
{
    public class Specialty : BaseEntity
    {
        public string SpecialtyName { get; set; }
        public ICollection<Subspecialties> Subspecialties { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
