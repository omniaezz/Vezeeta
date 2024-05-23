using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.ServicesContracts;
using Vezeeta.Dtos.Dtos.ServiceDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.ServiceServices
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServiceRespository _serviceRespository;

        public ServiceServices(IServiceRespository serviceRespository)
        {
            _serviceRespository = serviceRespository;
        }
        public Task<ResultView<ServiceDto>> CreateServiceAsync(ServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<ServiceDto>> DeleteServiceAsync(int ServiceId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataList<ServiceDto>> GetAllServiceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<ServiceDto>> GetOneServiceAsync(int ServiceId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<ServiceDto>> UpdateServiceAsync(ServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }
    }
}
