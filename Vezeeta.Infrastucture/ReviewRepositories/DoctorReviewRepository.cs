using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.ReviewsContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.DoctorModels;

namespace Vezeeta.Infrastucture.ReviewRepositories
{
    public class DoctorReviewRepository : Repository<DoctorReviews,int>, IDoctorReviewRepository
    {
        public DoctorReviewRepository(VezeetaContext vezeetaContext):base(vezeetaContext) { }
    }
}
