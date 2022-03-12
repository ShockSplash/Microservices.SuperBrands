using Brand.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Queries.GetAllBrands
{
    public class GetBrandsVm
    {
        public List<BrandModel> Brands { get; set; }
    }
}
