using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Context.Default.Entities;
using WM.CrossCutting.Enums;

namespace WM.Context.Default.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.UserType)
                   .HasMaxLength(20)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasConversion(
                       v => v.ToString(),
                       v => (UserType)Enum.Parse(typeof(UserType), v));

            builder.Property(e => e.Email)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.ImageProfile)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(500);

            builder.Property(e => e.Login)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100);

            builder.Property(e => e.Password)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.CreatedDate)
                   .HasColumnType("datetime");

            builder.HasMany(e => e.UserRoles)
                   .WithOne(e => e.User)
                   .HasForeignKey(e => e.UserId);

            builder.HasMany(e => e.WishLists)
                  .WithOne(e => e.User)
                  .HasForeignKey(e => e.UserId);
        }
    }
}
