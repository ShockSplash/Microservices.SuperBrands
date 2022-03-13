using Product.BLL.Dtos;
using Product.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(ProductModel product, CancellationToken token);

        Task<List<ProductModel>> GetAllProducts(CancellationToken token);

        Task<ProductModel> GetProductById(int id, CancellationToken token);

        Task<ProductDto> UpdateProduct(ProductModel product, CancellationToken token);

        Task<ProductDto> PatchProduct(PatchModel model, CancellationToken token);

        Task<int> DeleteProduct(int id, CancellationToken token);

        Task<ResultResponse> GetBrandsAsync();
    }
}
