using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.SubSpecialtyContracts;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Dtos.Dtos.SubSpecialitiesDtos;
using Vezeeta.Dtos.ResultDtos;
using Vezeeta.Models.SubSpecialtiesModels;

namespace Vezeeta.Application.Services.SubSpecialtiesServices
{
    public class SubSpecialtieService : ISubSpecialtieService
    {
        private readonly ISubSpecialitiesRepository _subSpecialitiesRepository;
        private readonly IMapper _mapper;

        public SubSpecialtieService(ISubSpecialitiesRepository subSpecialitiesRepository,IMapper mapper)
        {
            _subSpecialitiesRepository = subSpecialitiesRepository;
            _mapper = mapper;
        }

        public async Task<ResultView<SubSpecialitiesDto>> CreateSubSpecialtyAsync(SubSpecialitiesDto subSpecialitiesDto)
        {
            var ExistingSubSpecialty = (await _subSpecialitiesRepository.GetAllAsync())
                                       .FirstOrDefault(s=>s.Name == subSpecialitiesDto.Name);
            if (ExistingSubSpecialty is not null)
            {
                return new ResultView<SubSpecialitiesDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "SubSpecialty Already Existed"
                };
            }

            var SubSpecialty = _mapper.Map<Subspecialties>(subSpecialitiesDto);
            var CreatedSubSpecialty = await _subSpecialitiesRepository.CreateAsync(SubSpecialty);
            await _subSpecialitiesRepository.SaveChangesAsync();
            return new ResultView<SubSpecialitiesDto>
            {
                Entity = _mapper.Map<SubSpecialitiesDto>(CreatedSubSpecialty),
                IsSuccess = true,
                Message = "SubSpecialty created Successfully"
            };
        }

        public async Task<ResultView<SubSpecialitiesDto>> DeleteSubSpecialtyAsync(int SubSpecialtyId)
        {
            var ExistingSubSpecialty = await _subSpecialitiesRepository.GetByIdAsync(SubSpecialtyId);
            if(ExistingSubSpecialty is null)
            {
                return new ResultView<SubSpecialitiesDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "SubSpecialty Doesn't Exist"
                };
            }

            ExistingSubSpecialty.IsDeleted = true;
            await _subSpecialitiesRepository.SaveChangesAsync();
            return new ResultView<SubSpecialitiesDto>
            {
                Entity = _mapper.Map<SubSpecialitiesDto>(ExistingSubSpecialty),
                IsSuccess = true,
                Message = "SubSpecialty Deleted Successfully"
            };
        }

        public async Task<ResultDataList<SubSpecialitiesDto>> GetAllSubSpecialtiesAsync(int ItemsPerPage, int PageNumber)
        {
            var AllSubSpecialities = (await _subSpecialitiesRepository.GetAllAsync())
                                 .Where(s => s.IsDeleted == false)
                                 .ToList();
            if (AllSubSpecialities is null)
            {
                return new ResultDataList<SubSpecialitiesDto>
                {
                    Entites = null,
                    Count = 0
                };
            }

            var PaginatedSubSpecialities = AllSubSpecialities
                                       .Skip(ItemsPerPage * (PageNumber - 1))
                                       .Take(ItemsPerPage)
                                       .ToList();
            return new ResultDataList<SubSpecialitiesDto>
            {
                Entites = _mapper.Map<List<SubSpecialitiesDto>>(PaginatedSubSpecialities),
                Count = AllSubSpecialities.Count()
            };
        }

        public async Task<ResultView<SubSpecialitiesDto>> GetOneSubSpecialtyByIdAsync(int SubSpecialtyId)
        {
            var specialty = await _subSpecialitiesRepository.GetByIdAsync(SubSpecialtyId);
            if (specialty is null)
            {
                return new ResultView<SubSpecialitiesDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Review Doesn't Exist"
                };
            }

            return new ResultView<SubSpecialitiesDto>
            {
                Entity = _mapper.Map<SubSpecialitiesDto>(specialty),
                IsSuccess = true,
                Message = "Specialty Retrieved Successfully"
            };
        }

        public async Task<ResultDataList<SubSpecialitiesDto>> GetSubSpecialtiesBySpecialtyIdAsync(int SpecialtyId)//paginated?
        {
            var AllSubSpecialties = (await _subSpecialitiesRepository.GetAllAsync())
                                    .Where(s=>s.SpecialtyId == SpecialtyId && s.IsDeleted == false)
                                    .ToList();
            if(AllSubSpecialties is null)
            {
                return new ResultDataList<SubSpecialitiesDto>
                {
                    Entites = null,
                    Count = 0
                };
            }

            return new ResultDataList<SubSpecialitiesDto>
            {
                Entites = _mapper.Map<List<SubSpecialitiesDto>>(AllSubSpecialties),
                Count = AllSubSpecialties.Count()
            };
        } 

        public async Task<ResultView<SubSpecialitiesDto>> UpdateSubSpecialtyAsync(SubSpecialitiesDto subSpecialitiesDto)
        {
            var Subspecialty = _mapper.Map<Subspecialties>(subSpecialitiesDto);
            await _subSpecialitiesRepository.UpdateAsync(Subspecialty);
            await _subSpecialitiesRepository.SaveChangesAsync();
            return new ResultView<SubSpecialitiesDto>
            {
                Entity = _mapper.Map<SubSpecialitiesDto>(Subspecialty),
                IsSuccess = true,
                Message = "Specialty Updated Successfully"
            };
        }
    }
}
