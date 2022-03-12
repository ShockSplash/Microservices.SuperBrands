using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Domain.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Size> Sizes { get; set; }

        public bool IsDeleted { get; set; }

        public BrandModel()
        {
            Sizes = new List<Size>();
        }
    }
}
