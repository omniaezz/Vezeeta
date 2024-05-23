using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.UserModels;

namespace Vezeeta.Models.ServicesModels
{
    public class ServiceReviews : BaseEntity
    {
        public string Comment { get; set; }
        public int Rating { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Services")]
        public int ServiceId { get; set; }
        public Service Services { get; set; }
    }
}
