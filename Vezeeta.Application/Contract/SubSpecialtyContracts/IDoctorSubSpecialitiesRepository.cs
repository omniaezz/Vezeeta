using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.SubSpecialtiesModels;

namespace Vezeeta.Application.Contract.SubSpecialtyContracts
{
    public interface IDoctorSubSpecialitiesRepository : IRepository<DoctorSubSpecialties, int>
    {
        Task<IQueryable<Subspecialties>> GetSubSpecialityByDoctorId(int doctorId);
    }
}
