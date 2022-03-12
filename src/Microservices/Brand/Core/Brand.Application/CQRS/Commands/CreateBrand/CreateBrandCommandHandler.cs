using AutoMapper;
using Brand.Application.Common;
using Brand.Application.Common.Exceptions;
using Brand.Application.Services.Interfaces;
using Brand.Domain.Models;
using Brand.Persistance.Data.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ResultResponse<CreateBrandDto>>
    {
        private readonly IBrandsDbContext _context;

        private readonly IMapper _mapper;

        private readonly ISizeValidationService _sizeValidationService;

        public CreateBrandCommandHandler(IBrandsDbContext context, IMapper mapper, ISizeValidationService sizeValidationService)
        {
            _context = context;
            _mapper = mapper;
            _sizeValidationService = sizeValidationService;
        }


        public async Task<ResultResponse<CreateBrandDto>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<BrandModel>(request);

            if (!_sizeValidationService.Validaite(brand.Sizes))
            {
                throw new BadDataException("Identical Russian sizes were found.");
            }

            await _context.Brands.AddAsync(brand, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResultResponse<CreateBrandDto>
            {
                Result = "Success",
                Data = _mapper.Map<CreateBrandDto>(brand)
            };
        }
    }
}
