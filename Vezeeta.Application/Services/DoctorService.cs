using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract;
using Vezeeta.Dtos.Dtos.DoctorDto;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public Task<ResultView<DoctorDto>> CreateDoctor(DoctorDto doctor)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<DoctorDto>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataList<DoctorDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<DoctorDto>> GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<DoctorDto>> Update(DoctorDto doctor)
        {
            throw new NotImplementedException();
        }
    }
}
