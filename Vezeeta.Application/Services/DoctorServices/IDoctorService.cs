using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.DoctorDto;
using Vezeeta.Dtos.Dtos.DoctorDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<ResultView<CreateOrUpdateDoctorDto>> CreateDoctor(CreateOrUpdateDoctorDto doctor);
        Task<ResultView<CreateOrUpdateDoctorDto>> Update(CreateOrUpdateDoctorDto doctor);
        Task<ResultView<DoctorDto>> Delete(int Id);
        Task<ResultView<DoctorDto>> GetOne(int Id);
        Task<ResultDataList<DoctorDto>> GetAll(int ItemsPerPage, int PageNumber);
    }
}
