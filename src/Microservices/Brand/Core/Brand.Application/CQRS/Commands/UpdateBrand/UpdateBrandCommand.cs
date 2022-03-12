using Brand.Application.Common;
using Brand.Application.CQRS.Commands.CreateBrand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<ResultResponse<BrandDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
