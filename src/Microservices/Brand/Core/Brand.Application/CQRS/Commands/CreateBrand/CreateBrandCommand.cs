using Brand.Application.Common;
using Brand.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<ResultResponse<BrandDto>>
    {
        public string Name { get; set; }

        public List<Size> Sizes { get; set; }
    }
}
