using GymManagment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Configurations
{
    // for member and trainer
    public class GymUserConfigure<T> : IEntityTypeConfiguration<T> where T : GymUser
    {

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(50);

            builder.Property(builder => builder.Email).HasColumnType("varchar").HasMaxLength(100);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("EmailCheck", "Email LIKE '_%@_%._%'");
                tb.HasCheckConstraint("PhoneCheck", "Phone LIKE '010' or Phone LIKE '011' or Phone LIKE '012' or Phone LIKE '015'");
            }
            );

            builder.OwnsOne(x => x.Address, address =>
            {
              address.Property(x => x.Street).HasColumnName("Street").HasColumnType("varchar").HasMaxLength(30);
              address.Property(x => x.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(30);
            });
        }
    }
}