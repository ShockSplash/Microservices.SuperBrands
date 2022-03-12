using Brand.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Persistance.FluentApiConfiguration
{
    public class BrandsConfiguration : IEntityTypeConfiguration<Domain.Models.BrandModel>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.BrandModel> builder)
        {
            builder.Property(builder => builder.Name).HasMaxLength(256);
            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
