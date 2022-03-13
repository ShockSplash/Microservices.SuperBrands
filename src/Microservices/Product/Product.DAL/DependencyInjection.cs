using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DAL
{
    public static class DependencyInjection
    {
        public static void AddPersistace(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase("Products"));
        }
    }
}
