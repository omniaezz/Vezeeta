using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models;

namespace Vezeeta.Dtos.Dtos.DoctorDto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AboutDoctor { get; set; }
        public string? DoctorImage { get; set; }
        public decimal Fees { get; set; }
        public int WaitingTime { get; set; }
        public Gender Gender { get; set; }
        public int CountryId { get; set; }
        public int SpecialtyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
