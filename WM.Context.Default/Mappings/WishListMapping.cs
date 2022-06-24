using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Context.Default.Entities;

namespace WM.Context.Default.Mappings
{
    public class WishListMapping : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.ToTable("WishLists");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(e => e.Quantity)
                  .HasDefaultValue(0)
                  .IsRequired();

            builder.Property(e => e.CreatedDate)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(e => e.TotalPrice)
                   .HasPrecision(6, 2);

            builder.Property(e => e.UserId)
                   .IsRequired();

            builder.HasMany(e => e.WishListUsers)
                   .WithOne(e => e.WishList)
                   .HasForeignKey(e => e.WishListId);

            builder.HasMany(e => e.Products)
                   .WithOne(e => e.WishList)
                   .HasForeignKey(e => e.WishListId);
        }
    }
}
