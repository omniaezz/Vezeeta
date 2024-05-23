using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Services.ReviewServices;
using Vezeeta.Dtos.Dtos.ReviewDtos;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceReviewsController : ControllerBase
    {
        private readonly IServiceReviewService _serviceReviewService;

        public ServiceReviewsController(IServiceReviewService serviceReviewService)
        {
            _serviceReviewService = serviceReviewService;
        }

        [HttpGet("GetServiceReviewsAsync")]
        public async Task<IActionResult> GetServiceReviewsAsync(int ServiceId, int ItemsPerPage, int PageNumber)
        {
            if (ModelState.IsValid)
            {
                var doctor = await _serviceReviewService.GetReviewsByServiceIdAsync(ServiceId, ItemsPerPage, PageNumber);
                return Ok(doctor);
            }
            return BadRequest();
        }

        [HttpGet("GetServiceReview")]
        public async Task<IActionResult> GetServiceReview(int ReviewId)
        {
            if (ModelState.IsValid)
            {
                var serviceReview = await _serviceReviewService.GetOneServiceReviewAsync(ReviewId);
                return Ok(serviceReview);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceReviewsAsync(ServiceReviewDto serviceReviewDto)
        {
            if (ModelState.IsValid)
            {
                var ServiceReview = await _serviceReviewService.CreateServiceReviewAsync(serviceReviewDto);
                return Ok(ServiceReview);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctorReviewsAsync(ServiceReviewDto serviceReviewDto)
        {
            if (ModelState.IsValid)
            {
                var ServiceReview = await _serviceReviewService.UpdateServiceReviewAsync(serviceReviewDto);
                return Ok(ServiceReview);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctorReviewsAsync(int serviceReviewId)
        {
            if (ModelState.IsValid)
            {
                var ServiceReview = await _serviceReviewService.DeleteServiceReviewAsync(serviceReviewId);
                return Ok(ServiceReview);
            }
            return BadRequest();
        }
    }
}
