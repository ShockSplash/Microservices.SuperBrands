using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Brand.Application.CQRS.Queries.GetAllBrands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, ResultResponse<GetBrandsVm>>
    {
        private readonly IBrandsDbContext _context;

        private readonly IMapper _mapper;

        public GetBrandsQueryHandler(IBrandsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultResponse<GetBrandsVm>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.IgnoreQueryFilters()
                .Include(b => b.Sizes)
                .ToListAsync(cancellationToken);

            if (brands.Count == 0)
            {
                throw new NotFoundException("No brands found!");
            }

            return new ResultResponse<GetBrandsVm>()
            {
                Result = "Success",
                Data = new GetBrandsVm()
                {
                    Brands = brands
                }
            };
        }
    }
}
