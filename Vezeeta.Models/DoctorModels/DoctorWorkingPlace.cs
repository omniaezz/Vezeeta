﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models.WorkingPlacesModels;

namespace Vezeeta.Models.DoctorModels
{
    public class DoctorWorkingPlace : BaseEntity
    {
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("WorkingPlace")]
        public int WorkingPlaceId { get; set; }
        public WorkingPlace WorkingPlace { get; set; }
    }
}
