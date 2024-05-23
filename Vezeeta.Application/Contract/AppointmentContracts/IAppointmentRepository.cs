using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.AppointmentModels;

namespace Vezeeta.Application.Contract.AppointmentContracts
{
    public interface IAppointmentRepository : IRepository<Appointment, int>
    {
    }
}
