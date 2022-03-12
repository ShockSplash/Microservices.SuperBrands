using AutoMapper;
using Brand.Application.Common;
using Brand.Application.Common.Exceptions;
using Brand.Application.CQRS.Commands.CreateBrand;
using Brand.Persistance.Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Commands.PatchBrand
{
    public class PatchBrandCommandHandler : IRequestHandler<PatchBrandCommand, ResultResponse<BrandDto>>
    {
        private readonly IBrandsDbContext _context;

        private readonly IMapper _mapper;

        public PatchBrandCommandHandler(IBrandsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultResponse<BrandDto>> Handle(PatchBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (brand == null)
            {

                throw new NotFoundException($"Brand with id: {request.Id} not found");
            }

            request.PatchDocument.ApplyTo(brand);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResultResponse<BrandDto>()
            {
                Result = "Success",
                Data = _mapper.Map<BrandDto>(brand)
            };
        }
    }
}
