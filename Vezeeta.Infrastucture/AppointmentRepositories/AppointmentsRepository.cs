using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.AppointmentContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.AppointmentModels;

namespace Vezeeta.Infrastucture.AppointmentRepositories
{
    public class AppointmentsRepository : Repository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentsRepository(VezeetaContext vezeetaContext) : base(vezeetaContext)
        {
        }
    }
}
