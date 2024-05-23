using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Dtos.Dtos.CountriesDtos
{
    public class CountryImagesDto
    {
        public int Id { get; set; }
        public string CountriesImagesPath { get; set; }
        public int CountriesId { get; set; }
    }
}
