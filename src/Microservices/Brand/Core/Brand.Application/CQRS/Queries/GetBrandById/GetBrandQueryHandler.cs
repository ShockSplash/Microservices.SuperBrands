using Brand.Application.Common;
using Brand.Application.Common.Exceptions;
using Brand.Domain.Models;
using Brand.Persistance.Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Queries.GetBrandById
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, ResultResponse<BrandModel>>
    {
        private readonly IBrandsDbContext _context;

        public GetBrandQueryHandler(IBrandsDbContext context)
        {
            _context = context;
        }

        public async Task<ResultResponse<BrandModel>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (brand == null)
            {
                throw new NotFoundException($"Brand with id: {request.Id} not found");
            }

            return new ResultResponse<BrandModel>()
            {
                Result = "Success",
                Data = brand
            };
        }
    }
}
