using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.CountryContracts;
using Vezeeta.Dtos.Dtos.CountriesDtos;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Dtos.ResultDtos;
using Vezeeta.Models.CountryModels;

namespace Vezeeta.Application.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryImagesRepostiory _countryImagesRepostiory;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository,ICountryImagesRepostiory countryImagesRepostiory , IMapper mapper)
        {
            _countryRepository = countryRepository;
            _countryImagesRepostiory = countryImagesRepostiory;
            _mapper = mapper;
        }

        public async Task<ResultView<CountryDto>> CreateCountryAsync(CountryDto countryDto)
        {
            var ExistingCountry = (await _countryRepository.GetAllAsync())
                                  .FirstOrDefault(c => c.CountryName == countryDto.CountryName);
            if (ExistingCountry is null)
            {
                return new ResultView<CountryDto>
                {
                    Entity = countryDto,
                    IsSuccess = true,
                    Message = "Country Already Existed"
                };
            }

            var country = _mapper.Map<Countries>(countryDto);
            var CreatedCountry = await _countryRepository.CreateAsync(country);
            await _countryRepository.SaveChangesAsync();

            foreach(var image in countryDto.countryImagesDtos)
            {
                image.CountriesId = CreatedCountry.Id;
                await _countryImagesRepostiory.CreateAsync(_mapper.Map<CountriesImages>(image));
            }
            await _countryImagesRepostiory.SaveChangesAsync();

            return new ResultView<CountryDto> 
            {
                Entity = _mapper.Map<CountryDto>(CreatedCountry),
                IsSuccess = true,
                Message = "Country Created Successfully"
            };
        }

        public async Task<ResultView<CountryDto>> DeleteCountryAsync(int CountryId)
        {
            var ExistingCountry = await _countryRepository.GetByIdAsync(CountryId);
            if(ExistingCountry is null)
            {
                return new ResultView<CountryDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Country Doesn't Exist"
                };
            }

            ExistingCountry.IsDeleted = true;
            await _countryRepository.SaveChangesAsync();

            foreach (var image in ExistingCountry.CountriesImages)
            {
                image.IsDeleted = true;
            }
            await _countryImagesRepostiory.SaveChangesAsync();

            return new ResultView<CountryDto>
            {
                Entity = _mapper.Map<CountryDto>(ExistingCountry),
                IsSuccess = true,
                Message = "Country Deleted Successfully"
            };
        }

        public async Task<ResultDataList<CountryDto>> GetAllCoutriesAsync(int ItemsPerPage, int PageNumber)
        {
            var AllCoutries = (await _countryRepository.GetAllAsync())
                              .Where(s => s.IsDeleted == false)
                              .ToList();

            if (AllCoutries is null)
            {
                return new ResultDataList<CountryDto>
                {
                    Entites = null,
                    Count = 0
                };
            }

            var PaginatedCoutries = AllCoutries
                                       .Skip(ItemsPerPage * (PageNumber - 1))
                                       .Take(ItemsPerPage)
                                       .ToList();
            return new ResultDataList<CountryDto>
            {
                Entites = _mapper.Map<List<CountryDto>>(PaginatedCoutries),
                Count = AllCoutries.Count()
            };
        }

        public async Task<ResultView<CountryDto>> GetOneCountryAsync(int CountryId)
        {
            var counrty = await _countryRepository.GetByIdAsync(CountryId);

            if (counrty is null)
            {
                return new ResultView<CountryDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Country Doesn't Exist"
                };
            }

            return new ResultView<CountryDto>
            {
                Entity = _mapper.Map<CountryDto>(counrty),
                IsSuccess = true,
                Message = "Counrty Retrieved Successfully"
            };
        }

        public async Task<ResultView<CountryDto>> UpdateCountryAsync(CountryDto countryDto)
        {
            var country = _mapper.Map<Countries>(countryDto);
            var UpdatedCountry = await _countryRepository.UpdateAsync(country);
            await _countryRepository.SaveChangesAsync();

            foreach(var image in countryDto.countryImagesDtos)
            {
                await _countryImagesRepostiory.UpdateAsync(_mapper.Map<CountriesImages>(image));
            }
            await _countryImagesRepostiory.SaveChangesAsync();
            return new ResultView<CountryDto>
            {
                Entity = countryDto,
                IsSuccess = true,
                Message = "Country Updated Successfully"
            };
        }
    }
}
