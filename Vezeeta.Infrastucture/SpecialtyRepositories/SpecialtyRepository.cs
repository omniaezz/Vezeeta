using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.SpecialtyContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.SpecialtyModels;

namespace Vezeeta.Infrastucture.SpecialtyRepositories
{
    public class SpecialtyRepository : Repository<Specialty,int>,ISpecialtyRepository
    {
        public SpecialtyRepository(VezeetaContext vezeetaContext) : base(vezeetaContext) { }
    }
}
