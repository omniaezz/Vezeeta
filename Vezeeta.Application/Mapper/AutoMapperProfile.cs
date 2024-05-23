using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.AppointmentDtos;
using Vezeeta.Dtos.Dtos.CountriesDtos;
using Vezeeta.Dtos.Dtos.DoctorDto;
using Vezeeta.Dtos.Dtos.DoctorDtos;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Dtos.Dtos.SubSpecialitiesDtos;
using Vezeeta.Dtos.Dtos.WorkingPlaceDtos;
using Vezeeta.Models.AppointmentModels;
using Vezeeta.Models.CountryModels;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.ServicesModels;
using Vezeeta.Models.SpecialtyModels;
using Vezeeta.Models.SubSpecialtiesModels;
using Vezeeta.Models.WorkingPlacesModels;

namespace Vezeeta.Application.Mapper
{
    public class AutoMapperProfile :Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<DoctorDto,Doctor>().ReverseMap();
            CreateMap<CreateOrUpdateDoctorDto,Doctor>().ReverseMap();
            CreateMap<AppointmentsDto,Appointment>().ReverseMap();
            CreateMap<DoctorAppointmentsDto,DoctorAppointments>().ReverseMap();
            CreateMap<DoctorAppointmentsDto,DoctorTeleAppointments>().ReverseMap();
            CreateMap<WorkingPlaceDto,WorkingPlace>().ReverseMap();
            CreateMap<SubSpecialitiesDto,Subspecialties>().ReverseMap();
            CreateMap<DoctorWorkingPlaceDto,DoctorWorkingPlace>().ReverseMap();
            CreateMap<DoctorSubSpecialitiesDto,DoctorSubSpecialties>().ReverseMap();
            CreateMap<DoctorReviewDto, DoctorReviews>().ReverseMap();
            CreateMap<ServiceReviewDto, ServiceReviews>().ReverseMap();
            CreateMap<SpecialtyDto, Specialty>().ReverseMap();
            CreateMap<CountryDto, Countries>().ReverseMap();
        }
    }
}
