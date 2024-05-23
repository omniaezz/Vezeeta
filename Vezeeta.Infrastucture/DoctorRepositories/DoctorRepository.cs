using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.DoctorContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Infrastucture.DoctorRepositories
{
    public class DoctorRepository : Repository<Doctor, int>, IDoctorRepository
    {
        public DoctorRepository(VezeetaContext vezeetaContext) : base(vezeetaContext)
        {
        }
    }
}
