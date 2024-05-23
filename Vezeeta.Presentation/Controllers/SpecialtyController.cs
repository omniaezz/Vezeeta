using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Services.SpecialtyServices;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.Dtos.SpecialtyDtos;
using Vezeeta.Models;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet("GetSpecialtiesAsync")]
        public async Task<IActionResult> GetSpecialtiesAsync(int ItemsPerPage, int PageNumber)
        {
            if (ModelState.IsValid)
            {
                var doctor = await _specialtyService.GetAllSpecialtiesAsync(ItemsPerPage,PageNumber);
                return Ok(doctor);
            }
            return BadRequest();
        }

        [HttpGet("GetSpecialty")]
        public async Task<IActionResult> GetSpecialty(int SpecialtyId)
        {
            if (ModelState.IsValid)
            {
                var specialty = await _specialtyService.GetOneSpecialtyByIdAsync(SpecialtyId);
                return Ok(specialty);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialtyAsync(SpecialtyDto specialtyDto)
        {
            if (ModelState.IsValid)
            {
                var specialty = await _specialtyService.CreateSpecialtyAsync(specialtyDto);
                return Ok(specialty);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialtyAsync(SpecialtyDto specialtyDto)
        {
            if (ModelState.IsValid)
            {
                var specialty = await _specialtyService.UpdateSpecialtyAsync(specialtyDto);
                return Ok(specialty);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialtyAsync(int SpecialtyId)
        {
            if (ModelState.IsValid)
            {
                var specialty = await _specialtyService.DeleteSpecialtyAsync(SpecialtyId);
                return Ok(specialty);
            }
            return BadRequest();
        }
    }
}
