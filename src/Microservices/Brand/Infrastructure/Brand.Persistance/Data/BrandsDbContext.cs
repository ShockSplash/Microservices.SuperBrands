using Brand.Domain.Models;
using Brand.Persistance.Data.Interfaces;
using Brand.Persistance.FluentApiConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Persistance.Data
{
    public class BrandsDbContext : DbContext, IBrandsDbContext
    {
        public BrandsDbContext(DbContextOptions<BrandsDbContext> options) : base(options)
        {

        }

        public DbSet<Brands> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Brands>(new BrandsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
