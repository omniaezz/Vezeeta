using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.SpecialtyContracts;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Dtos.ResultDtos;
using Vezeeta.Models.SpecialtyModels;

namespace Vezeeta.Application.Services.SpecialtyServices
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IMapper _mapper;

        public SpecialtyService(ISpecialtyRepository specialtyRepository , IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
        }
        public async Task<ResultView<SpecialtyDto>> CreateSpecialtyAsync(SpecialtyDto specialtyDto)
        {
            var ExistingSpecialty = (await _specialtyRepository.GetAllAsync())
                                    .FirstOrDefault(s=>s.SpecialtyName == specialtyDto.SpecialtyName);
            if (ExistingSpecialty != null)
            {
                return new ResultView<SpecialtyDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Specialty Already Existed"
                };
            }

            var specialty = _mapper.Map<Specialty>(specialtyDto);
            var CreatedSpecialty = await _specialtyRepository.CreateAsync(specialty);
            await _specialtyRepository.SaveChangesAsync();
            return new ResultView<SpecialtyDto>
            {
                Entity = _mapper.Map<SpecialtyDto>(CreatedSpecialty),
                IsSuccess = true,
                Message = "Specialty Created Successfully"
            };
        }

        public async Task<ResultView<SpecialtyDto>> DeleteSpecialtyAsync(int SpecialtyId)
        {
            var ExistingSpecialty = await _specialtyRepository.GetByIdAsync(SpecialtyId);
            if(ExistingSpecialty is null)
            {
                return new ResultView<SpecialtyDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Specialty Doesn't Exist"
                };
            }

            ExistingSpecialty.IsDeleted = true;
            await _specialtyRepository.SaveChangesAsync();
            return new ResultView<SpecialtyDto>
            {
                Entity = _mapper.Map<SpecialtyDto>(ExistingSpecialty),
                IsSuccess = true,
                Message = "Specialty Deleted Successfully"
            };
        }

        public async Task<ResultDataList<SpecialtyDto>> GetAllSpecialtiesAsync(int ItemsPerPage, int PageNumber)
        {
            var AllSpecialties = (await _specialtyRepository.GetAllAsync())
                                 .Where(s => s.IsDeleted == false)
                                 .ToList();
            if(AllSpecialties is null)
            {
                return new ResultDataList<SpecialtyDto>
                {
                    Entites = null,
                    Count = 0
                };
            }

            var PaginatedSpecialties = AllSpecialties
                                       .Skip(ItemsPerPage * (PageNumber - 1))
                                       .Take(ItemsPerPage)
                                       .ToList();
            return new ResultDataList<SpecialtyDto>
            {
                Entites = _mapper.Map<List<SpecialtyDto>>(PaginatedSpecialties),
                Count = AllSpecialties.Count()
            };
        }

        public async Task<ResultView<SpecialtyDto>> GetOneSpecialtyByIdAsync(int SpecialtyId)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(SpecialtyId);
            if (specialty is null)
            {
                return new ResultView<SpecialtyDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Review Doesn't Exist"
                };
            }

            return new ResultView<SpecialtyDto>
            {
                Entity = _mapper.Map<SpecialtyDto>(specialty),
                IsSuccess = true,
                Message = "Specialty Retrieved Successfully"
            };
        }

        public async Task<ResultView<SpecialtyDto>> UpdateSpecialtyAsync(SpecialtyDto specialtyDto)
        {
            var specialty = _mapper.Map<Specialty>(specialtyDto);
            await _specialtyRepository.UpdateAsync(specialty);
            await _specialtyRepository.SaveChangesAsync();
            return new ResultView<SpecialtyDto>
            {
                Entity = _mapper.Map<SpecialtyDto>(specialty),
                IsSuccess = true,
                Message = "Specialty Updated Successfully"
            };
        }
    }
}
