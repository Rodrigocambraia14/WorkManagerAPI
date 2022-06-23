using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Context.Default.Entities;
using WM.CrossCutting.Enums;

namespace WM.Context.Default.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(e => e.Link)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(600);

            builder.Property(e => e.Quantity)
                  .HasDefaultValue(1)
                  .IsRequired();

            builder.Property(e => e.TotalPrice)
                   .HasPrecision(6, 2);

            builder.Property(e => e.Price)
                   .HasPrecision(6, 2);

            builder.Property(e => e.CreatedDate)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(e => e.Status)
                   .HasMaxLength(20)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasConversion(
                       v => v.ToString(),
                       v => (ProductType)Enum.Parse(typeof(ProductType), v));

            builder.Property(e => e.WishListId)
                   .IsRequired();

            builder.HasOne(e => e.WishList)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.WishListId);
        }
    }
}
