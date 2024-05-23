using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.SubSpecialtyContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.SubSpecialtiesModels;

namespace Vezeeta.Infrastucture.SubSpecialitiesRepositories
{
    public class SubSpecialtiesRepository : Repository<Subspecialties,int>,ISubSpecialitiesRepository
    {
        public SubSpecialtiesRepository(VezeetaContext vezeetaContext) : base(vezeetaContext) { }
       
    }
}
