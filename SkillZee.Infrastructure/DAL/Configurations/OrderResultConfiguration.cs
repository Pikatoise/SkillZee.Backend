using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class OrderResultConfiguration: IEntityTypeConfiguration<OrderResult>
    {
        public void Configure(EntityTypeBuilder<OrderResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.TotalReward).IsRequired();
            builder.Property(x => x.WorkingTime).IsRequired();

            builder.HasOne(x => x.Order)
                .WithOne(x => x.Result)
                .HasForeignKey<OrderResult>(x => x.OrderId);

            builder.HasOne(x => x.Tip)
               .WithOne(x => x.Result)
               .HasForeignKey<OrderResult>(x => x.TipId);
        }
    }
}
