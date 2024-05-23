using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.ReviewsContracts;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.ResultDtos;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Application.Services.ReviewServices
{
    public class DoctorReviewServices : IDoctorReviewServices
    {
        private readonly IDoctorReviewRepository _doctorReviewRepository;
        private readonly IMapper _mapper;

        public DoctorReviewServices(IDoctorReviewRepository doctorReviewRepository, IMapper mapper)
        {
            _doctorReviewRepository = doctorReviewRepository;
            _mapper = mapper;
        }

        public async Task<ResultView<DoctorReviewDto>> CreateDoctorReviewAsync(DoctorReviewDto reviewDto)
        {
            var review = _mapper.Map<DoctorReviews>(reviewDto);
            var CreatedReview = await _doctorReviewRepository.CreateAsync(review);
            await _doctorReviewRepository.SaveChangesAsync();
            return new ResultView<DoctorReviewDto>
            {
                Entity = _mapper.Map<DoctorReviewDto>(CreatedReview),
                IsSuccess = true,
                Message = "Review Created Successfully"
            };
        }

        public async Task<ResultView<DoctorReviewDto>> DeleteDoctorReviewAsync(int ReviewId)
        {
            var ExistingReview = await _doctorReviewRepository.GetByIdAsync(ReviewId);
            if (ExistingReview is null) 
            {
                return new ResultView<DoctorReviewDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Review Doesn't Exist"
                };
            }

            ExistingReview.IsDeleted = true;
            await _doctorReviewRepository.SaveChangesAsync();
            return new ResultView<DoctorReviewDto>
            {
                Entity = _mapper.Map<DoctorReviewDto>(ExistingReview),
                IsSuccess = true,
                Message = "Review Deleted Successfully"
            };

        }

        public async Task<ResultView<DoctorReviewDto>> GetOneDoctorReviewAsync(int ReviewId)
        {
            var ExistingReview = await _doctorReviewRepository.GetByIdAsync(ReviewId);
            if(ExistingReview is null)
            {
                return new ResultView<DoctorReviewDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Review Doesn't Exist"
                };
            }

            return new ResultView<DoctorReviewDto>
            {
                Entity = _mapper.Map<DoctorReviewDto>(ExistingReview),
                IsSuccess = true,
                Message = "Review Retrieved Successfully"
            };
        }

        public async Task<ResultDataList<DoctorReviewDto>> GetReviewsByDoctorIdAsync(int DoctorId, int ItemsPerPage, int PageNumber)
        {
            var GetAllReviews = (await _doctorReviewRepository.GetAllAsync())
                                .Where(r => r.DoctorId == DoctorId && r.IsDeleted == false)
                                .ToList();
            if(GetAllReviews is null)
            {
                return new ResultDataList<DoctorReviewDto>
                {
                    Entites = null,
                    Count = 0
                };
            }

            var PaginatedReviews = GetAllReviews
                                   .Skip(ItemsPerPage * (PageNumber - 1))
                                   .Take(ItemsPerPage)
                                   .ToList();
            return new ResultDataList<DoctorReviewDto>
            {
                Entites = _mapper.Map<List<DoctorReviewDto>>(PaginatedReviews),
                Count = GetAllReviews.Count()
            };

        }

        public async Task<ResultView<DoctorReviewDto>> UpdateDoctorReviewAsync(DoctorReviewDto reviewDto)
        {
            var review = _mapper.Map<DoctorReviews>(reviewDto);
            await _doctorReviewRepository.UpdateAsync(review);
            await _doctorReviewRepository.SaveChangesAsync();
            return new ResultView<DoctorReviewDto>
            {
                Entity = _mapper.Map<DoctorReviewDto>(review),
                IsSuccess = true,
                Message = "Review Updated Successfully"
            };
        }
    }
}
