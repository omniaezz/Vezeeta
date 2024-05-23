using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.ReviewServices
{
    public interface IServiceReviewService
    {
        Task<ResultView<ServiceReviewDto>> CreateServiceReviewAsync(ServiceReviewDto reviewDto);
        Task<ResultView<ServiceReviewDto>> UpdateServiceReviewAsync(ServiceReviewDto reviewDto);
        Task<ResultView<ServiceReviewDto>> GetOneServiceReviewAsync(int ReviewId);
        Task<ResultDataList<ServiceReviewDto>> GetReviewsByServiceIdAsync(int ServiceId, int ItemsPerPage, int PageNumber);
        Task<ResultView<ServiceReviewDto>> DeleteServiceReviewAsync(int ReviewId);
    }
}
