using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class OrderResponseConfiguration: IEntityTypeConfiguration<OrderResponse>
    {
        public void Configure(EntityTypeBuilder<OrderResponse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasOne(x => x.Worker)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.WorkerId);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
