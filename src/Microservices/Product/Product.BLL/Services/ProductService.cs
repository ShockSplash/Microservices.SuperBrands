using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Product.BLL.Dtos;
using Product.BLL.Services.Interfaces;
using Product.DAL.Common.Exceptions;
using Product.DAL.Data;
using Product.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> CreateProduct(ProductModel product, CancellationToken token)
        {
            ResultResponse response;

            try
            {
                response = await GetBrandsAsync();
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Not Found"))
                {
                    throw new NotFoundException($"Brand with name: {product.Name} not found");
                }

                throw new Exception(exception.Message);
            }

            var brand = response.Data.Brands.FirstOrDefault(brand => brand.Name == product.BrandName);

            if (brand == null)
            {
                throw new NotFoundException($"Brand with name: {product.Name} not found.");
            }

            foreach (var size in brand.Sizes)
            {
                if(size.RussianSize == product.RussianSize)
                {
                    throw new BadDataException($"Brand : {brand.Name} already has russian size: {size.RussianSize}");
                }
            }

            await _context.Products.AddAsync(product, token);

            await _context.SaveChangesAsync(token);

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                RussianSize = product.RussianSize,
            };
        }

        public async Task<int> DeleteProduct(int id, CancellationToken token)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id, token);

            if (product == null)
            {
                throw new NotFoundException($"Product with id: {id} nto found.");
            }

            product.IsDeleted = true;

            await _context.SaveChangesAsync(token);

            return product.Id;
        }

        public async Task<List<ProductModel>> GetAllProducts(CancellationToken token)
        {
            var products = await _context.Products.IgnoreQueryFilters().ToListAsync(token);

            if(products.Count == 0)
            {
                throw new NotFoundException($"Products not found.");
            }

            return products;
        }

        public async Task<ResultResponse> GetBrandsAsync()
        {
            using (var client = new HttpClient())
            {
                var items = await client.GetStringAsync($"http://localhost:5000/api/brand");
                var result = JsonConvert.DeserializeObject<ResultResponse>(items);
                return result;
            }
        }

        public async Task<ProductModel> GetProductById(int id, CancellationToken token)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new NotFoundException($"Product with id: {id} not found.");
            }

            return product;
        }

        public async Task<ProductDto> PatchProduct(PatchModel model, CancellationToken token)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == model.Id, token);

            if (product == null)
            {
                throw new NotFoundException($"Product with id: {model.Id} not found");
            }

            model.PatchDocument.ApplyTo(product);

            await _context.SaveChangesAsync(token);

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                RussianSize = product.RussianSize,
            };
        }

        public async Task<ProductDto> UpdateProduct(ProductModel product, CancellationToken token)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(product => product.Id == product.Id, token);

            if(productEntity == null)
            {
                throw new NotFoundException($"Product with id: {product.Id} not found");
            }

            productEntity.Name = product.Name;
            productEntity.BrandName = product.Name;
            productEntity.RussianSize = product.RussianSize;

            await _context.SaveChangesAsync(token);

            return new ProductDto()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                RussianSize = productEntity.RussianSize
            };
        }
    }
}
