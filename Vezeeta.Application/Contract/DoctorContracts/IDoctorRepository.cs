using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Application.Contract.DoctorContracts
{
    public interface IDoctorRepository : IRepository<Doctor, int>
    {
    }
}
