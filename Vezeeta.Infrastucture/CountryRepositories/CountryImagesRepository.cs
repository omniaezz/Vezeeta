using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.CountryContracts;
using Vezeeta.Context;
using Vezeeta.Infrastucture.GenericeRepository;
using Vezeeta.Models.CountryModels;

namespace Vezeeta.Infrastucture.CountryRepositories
{
    public class CountryImagesRepository : Repository<CountriesImages,int>,ICountryImagesRepostiory
    {
        public CountryImagesRepository(VezeetaContext vezeetaContext) : base(vezeetaContext) { }
    }
}
