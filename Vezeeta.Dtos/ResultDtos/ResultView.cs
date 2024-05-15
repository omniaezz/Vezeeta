using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Dtos.ResultDtos
{
    public class ResultView<TEntity>
    {
        public TEntity Entity { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
