using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.ServicesModels;

namespace Vezeeta.Application.Contract.ServicesContracts
{
    public interface IServiceRespository : IRepository<Service, int>
    {
    }
}
