using Microsoft.AspNetCore.Mvc;
using Product.BLL;
using Product.BLL.Dtos;
using Product.BLL.Services.Interfaces;
using Product.DAL.Data;
using Product.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.PL.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _serivce;

        private readonly ProductDbContext _context;

        public ProductController(IProductService service, ProductDbContext context)
        {
            _serivce = service;
            _context = context;
        }

        [HttpPost("product")]
        public async Task<ProductDto> CreateProduct(ProductModel model, CancellationToken token)
        {
            return await _serivce.CreateProduct(model, token);
        }

        [HttpGet("product")]
        public async Task<List<ProductModel>> GetProducts(CancellationToken token)
        {
            return await _serivce.GetAllProducts(token);
        }

        [HttpGet("product/{id}")]
        public async Task<ProductModel> GetProductById(int id, CancellationToken token)
        {
            return await _serivce.GetProductById(id, token);
        }

        [HttpPut("product")]
        public async Task<ProductDto> UpdateProduct(ProductModel model, CancellationToken token)
        {
            return await _serivce.UpdateProduct(model, token);
        }

        [HttpPatch("product")]
        public async Task<ProductDto> PatchProduct(PatchModel model, CancellationToken token)
        {
            return await _serivce.PatchProduct(model, token);
        }

        [HttpDelete("patch")]
        public async Task<int> DeleteProduct(int id, CancellationToken token)
        {
            return await _serivce.DeleteProduct(id, token);
        }
    }
}
