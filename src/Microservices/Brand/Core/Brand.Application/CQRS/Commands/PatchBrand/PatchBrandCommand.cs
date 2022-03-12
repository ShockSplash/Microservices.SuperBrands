using Brand.Application.Common;
using Brand.Application.CQRS.Commands.CreateBrand;
using Brand.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.CQRS.Commands.PatchBrand
{
    public class PatchBrandCommand : IRequest<ResultResponse<BrandDto>>
    {
        public JsonPatchDocument<BrandModel> PatchDocument { get; set; }

        public int Id { get; set; }
    }
}
