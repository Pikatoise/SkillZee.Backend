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

            builder.HasData(new List<OrderSpeed>()
            {
                new OrderSpeed()
                {
                    Id = Guid.Parse("019f5b79-1fe2-435d-99f3-837e38047036"),
                    CreatedAt = new DateTime(2025 ,01 ,15 ,12 ,0 ,0 ,DateTimeKind.Utc),
                    Title = "Стандартно",
                    RewardMultiplier = 1.0
                },
                new OrderSpeed()
                {
                    Id = Guid.Parse("7d318e1a-cded-4481-b24b-77b385735245"),
                    CreatedAt = new DateTime(2025 ,01 ,15 ,12 ,0 ,0 ,DateTimeKind.Utc),
                    Title = "Срочно",
                    RewardMultiplier = 1.1
                },
                new OrderSpeed()
                {
                    Id = Guid.Parse("1a452389-4644-45af-be2c-359ceec260e5"),
                    CreatedAt = new DateTime(2025 ,01 ,15 ,12 ,0 ,0 ,DateTimeKind.Utc),
                    Title = "Очень срочно",
                    RewardMultiplier = 1.2
                }
            });
        }
    }
}
