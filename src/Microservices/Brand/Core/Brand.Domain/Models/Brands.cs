using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Domain.Models
{
    public class Brands
    {
        public string Name { get; set; }

        public List<Size> Sizes { get; set; }

        public Brands()
        {
            Sizes = new List<Size>();
        }
    }
}
