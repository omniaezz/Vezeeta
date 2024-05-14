using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Models
{
    public class CountriesImages : BaseEntity
    {
        public string CountriesImagesPath { get; set; }

        [ForeignKey("Countries")]
        public int CountriesId { get; set; }
        public Countries Countries { get; set; }
    }
}
