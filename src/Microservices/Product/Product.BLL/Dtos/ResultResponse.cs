using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BLL.Dtos
{
    public class ResultResponse
    {
        public string Result { get; set; }

        public GetBrandsVm Data { get; set; }
    }

    public class GetBrandsVm
    {
        public List<BrandModel> Brands { get; set; }
    }

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

    public class Size
    {
        public int Id { get; set; }

        public string RussianSize { get; set; }

        public string BrandSize { get; set; }
    }
}
