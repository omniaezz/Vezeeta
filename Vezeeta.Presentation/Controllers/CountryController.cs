using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Services.CountryServices;
using Vezeeta.Dtos.Dtos.CountriesDtos;
using Vezeeta.Dtos.Dtos.ReviewDtos;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoutriesAsync(int ItemsPerPage, int PageNumber)
        {
            if (ModelState.IsValid)
            {
                var country = await _countryService.GetAllCoutriesAsync(ItemsPerPage, PageNumber);
                return Ok(country);
            }
            return BadRequest();
        }

        [HttpGet("{CountryId}")]
        public async Task<IActionResult> GetOneCountryAsync(int CountryId)
        {
            if (ModelState.IsValid)
            {
                var country = await _countryService.GetOneCountryAsync(CountryId);
                return Ok(country);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountryAsync(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                var country = await _countryService.CreateCountryAsync(countryDto);
                return Ok(country);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountryAsync(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                var country = await _countryService.UpdateCountryAsync(countryDto);
                return Ok(country);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountryAsync(int CountryId)
        {
            if (ModelState.IsValid)
            {
                var country = await _countryService.DeleteCountryAsync(CountryId);
                return Ok(country);
            }
            return BadRequest();
        }
    }
}
