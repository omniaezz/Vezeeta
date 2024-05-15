using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Dtos.ResultDtos
{
    public class ResultDataList<TEntity>
    {
        public List<TEntity> Entites { get; set; }
        public int Count { get; set; }
    }
}
