using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Dtos.Dtos.SubSpecialitiesDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.SubSpecialtiesServices
{
    public interface ISubSpecialtieService
    {
        Task<ResultView<SubSpecialitiesDto>> CreateSubSpecialtyAsync(SubSpecialitiesDto subSpecialitiesDto);
        Task<ResultView<SubSpecialitiesDto>> UpdateSubSpecialtyAsync(SubSpecialitiesDto subSpecialitiesDto);
        Task<ResultView<SubSpecialitiesDto>> DeleteSubSpecialtyAsync(int SubSpecialtyId);
        Task<ResultView<SubSpecialitiesDto>> GetOneSubSpecialtyByIdAsync(int SubSpecialtyId);
        Task<ResultDataList<SubSpecialitiesDto>> GetSubSpecialtiesBySpecialtyIdAsync(int SpecialtyId);
        Task<ResultDataList<SubSpecialitiesDto>> GetAllSubSpecialtiesAsync(int ItemsPerPage, int PageNumber);//not important
    }
}
