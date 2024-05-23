using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Models.WorkingPlacesModels
{
    public class WorkingPlace : BaseEntity
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public ICollection<DoctorWorkingPlace> DoctorWorkingPlaces { get; set; }
    }
}
