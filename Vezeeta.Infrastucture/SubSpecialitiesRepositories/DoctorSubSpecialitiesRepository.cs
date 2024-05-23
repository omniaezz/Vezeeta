using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.SubSpecialtyContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.SubSpecialtiesModels;

namespace Vezeeta.Infrastucture.SubSpecialitiesRepositories
{
    public class DoctorSubSpecialitiesRepository : Repository<DoctorSubSpecialties,int>,IDoctorSubSpecialitiesRepository
    {
        private readonly VezeetaContext _vezeetaContext;

        public DoctorSubSpecialitiesRepository(VezeetaContext vezeetaContext) : base(vezeetaContext)
        {
            _vezeetaContext = vezeetaContext;
        }

        public Task<IQueryable<Subspecialties>> GetSubSpecialityByDoctorId(int doctorId)
        {
            return Task.FromResult(from da in _vezeetaContext.DoctorSubSpecialties
                                   join a in _vezeetaContext.Subspecialties on da.SubSpecialtiesId equals a.Id
                                   where da.DoctorId == doctorId
                                   select a);
        }
    }
}
