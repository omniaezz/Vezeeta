using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Services.SubSpecialtiesServices;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.Dtos.SubSpecialitiesDtos;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSpecialtyController : ControllerBase
    {
        private readonly ISubSpecialtieService _subSpecialtieService;

        public SubSpecialtyController(ISubSpecialtieService subSpecialtieService)
        {
            _subSpecialtieService  = subSpecialtieService;
        }


        [HttpGet("GetSubSpecialtiesBySpecialtyIdAsync")]
        public async Task<IActionResult> GetSubSpecialtiesBySpecialtyIdAsync(int SpecialtyId)
        {
            if (ModelState.IsValid)
            {
                var SubSpecialties = await _subSpecialtieService.GetSubSpecialtiesBySpecialtyIdAsync(SpecialtyId);
                return Ok(SubSpecialties);
            }
            return BadRequest();
        }

        [HttpGet("GetServiceReview")]
        public async Task<IActionResult> GetServiceReview(int SubSpecialtyId)
        {
            if (ModelState.IsValid)
            {
                var subSpecialty = await _subSpecialtieService.GetOneSubSpecialtyByIdAsync(SubSpecialtyId);
                return Ok(subSpecialty);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubSpecialtyAsync(SubSpecialitiesDto subSpecialitiesDto)
        {
            if (ModelState.IsValid)
            {
                var subSpecialty = await _subSpecialtieService.CreateSubSpecialtyAsync(subSpecialitiesDto);
                return Ok(subSpecialty);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubSpecialtyAsync(SubSpecialitiesDto subSpecialitiesDto)
        {
            if (ModelState.IsValid)
            {
                var subSpecialty = await _subSpecialtieService.UpdateSubSpecialtyAsync(subSpecialitiesDto);
                return Ok(subSpecialty);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubSpecialtyAsync(int SubSpecialtyId)
        {
            if (ModelState.IsValid)
            {
                var subSpecialty = await _subSpecialtieService.DeleteSubSpecialtyAsync(SubSpecialtyId);
                return Ok(subSpecialty);
            }
            return BadRequest();
        }
    }
}
