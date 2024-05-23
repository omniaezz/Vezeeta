using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.ServicesContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.ServicesModels;

namespace Vezeeta.Infrastucture.ServicesRepositories
{
    public class ServiceRepository : Repository<Service,int>,IServiceRespository
    {
        public ServiceRepository(VezeetaContext vezeetaContext):base(vezeetaContext) { }
        
    }
}
