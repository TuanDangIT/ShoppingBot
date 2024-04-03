using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar(20)")
                .IsRequired();
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.ServerId);
            builder.Property(x => x.Description)
                .HasColumnType("varchar(200)");
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Product);
        }
    }
}
