﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.UserModels;

namespace Vezeeta.Models.DoctorModels
{
    public class DoctorReviews : BaseEntity
    {
        public string Comment { get; set; }
        public int Rating { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
