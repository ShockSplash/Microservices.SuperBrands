using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DAL.Common.Exceptions
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
