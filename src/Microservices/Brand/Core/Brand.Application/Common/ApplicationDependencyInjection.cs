using Brand.Application.CQRS.Commands.CreateBrand;
using Brand.Application.Services;
using Brand.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.Common
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BrandDto));

            services.AddTransient<ISizeValidationService, SizeValidationService>();
        }
    }
}
