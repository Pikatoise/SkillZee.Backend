using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class OrderSpeedConfiguration: IEntityTypeConfiguration<OrderSpeed>
    {
        public void Configure(EntityTypeBuilder<OrderSpeed> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
            builder.Property(x => x.RewardMultiplier).IsRequired().HasDefaultValue(1.0);
        }
    }
}
