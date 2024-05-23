using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Services.DoctorServices;
using Vezeeta.Dtos.Dtos.DoctorDtos;

namespace Vezeeta.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateOrUpdateDoctorDto doctorDto)
        {
            if(ModelState.IsValid)
            {
                var doctor = await _doctorService.CreateDoctor(doctorDto);
                return Ok(doctor);
            }
            return BadRequest();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(CreateOrUpdateDoctorDto doctorDto)
        {
            if(ModelState.IsValid)
            {
                var doctor = await _doctorService.Update(doctorDto);
                return Ok(doctor);
            }
            return BadRequest();
        }
        
        [HttpGet("GetDoctor")]
        public async Task<IActionResult> GetDoctor(int DoctorId)
        {
            if(ModelState.IsValid)
            {
                var doctor = await _doctorService.GetOne(DoctorId);
                return Ok(doctor);
            }
            return BadRequest();
        }
        
        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors(int ItemsPerPage, int PageNumber)
        {
            if(ModelState.IsValid)
            {
                var Doctors = await _doctorService.GetAll(ItemsPerPage, PageNumber);
                return Ok(Doctors);
            }
            return BadRequest();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int DoctorId)
        {
            if(ModelState.IsValid)
            {
                var doctor = await _doctorService.Delete(DoctorId);
                return Ok(doctor);
            }
            return BadRequest();
        }
    }
}
