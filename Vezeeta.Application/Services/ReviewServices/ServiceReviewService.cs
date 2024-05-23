using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.ReviewsContracts;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.ResultDtos;
using Vezeeta.Models.ServicesModels;

namespace Vezeeta.Application.Services.ReviewServices
{
    public class ServiceReviewService : IServiceReviewService
    {
        private readonly IServiceReviewRepository _serviceReviewRepository;
        private readonly IMapper _mapper;

        public ServiceReviewService(IServiceReviewRepository serviceReviewRepository ,IMapper mapper)
        {
            _serviceReviewRepository = serviceReviewRepository;
            _mapper = mapper;
        }
        public async Task<ResultView<ServiceReviewDto>> CreateServiceReviewAsync(ServiceReviewDto reviewDto)
        {
            var review = _mapper.Map<ServiceReviews>(reviewDto);
            var CreatedReview = await _serviceReviewRepository.CreateAsync(review);
            await _serviceReviewRepository.SaveChangesAsync();
            return new ResultView<ServiceReviewDto>
            {
                Entity = _mapper.Map<ServiceReviewDto>(CreatedReview),
                IsSuccess = true,
                Message = "Review Created Successfully"
            };
        }

        public async Task<ResultView<ServiceReviewDto>> DeleteServiceReviewAsync(int ReviewId)
        {
            var ExistingReview = await _serviceReviewRepository.GetByIdAsync(ReviewId);
            if (ExistingReview is null)
            {
                return new ResultView<ServiceReviewDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Review Doesn't Exist"
                };
            }

            ExistingReview.IsDeleted = true;
            await _serviceReviewRepository.SaveChangesAsync();
            return new ResultView<ServiceReviewDto>
            {
                Entity = _mapper.Map<ServiceReviewDto>(ExistingReview),
                IsSuccess = true,
                Message = "Review Deleted Successfully"
            };
        }

        public async Task<ResultView<ServiceReviewDto>> GetOneServiceReviewAsync(int ReviewId)
        {
            var ExistingReview = await _serviceReviewRepository.GetByIdAsync(ReviewId);
            if (ExistingReview is null)
            {
                return new ResultView<ServiceReviewDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "Review Doesn't Exist"
                };
            }

            return new ResultView<ServiceReviewDto>
            {
                Entity = _mapper.Map<ServiceReviewDto>(ExistingReview),
                IsSuccess = true,
                Message = "Review Retrieved Successfully"
            };
        }

        public async Task<ResultDataList<ServiceReviewDto>> GetReviewsByServiceIdAsync(int ServiceId, int ItemsPerPage, int PageNumber)
        {
            var GetAllReviews = (await _serviceReviewRepository.GetAllAsync())
                                .Where(s => s.ServiceId == ServiceId && s.IsDeleted == false)
                                .ToList();
            if (GetAllReviews is null)
            {
                return new ResultDataList<ServiceReviewDto>
                {
                    Entites = null,
                    Count = 0
                };
            }

            var PaginatedReviews = GetAllReviews
                                   .Skip(ItemsPerPage * (PageNumber - 1))
                                   .Take(ItemsPerPage)
                                   .ToList();
            return new ResultDataList<ServiceReviewDto>
            {
                Entites = _mapper.Map<List<ServiceReviewDto>>(PaginatedReviews),
                Count = GetAllReviews.Count()
            };
        }

        public async Task<ResultView<ServiceReviewDto>> UpdateServiceReviewAsync(ServiceReviewDto reviewDto)
        {
            var review = _mapper.Map<ServiceReviews>(reviewDto);
            await _serviceReviewRepository.UpdateAsync(review);
            await _serviceReviewRepository.SaveChangesAsync();
            return new ResultView<ServiceReviewDto>
            {
                Entity = _mapper.Map<ServiceReviewDto>(review),
                IsSuccess = true,
                Message = "Review Updated Successfully"
            };
        }
    }
}
