using Brand.Application.Common;
using Brand.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Queries.GetBrandById
{
    public class GetBrandQuery : IRequest<ResultResponse<BrandModel>>
    {
        public int Id { get; set; }
    }
}
