﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models;

namespace Vezeeta.Dtos.Dtos.ReviewDtos
{
    public class DoctorReviewDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; }
        public int DoctorId { get; set; }
    }
}
