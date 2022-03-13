using Microsoft.AspNetCore.JsonPatch;
using Product.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BLL.Dtos
{
    public class PatchModel
    {
        public JsonPatchDocument<ProductModel> PatchDocument { get; set; }

        public int Id { get; set; }
    }
}
