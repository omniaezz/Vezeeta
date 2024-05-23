using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Models.CountryModels;

namespace Vezeeta.Application.Contract.CountryContracts
{
    public interface ICountryImagesRepostiory : IRepository<CountriesImages, int>
    {
    }
}
