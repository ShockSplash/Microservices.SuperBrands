using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.Common.Exceptions
{
    public class BadDataException : Exception
    {
        public BadDataException(object errors = null)
        {
            Errors = errors;
        }
        public object Errors { get; set; }
    }
}

