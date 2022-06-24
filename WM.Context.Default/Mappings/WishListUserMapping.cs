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
    public class WishListUserMapping : IEntityTypeConfiguration<WishListUser>
    {
        public void Configure(EntityTypeBuilder<WishListUser> builder)
        {
            builder.ToTable("WishListUsers");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.UserId)
                   .IsRequired();

            builder.Property(e => e.WishListId)
                   .IsRequired();

            builder.Property(e => e.UserType)
                   .HasMaxLength(20)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasConversion(
                       v => v.ToString(),
                       v => (WishListUserType)Enum.Parse(typeof(WishListUserType), v));


            builder.HasOne(e => e.WishList)
                   .WithMany(e => e.WishListUsers)
                   .HasForeignKey(e => e.WishListId);

            builder.HasOne(e => e.User)
                  .WithMany(e => e.WishListUsers)
                  .HasForeignKey(e => e.UserId);
        }
    }
}
