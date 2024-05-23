using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Services.ReviewServices;
using Vezeeta.Dtos.Dtos.ReviewDtos;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorReviewsController : ControllerBase
    {
        private readonly IDoctorReviewServices _doctorReviewServices;

        public DoctorReviewsController(IDoctorReviewServices doctorReviewServices)
        {
            _doctorReviewServices = doctorReviewServices;
        }

        [HttpGet("GetDoctorReviews")]
        public async Task<IActionResult> GetDoctorReviewsAsync(int DoctorId, int ItemsPerPage, int PageNumber)
        {
            if (ModelState.IsValid)
            {
                var doctor = await _doctorReviewServices.GetReviewsByDoctorIdAsync(DoctorId,ItemsPerPage,PageNumber);
                return Ok(doctor);
            }
            return BadRequest();
        }
        
        [HttpGet("GetDoctorReview")]
        public async Task<IActionResult> GetDoctorReview(int ReviewId)
        {
            if (ModelState.IsValid)
            {
                var doctor = await _doctorReviewServices.GetOneDoctorReviewAsync(ReviewId);
                return Ok(doctor);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorReviewsAsync(DoctorReviewDto doctorReviewDto)
        {
            if (ModelState.IsValid)
            {
                var doctorReview = await _doctorReviewServices.CreateDoctorReviewAsync(doctorReviewDto);
                return Ok(doctorReview);
            }
            return BadRequest();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateDoctorReviewsAsync(DoctorReviewDto doctorReviewDto)
        {
            if (ModelState.IsValid)
            {
                var doctorReview = await _doctorReviewServices.UpdateDoctorReviewAsync(doctorReviewDto);
                return Ok(doctorReview);
            }
            return BadRequest();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctorReviewsAsync(int doctorReviewId)
        {
            if (ModelState.IsValid)
            {
                var doctorReview = await _doctorReviewServices.DeleteDoctorReviewAsync(doctorReviewId);
                return Ok(doctorReview);
            }
            return BadRequest();
        }

    }
}
