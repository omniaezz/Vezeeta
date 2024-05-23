using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models.WorkingPlacesModels
{
    public class ClinicImages : BaseEntity
    {
        public string ImagePath { get; set; }

        [ForeignKey("WorkingPlace")]
        public int WorkingId { get; set; }
        public WorkingPlace WorkingPlace { get; set; }
    }
}
