using Brand.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistace(this IServiceCollection services)
        {
            services.AddDbContext<BrandsDbContext>(options => options.UseInMemoryDatabase("Brands"));
        }
    }
}
