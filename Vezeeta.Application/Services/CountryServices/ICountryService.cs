using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.CountriesDtos;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.CountryServices
{
    public interface ICountryService
    {
        Task<ResultView<CountryDto>> CreateCountryAsync(CountryDto countryDto);
        Task<ResultView<CountryDto>> UpdateCountryAsync(CountryDto countryDto);
        Task<ResultView<CountryDto>> GetOneCountryAsync(int ReviewId);
        Task<ResultDataList<CountryDto>> GetAllCoutriesAsync(int ItemsPerPage, int PageNumber);
        Task<ResultView<CountryDto>> DeleteCountryAsync(int CountryId);
    }
}
