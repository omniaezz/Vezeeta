using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract;
using Vezeeta.Context;
using Vezeeta.Models;

namespace Vezeeta.Infrastucture
{
    public class DoctorRepository : Repository<Doctor,int>,IDoctorRepository
    {
        private readonly VezeetaContext _vezeetaContext;
        public DoctorRepository(VezeetaContext vezeetaContext):base(vezeetaContext)
        {

            _vezeetaContext = vezeetaContext;
        }
    }
}
