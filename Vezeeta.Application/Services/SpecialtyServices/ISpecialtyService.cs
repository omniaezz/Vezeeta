using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.SpecialtyServices
{
    public interface ISpecialtyService
    {
        Task<ResultView<SpecialtyDto>> CreateSpecialtyAsync(SpecialtyDto specialtyDto);
        Task<ResultView<SpecialtyDto>> UpdateSpecialtyAsync(SpecialtyDto specialtyDto);
        Task<ResultView<SpecialtyDto>> DeleteSpecialtyAsync(int SpecialtyId);
        Task<ResultView<SpecialtyDto>> GetOneSpecialtyByIdAsync(int SpecialtyId);
        Task<ResultDataList<SpecialtyDto>> GetAllSpecialtiesAsync(int ItemsPerPage , int PageNumber);
    }
}
