using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.DoctorDto;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services
{
    public interface IDoctorService
    {
        Task<ResultView<DoctorDto>> CreateDoctor(DoctorDto doctor);
        Task<ResultView<DoctorDto>> Update(DoctorDto doctor);
        Task<ResultView<DoctorDto>> Delete(int Id);
        Task<ResultView<DoctorDto>> GetOne(int Id);
        Task<ResultDataList<DoctorDto>> GetAll();
    }
}
