using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.Email).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Nickname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Balance).IsRequired().HasDefaultValue(0.0);
            builder.Property(x => x.AvatarUri);
            builder.Property(x => x.IsWorker).HasDefaultValue(false);
            builder.Property(x => x.SuccessOrders).HasDefaultValue(0);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
