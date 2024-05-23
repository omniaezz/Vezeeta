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
    public interface IDoctorAppointmentsRepository : IRepository<DoctorAppointments, int>
    {
        Task<IQueryable<Appointment>> GetAppointmentsByDoctorId(int doctorId);
    }
}
