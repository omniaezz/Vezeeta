using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.AppointmentDtos;
using Vezeeta.Dtos.Dtos.SubSpecialitiesDtos;
using Vezeeta.Dtos.Dtos.WorkingPlaceDtos;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Dtos.Dtos.DoctorDtos
{
    public class CreateOrUpdateDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AboutDoctor { get; set; }
        public string PhoneNumber { get; set; }
        public string SSN { get; set; }
        public string? DoctorImage { get; set; }
        public decimal Fees { get; set; }
        public int WaitingTime { get; set; }
        public int? AppointmentDurationMinutes { get; set; }
        public Gender Gender { get; set; }
        public int CountryId { get; set; }
        public int SpecialtyId { get; set; }
        public ICollection<AppointmentsDto> AppointmentsDtos { get; set; }
        public ICollection<AppointmentsDto>? TeleAppointmentsDtos { get; set; }
        public ICollection<WorkingPlaceDto> WorkingPlaceDtos { get; set; }
        public ICollection<int> SubSpecialitiesIds { get; set; }

    }
}
