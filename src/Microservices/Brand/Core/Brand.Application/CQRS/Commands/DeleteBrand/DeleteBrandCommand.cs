using Brand.Application.Common;
using Brand.Application.CQRS.Commands.CreateBrand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<ResultResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
