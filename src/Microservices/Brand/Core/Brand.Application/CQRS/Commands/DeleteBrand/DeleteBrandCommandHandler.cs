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

namespace Brand.Application.CQRS.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, ResultResponse<Unit>>
    {
        private readonly IBrandsDbContext _context;

        public DeleteBrandCommandHandler(IBrandsDbContext context)
        {
            _context = context;
        }

        public async Task<ResultResponse<Unit>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (brand == null)
            {
                throw new NotFoundException($"Brand with id: {request.Id} not found.");
            }

            brand.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return new ResultResponse<Unit>()
            {
                Result = "Success"
            };
        }
    }
}
