using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.WorkingPlacesModels;

namespace Vezeeta.Application.Contract.WorkingPlaceContracts
{
    public interface IWorkingPlaceRepository : IRepository<WorkingPlace, int>
    {

    }
}
