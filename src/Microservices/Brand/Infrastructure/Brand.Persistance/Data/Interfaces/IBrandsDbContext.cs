using Brand.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brand.Persistance.Data.Interfaces
{
    public interface IBrandsDbContext
    {
        DbSet<Domain.Models.BrandModel> Brands { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
