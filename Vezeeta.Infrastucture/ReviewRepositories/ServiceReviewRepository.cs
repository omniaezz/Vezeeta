using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.ReviewsContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.ServicesModels;

namespace Vezeeta.Infrastucture.ReviewRepositories
{
    public class ServiceReviewRepository : Repository<ServiceReviews,int>,IServiceReviewRepository
    {
        public ServiceReviewRepository(VezeetaContext vezeetaContext):base(vezeetaContext) { }
    }
}
