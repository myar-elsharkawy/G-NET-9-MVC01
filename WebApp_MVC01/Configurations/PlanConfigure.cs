using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp_MVC01.Models;

namespace WebApp_MVC01.Configurations
{
    public class PlanConfigure : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(30);

            builder.Property(p => p.Description)
                   .HasMaxLength(200);

            builder.Property(p => p.Price)
                    .HasPrecision(10, 2);

            builder.Property(p => p.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

            builder.ToTable(p =>
            {
                p.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 365");
            });
        }
    }
}
