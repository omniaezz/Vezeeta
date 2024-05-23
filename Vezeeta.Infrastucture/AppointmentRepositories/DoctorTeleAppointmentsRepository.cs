using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.AppointmentContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.AppointmentModels;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Infrastucture.AppointmentRepositories
{
    public class DoctorTeleAppointmentsRepository : Repository<DoctorTeleAppointments, int>, IDoctorTeleAppointmentsRepository
    {
        private readonly VezeetaContext _vezeetaContext;

        public DoctorTeleAppointmentsRepository(VezeetaContext vezeetaContext) : base(vezeetaContext)
        {
            _vezeetaContext = vezeetaContext;
        }

        public Task<IQueryable<Appointment>> GetTeleAppointmentsByDoctorId(int doctorId)
        {
            return Task.FromResult(from da in _vezeetaContext.DoctorTeleAppointments
                                   join a in _vezeetaContext.Appointments on da.AppointmentId equals a.Id
                                   where da.DoctorId == doctorId
                                   select a);
        }
    }
}
