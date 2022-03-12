using Brand.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Queries.GetAllBrands
{
    public class GetBrandsQuery : IRequest<ResultResponse<GetBrandsVm>>
    {
        public int Id { get; set; }
    }
}
