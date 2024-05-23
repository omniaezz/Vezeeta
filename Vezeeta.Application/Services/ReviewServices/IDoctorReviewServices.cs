using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Dtos.ReviewDtos;
using Vezeeta.Dtos.ResultDtos;

namespace Vezeeta.Application.Services.ReviewServices
{
    public interface IDoctorReviewServices
    {
        Task<ResultView<DoctorReviewDto>> CreateDoctorReviewAsync(DoctorReviewDto reviewDto);
        Task<ResultView<DoctorReviewDto>> UpdateDoctorReviewAsync(DoctorReviewDto reviewDto);
        Task<ResultView<DoctorReviewDto>> GetOneDoctorReviewAsync(int ReviewId);
        Task<ResultDataList<DoctorReviewDto>> GetReviewsByDoctorIdAsync(int DoctorId,int ItemsPerPage,int PageNumber);
        Task<ResultView<DoctorReviewDto>> DeleteDoctorReviewAsync(int ReviewId);
    }
}
