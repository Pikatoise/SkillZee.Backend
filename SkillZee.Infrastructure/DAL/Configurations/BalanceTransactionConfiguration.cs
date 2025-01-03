using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class BalanceTransactionConfiguration: IEntityTypeConfiguration<BalanceTransaction>
    {
        public void Configure(EntityTypeBuilder<BalanceTransaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.BalanceTransactions)
                .HasForeignKey(x => x.UserId);
        }
    }
}
