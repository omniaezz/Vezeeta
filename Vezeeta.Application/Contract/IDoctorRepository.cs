﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Models;

namespace Vezeeta.Application.Contract
{
    public interface IDoctorRepository : IRepository<Doctor,int>
    {
    }
}
