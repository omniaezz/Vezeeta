using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.ServiceDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.ServiceServices
{
    public interface IServiceServices 
    {
        Task<ResultView<ServiceDto>> CreateServiceAsync(ServiceDto serviceDto);
        Task<ResultView<ServiceDto>> UpdateServiceAsync(ServiceDto serviceDto);
        Task<ResultView<ServiceDto>> DeleteServiceAsync(int ServiceId);
        Task<ResultDataList<ServiceDto>> GetAllServiceAsync();
        Task<ResultView<ServiceDto>> GetOneServiceAsync(int ServiceId);
    }
}
