using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.Reward).IsRequired().HasDefaultValue(0.0);

            builder.HasOne(x => x.OrderSpeed)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.OrderSpeedId);

            builder.HasOne(x => x.Area)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AreaId);

            builder.HasOne(x => x.Customer);

            builder.HasOne(x => x.Worker);

            builder.HasOne(x => x.Result)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.ResultId);
        }
    }
}
