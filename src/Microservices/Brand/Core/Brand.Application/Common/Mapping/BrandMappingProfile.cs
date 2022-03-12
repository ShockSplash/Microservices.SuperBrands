using AutoMapper;
using Brand.Application.CQRS.Commands.CreateBrand;
using Brand.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.Common.Mapping
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<BrandModel, CreateBrandCommand>().ReverseMap();
            CreateMap<BrandModel, BrandDto>().ReverseMap();
        }
    }
}
