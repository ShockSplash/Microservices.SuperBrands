using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DAL.Entities
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public string RussianSize { get; set; }

        public bool IsDeleted { get; set; }
    }
}
