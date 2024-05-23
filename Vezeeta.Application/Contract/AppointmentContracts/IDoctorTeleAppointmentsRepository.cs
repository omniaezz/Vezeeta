using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.AppointmentModels;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Application.Contract.AppointmentContracts
{
    public interface IDoctorTeleAppointmentsRepository : IRepository<DoctorTeleAppointments, int>
    {
        Task<IQueryable<Appointment>> GetTeleAppointmentsByDoctorId(int doctorId);
    }
}
