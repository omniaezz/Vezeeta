using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public class WorkingPlace : BaseEntity
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string City { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId {  get; set; }
        public Doctor Doctor { get; set; }
    }
}
