using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.WorkingPlaceContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.WorkingPlacesModels;

namespace Vezeeta.Infrastucture.WorkingPlaceRepositories
{
    public class WorkingPlaceRepository : Repository<WorkingPlace, int>, IWorkingPlaceRepository
    {
        public WorkingPlaceRepository(VezeetaContext vezeetaContext) : base(vezeetaContext) { }

    }
}
