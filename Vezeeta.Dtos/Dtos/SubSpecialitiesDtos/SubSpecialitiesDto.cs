﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Dtos.Dtos.SubSpecialitiesDtos
{
    public class SubSpecialitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialtyId { get; set; }
    }
}
