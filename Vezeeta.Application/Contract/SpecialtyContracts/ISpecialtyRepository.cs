using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.SpecialtyModels;

namespace Vezeeta.Application.Contract.SpecialtyContracts
{
    public interface ISpecialtyRepository : IRepository<Specialty, int>
    {
    }
}
