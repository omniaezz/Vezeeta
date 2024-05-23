using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.WorkingPlaceContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.DoctorModels;
using Vezeeta.Models.WorkingPlacesModels;

namespace Vezeeta.Infrastucture.WorkingPlaceRepositories
{
    public class DoctorWorkingPlaceRepository : Repository<DoctorWorkingPlace, int>, IDoctorWorkingPlaceRepository
    {
        private readonly VezeetaContext _vezeetaContext;

        public DoctorWorkingPlaceRepository(VezeetaContext vezeetaContext) : base(vezeetaContext)
        {
            _vezeetaContext = vezeetaContext;
        }

        public Task<IQueryable<WorkingPlace>> GetWorkingByDoctorId(int doctorId)
        {
            return Task.FromResult(from da in _vezeetaContext.DoctorWorkingPlaces
                                   join a in _vezeetaContext.WorkingPlaces on da.WorkingPlaceId equals a.Id
                                   where da.DoctorId == doctorId
                                   select a);
        }
    }
}
