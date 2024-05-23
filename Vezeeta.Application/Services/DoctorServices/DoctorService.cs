using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.AppointmentContracts;
using Vezeeta.Application.Contract.DoctorContracts;
using Vezeeta.Application.Contract.SubSpecialtyContracts;
using Vezeeta.Application.Contract.WorkingPlaceContracts;
using Vezeeta.Dtos.Dtos.AppointmentDtos;
using Vezeeta.Dtos.Dtos.DoctorDto;
using Vezeeta.Dtos.Dtos.DoctorDtos;
using Vezeeta.Dtos.Dtos.SubSpecialitiesDtos;
using Vezeeta.Dtos.Dtos.WorkingPlaceDtos;
using Vezeeta.Dtos.ResultDtos;
using Vezeeta.Models.AppointmentModels;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.WorkingPlacesModels;

namespace Vezeeta.Application.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorAppointmentsRepository _doctorAppointmentsRepository;
        private readonly IDoctorTeleAppointmentsRepository _doctorTeleAppointmentsRepository;
        private readonly IWorkingPlaceRepository _workingPlaceRepository;
        private readonly IDoctorWorkingPlaceRepository _doctorWorkingPlaceRepository;
        private readonly ISubSpecialitiesRepository _subSpecialitiesRepository;
        private readonly IDoctorSubSpecialitiesRepository _doctorSubSpecialitiesRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository,
                             IDoctorAppointmentsRepository doctorAppointmentsRepository,
                             IDoctorTeleAppointmentsRepository doctorTeleAppointmentsRepository,
                             IWorkingPlaceRepository workingPlaceRepository,
                             IDoctorWorkingPlaceRepository doctorWorkingPlaceRepository,
                             ISubSpecialitiesRepository subSpecialitiesRepository,
                             IDoctorSubSpecialitiesRepository doctorSubSpecialitiesRepository,
                             IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _doctorAppointmentsRepository = doctorAppointmentsRepository;
            _doctorTeleAppointmentsRepository = doctorTeleAppointmentsRepository;
            _workingPlaceRepository = workingPlaceRepository;
            _doctorWorkingPlaceRepository = doctorWorkingPlaceRepository;
            _subSpecialitiesRepository = subSpecialitiesRepository;
            _doctorSubSpecialitiesRepository = doctorSubSpecialitiesRepository;
            _mapper = mapper;
        }

        public async Task<ResultView<CreateOrUpdateDoctorDto>> CreateDoctor(CreateOrUpdateDoctorDto doctorDto)
        {
            var ExistingDoctor = (await _doctorRepository.GetAllAsync())
                                 .FirstOrDefault(d => d.SSN == doctorDto.SSN);
            if (ExistingDoctor is not null)
            {
                return new ResultView<CreateOrUpdateDoctorDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Faild To Add , Doctor Already Exists"
                };
            }

            var MappingDoctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.CreateAsync(MappingDoctor);
            await _doctorRepository.SaveChangesAsync();


            if (doctorDto.AppointmentsDtos != null)
            {
                foreach (var appointment in doctorDto.AppointmentsDtos)
                {

                    var ExistingAppointment = (await _appointmentRepository.GetAllAsync())
                     .FirstOrDefault(a => a.StartTime == appointment.StartTime
                     && a.EndTime == appointment.EndTime);

                    if (ExistingAppointment is null)
                    {
                        var AddedAppointment = await _appointmentRepository.CreateAsync(_mapper.Map<Appointment>(appointment));
                        await _appointmentRepository.SaveChangesAsync();

                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = MappingDoctor.Id, AppointmentId = AddedAppointment.Id };
                        await _doctorAppointmentsRepository.CreateAsync(_mapper.Map<DoctorAppointments>(DoctorAppointment));
                    }
                    else
                    {
                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = MappingDoctor.Id, AppointmentId = ExistingAppointment.Id };
                        await _doctorAppointmentsRepository.CreateAsync(_mapper.Map<DoctorAppointments>(DoctorAppointment));
                    }
                    await _doctorAppointmentsRepository.SaveChangesAsync();
                }
            }


            if (doctorDto.TeleAppointmentsDtos != null)
            {
                foreach (var appointment in doctorDto.TeleAppointmentsDtos)
                {
                    var ExistingAppointment = (await _appointmentRepository.GetAllAsync())
                     .FirstOrDefault(a => a.StartTime == appointment.StartTime
                     && a.EndTime == appointment.EndTime);

                    if (ExistingAppointment is null)
                    {
                        var AddedAppointment = await _appointmentRepository.CreateAsync(_mapper.Map<Appointment>(appointment));
                        await _appointmentRepository.SaveChangesAsync();

                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = MappingDoctor.Id, AppointmentId = AddedAppointment.Id };
                        await _doctorTeleAppointmentsRepository.CreateAsync(_mapper.Map<DoctorTeleAppointments>(DoctorAppointment));
                    }
                    else
                    {
                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = MappingDoctor.Id, AppointmentId = ExistingAppointment.Id };
                        await _doctorTeleAppointmentsRepository.CreateAsync(_mapper.Map<DoctorTeleAppointments>(DoctorAppointment));
                    }
                    await _doctorAppointmentsRepository.SaveChangesAsync();
                    await _doctorTeleAppointmentsRepository.SaveChangesAsync();
                }
            }


            if(doctorDto.WorkingPlaceDtos != null)
            {
                foreach(var workingPlaceDto in  doctorDto.WorkingPlaceDtos)
                {
                    var ExistingPlace = (await _workingPlaceRepository.GetAllAsync())
                                        .FirstOrDefault(w=>w.Name == workingPlaceDto.Name 
                                                        && w.Area == workingPlaceDto.Area 
                                                        && w.City == workingPlaceDto.City);
                    if (ExistingPlace is null)
                    {
                        var AddedPlace = await _workingPlaceRepository.CreateAsync(_mapper.Map<WorkingPlace>(workingPlaceDto));
                        await _workingPlaceRepository.SaveChangesAsync();

                        var DocWorkingPlacedto = new DoctorWorkingPlaceDto { DoctorId = MappingDoctor.Id, WorkingPlaceId = AddedPlace.Id };
                        await _doctorWorkingPlaceRepository.CreateAsync(_mapper.Map<DoctorWorkingPlace>(DocWorkingPlacedto));
                    }
                    else
                    {
                        var DocWorkingPlacedto = new DoctorWorkingPlaceDto { DoctorId = MappingDoctor.Id, WorkingPlaceId = ExistingPlace.Id };
                        await _doctorWorkingPlaceRepository.CreateAsync(_mapper.Map<DoctorWorkingPlace>(DocWorkingPlacedto));
                    }
                    await _doctorWorkingPlaceRepository.SaveChangesAsync();
                }
            }


            if(doctorDto.SubSpecialitiesIds !=null)
            {
                foreach(var SubSpecilatyId in doctorDto.SubSpecialitiesIds)
                {
                    var ExistingSubSpecialties = await _subSpecialitiesRepository.GetByIdAsync(SubSpecilatyId);
                    if(ExistingSubSpecialties != null)
                    {
                        var DoctorSubSpecialtyDto = new DoctorSubSpecialitiesDto { DoctorId = MappingDoctor.Id , SubSpecialtiesId = SubSpecilatyId };
                        await _doctorSubSpecialitiesRepository.CreateAsync(_mapper.Map<DoctorSubSpecialties>(DoctorSubSpecialtyDto));
                        await _doctorSubSpecialitiesRepository.SaveChangesAsync();
                    }
                }
            }

            return new ResultView<CreateOrUpdateDoctorDto>
            {
                Entity = _mapper.Map<CreateOrUpdateDoctorDto>(MappingDoctor),
                IsSuccess = true,
                Message = "Doctor Added Successfully"
            };
        }

        public async Task<ResultView<DoctorDto>> Delete(int Id)
        {
            var ExistingDoctor = await _doctorRepository.GetByIdAsync(Id);
            if (ExistingDoctor == null)
            {
                return new ResultView<DoctorDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Doctor Doesn't Exist"
                };
            }

            //appointments

            var AllDoctorAppointments = (await _doctorAppointmentsRepository.GetAllAsync())
                                        .Where(da => da.DoctorId == Id && da.IsDeleted == false);

            foreach(var doctorAppointment in AllDoctorAppointments)
            {
                doctorAppointment.IsDeleted = true;
            }
            await _doctorAppointmentsRepository.SaveChangesAsync();


            //teleappointments

            var AllDoctorTeleAppointments = (await _doctorTeleAppointmentsRepository.GetAllAsync())
                                        .Where(da => da.DoctorId == Id && da.IsDeleted == false);

            foreach (var doctorTeleAppointment in AllDoctorTeleAppointments)
            {
                doctorTeleAppointment.IsDeleted = true;
            }
            await _doctorTeleAppointmentsRepository.SaveChangesAsync();


            //workingplaces

            var AllDoctorWorkingPlaces = (await _doctorWorkingPlaceRepository.GetAllAsync())
                                        .Where(da => da.DoctorId == Id && da.IsDeleted == false);

            foreach (var workingPlace in AllDoctorWorkingPlaces)
            {
                workingPlace.IsDeleted = true;
            }
            await _doctorWorkingPlaceRepository.SaveChangesAsync();


            //SubSpecialities

            var AllDoctorSubSpecialities = (await _doctorSubSpecialitiesRepository.GetAllAsync())
                                        .Where(da => da.DoctorId == Id && da.IsDeleted == false);

            foreach (var doctorSubSpecialty in AllDoctorSubSpecialities)
            {
                doctorSubSpecialty.IsDeleted = true;
            }
            await _doctorSubSpecialitiesRepository.SaveChangesAsync();

            ExistingDoctor.IsDeleted = true;
            await _doctorRepository.SaveChangesAsync();
            return new ResultView<DoctorDto>
            {
                Entity = _mapper.Map<DoctorDto>(ExistingDoctor),
                IsSuccess = true,
                Message = "Doctor Deleted Successfully"
            };
        }

        public async Task<ResultDataList<DoctorDto>> GetAll(int ItemsPerPage, int PageNumber)
        {

            var AllDoctors = (await _doctorRepository.GetAllAsync())
                             .Where(d => d.IsDeleted == false)
                             .ToList();
            if (AllDoctors is not null)
            {
                var AllDoctorsDto = _mapper.Map<List<DoctorDto>>(AllDoctors);

                foreach(var doctorDto in AllDoctorsDto) 
                {
                    var DoctorAppointments = (await _doctorAppointmentsRepository.GetAppointmentsByDoctorId(doctorDto.Id)).ToList();
                    doctorDto.AppointmentsDtos = _mapper.Map<List<AppointmentsDto>>(DoctorAppointments);

                    var DoctorTeleAppointments = (await _doctorTeleAppointmentsRepository.GetTeleAppointmentsByDoctorId(doctorDto.Id)).ToList();
                    doctorDto.TeleAppointmentsDtos = _mapper.Map<List<AppointmentsDto>>(DoctorTeleAppointments);

                    var DoctorWorkingPlaces = (await _doctorWorkingPlaceRepository.GetWorkingByDoctorId(doctorDto.Id)).ToList();
                    doctorDto.WorkingPlaceDtos = _mapper.Map<List<WorkingPlaceDto>>(DoctorWorkingPlaces);

                    var DoctorSubSpecialities = (await _doctorSubSpecialitiesRepository.GetSubSpecialityByDoctorId(doctorDto.Id)).ToList();
                    doctorDto.SubSpecialitiesDto = _mapper.Map<List<SubSpecialitiesDto>>(DoctorSubSpecialities);
                }


                var PaginatedDoctors = AllDoctorsDto
                                      .Skip(ItemsPerPage * (PageNumber - 1))
                                      .Take(ItemsPerPage)
                                      .ToList();

                return new ResultDataList<DoctorDto>
                {
                    Entites = PaginatedDoctors,
                    Count = AllDoctors.Count(),
                };

            }

            return new ResultDataList<DoctorDto>
            {
                Entites = null,
                Count = 0
            };
        }

        public async Task<ResultView<DoctorDto>> GetOne(int Id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(Id);
            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            var DoctorAppointments = (await _doctorAppointmentsRepository.GetAppointmentsByDoctorId(Id)).ToList();
            doctorDto.AppointmentsDtos = _mapper.Map<List<AppointmentsDto>>(DoctorAppointments);
            
            var DoctorTeleAppointments = (await _doctorTeleAppointmentsRepository.GetTeleAppointmentsByDoctorId(Id)).ToList();
            doctorDto.TeleAppointmentsDtos = _mapper.Map<List<AppointmentsDto>>(DoctorTeleAppointments);

            var DoctorWorkingPlaces = (await _doctorWorkingPlaceRepository.GetWorkingByDoctorId(Id)).ToList();
            doctorDto.WorkingPlaceDtos = _mapper.Map<List<WorkingPlaceDto>>(DoctorWorkingPlaces);

            var DoctorSubSpecialities = (await _doctorSubSpecialitiesRepository.GetSubSpecialityByDoctorId(Id)).ToList();
            doctorDto.SubSpecialitiesDto = _mapper.Map<List<SubSpecialitiesDto>>(DoctorSubSpecialities);

            if (doctor is null)
            {
                return new ResultView<DoctorDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Doctor Doesn't Exist"
                };
            }
            return new ResultView<DoctorDto>
            {
                Entity = doctorDto,
                IsSuccess = true,
                Message = "Doctor Retrived Successfully"
            };
        }

        public async Task<ResultView<CreateOrUpdateDoctorDto>> Update(CreateOrUpdateDoctorDto doctorDto)
        {
           

            var UpdatedDoctor = await _doctorRepository.UpdateAsync(_mapper.Map<Doctor>(doctorDto));
            await _doctorRepository.SaveChangesAsync();


            //Appointments

            var ExistingAppointmets = (await _doctorAppointmentsRepository.GetAllAsync())
                                      .Where(d=>d.DoctorId ==  doctorDto.Id).ToList();

            foreach(var OldAppointment in ExistingAppointmets)
            {
                await _doctorAppointmentsRepository.DeleteAsync(OldAppointment);
                await _doctorAppointmentsRepository.SaveChangesAsync();
            }

            if (doctorDto.AppointmentsDtos != null)
            {

                foreach (var NewAppointment in doctorDto.AppointmentsDtos)
                {
                    var ExistingAppointment = (await _appointmentRepository.GetAllAsync())
                         .FirstOrDefault(a => a.StartTime == NewAppointment.StartTime
                         && a.EndTime == NewAppointment.EndTime);

                    if (ExistingAppointment is null)
                    {
                        var AddedAppointment = await _appointmentRepository.CreateAsync(_mapper.Map<Appointment>(NewAppointment));
                        await _appointmentRepository.SaveChangesAsync();

                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = UpdatedDoctor.Id, AppointmentId = AddedAppointment.Id };
                        await _doctorAppointmentsRepository.CreateAsync(_mapper.Map<DoctorAppointments>(DoctorAppointment));
                    }
                    else
                    {
                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = UpdatedDoctor.Id, AppointmentId = ExistingAppointment.Id };
                        await _doctorAppointmentsRepository.CreateAsync(_mapper.Map<DoctorAppointments>(DoctorAppointment));
                    }
                    await _doctorAppointmentsRepository.SaveChangesAsync();

                }

            }

                


            //TelepAppointments

            var ExistingTeleAppointments = (await _doctorTeleAppointmentsRepository.GetAllAsync())
                                           .Where(d => d.DoctorId == doctorDto.Id).ToList();

            foreach(var OldTeleAppointment in ExistingTeleAppointments)
            {
                await _doctorTeleAppointmentsRepository.DeleteAsync(OldTeleAppointment);
                await _doctorTeleAppointmentsRepository.SaveChangesAsync();
            }


            if (doctorDto.TeleAppointmentsDtos != null)
            {
                foreach (var NewTeleAppointment in doctorDto.TeleAppointmentsDtos)
                {
                    var ExistingAppointment = (await _appointmentRepository.GetAllAsync())
                         .FirstOrDefault(a => a.StartTime == NewTeleAppointment.StartTime
                         && a.EndTime == NewTeleAppointment.EndTime);

                    if (ExistingAppointment is null)
                    {
                        var AddedAppointment = await _appointmentRepository.CreateAsync(_mapper.Map<Appointment>(NewTeleAppointment));
                        await _appointmentRepository.SaveChangesAsync();

                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = UpdatedDoctor.Id, AppointmentId = AddedAppointment.Id };
                        await _doctorTeleAppointmentsRepository.CreateAsync(_mapper.Map<DoctorTeleAppointments>(DoctorAppointment));
                    }
                    else
                    {
                        var DoctorAppointment = new DoctorAppointmentsDto { DoctorId = UpdatedDoctor.Id, AppointmentId = ExistingAppointment.Id };
                        await _doctorTeleAppointmentsRepository.CreateAsync(_mapper.Map<DoctorTeleAppointments>(DoctorAppointment));
                    }
                    await _doctorAppointmentsRepository.SaveChangesAsync();
                    await _doctorTeleAppointmentsRepository.SaveChangesAsync();
                }
            }


            //WorkingPlaces

            var ExistingWorkingPlaces = (await _doctorWorkingPlaceRepository.GetAllAsync())
                                           .Where(d => d.DoctorId == doctorDto.Id).ToList();

            foreach( var OldWorkingPlace in ExistingWorkingPlaces)
            {
                await _doctorWorkingPlaceRepository.DeleteAsync(OldWorkingPlace);
                await _doctorWorkingPlaceRepository.SaveChangesAsync();
            }

            if(doctorDto.WorkingPlaceDtos != null)
            {
                foreach(var NewWorkingPlace in  doctorDto.WorkingPlaceDtos)
                {
                    var ExistingPlace = (await _workingPlaceRepository.GetAllAsync())
                                        .FirstOrDefault(w => w.Name == NewWorkingPlace.Name
                                                        && w.Area == NewWorkingPlace.Area
                                                        && w.City == NewWorkingPlace.City);
                    if (ExistingPlace is null)
                    {
                        var AddedPlace = await _workingPlaceRepository.CreateAsync(_mapper.Map<WorkingPlace>(NewWorkingPlace));
                        await _workingPlaceRepository.SaveChangesAsync();

                        var DocWorkingPlacedto = new DoctorWorkingPlaceDto { DoctorId = UpdatedDoctor.Id, WorkingPlaceId = AddedPlace.Id };
                        await _doctorWorkingPlaceRepository.CreateAsync(_mapper.Map<DoctorWorkingPlace>(DocWorkingPlacedto));
                    }
                    else
                    {
                        var DocWorkingPlacedto = new DoctorWorkingPlaceDto { DoctorId = UpdatedDoctor.Id, WorkingPlaceId = ExistingPlace.Id };
                        await _doctorWorkingPlaceRepository.CreateAsync(_mapper.Map<DoctorWorkingPlace>(DocWorkingPlacedto));
                    }
                    await _doctorWorkingPlaceRepository.SaveChangesAsync();
                }
            }


            //SubSpecialities

            var ExistingSubSpecialties = (await _doctorSubSpecialitiesRepository.GetAllAsync())
                                         .Where(d => d.DoctorId == doctorDto.Id).ToList();

            foreach (var OldSubSpecialty in ExistingSubSpecialties)
            {
                await _doctorSubSpecialitiesRepository.DeleteAsync(OldSubSpecialty);
                await _doctorSubSpecialitiesRepository.SaveChangesAsync();
            }

            if (doctorDto.SubSpecialitiesIds != null)
            {
                foreach (var NewSubSpecialty in doctorDto.SubSpecialitiesIds)
                {
                    var ExistingSubSpecialty = await _subSpecialitiesRepository.GetByIdAsync(NewSubSpecialty);
                    
                    if (ExistingSubSpecialty != null)
                    {
                        var DoctorSubSpecialtyDto = new DoctorSubSpecialitiesDto { DoctorId = UpdatedDoctor.Id, SubSpecialtiesId = NewSubSpecialty };
                        await _doctorSubSpecialitiesRepository.CreateAsync(_mapper.Map<DoctorSubSpecialties>(DoctorSubSpecialtyDto));
                        await _doctorSubSpecialitiesRepository.SaveChangesAsync();
                    }
                }
            }


            return new ResultView<CreateOrUpdateDoctorDto>
            {
                Entity = _mapper.Map<CreateOrUpdateDoctorDto>(UpdatedDoctor),
                IsSuccess = true,
                Message = "Doctor Updated Successfully"
            };
        }
    }
}
