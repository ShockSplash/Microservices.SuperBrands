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
    public class SizesConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(size => size.RussianSize).HasMaxLength(6);
            builder.Property(size => size.BrandSize).HasMaxLength(6);
        }
    }
}
