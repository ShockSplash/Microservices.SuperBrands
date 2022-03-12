using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.Common
{
    public class ResultResponse<T>
    {
        public string Result { get; set; }

        public T Data { get; set; }
    }
}
