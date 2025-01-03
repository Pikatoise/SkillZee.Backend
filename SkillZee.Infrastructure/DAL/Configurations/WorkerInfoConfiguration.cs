using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL.Configurations
{
    public class WorkerInfoConfiguration: IEntityTypeConfiguration<WorkerInfo>
    {
        public void Configure(EntityTypeBuilder<WorkerInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasMany<Area>(x => x.WorkerAreas);
            builder.HasMany<Skill>(x => x.WorkerSkills);

            builder.HasOne<User>(x => x.Worker)
                .WithOne(x => x.WorkerInfo)
                .HasForeignKey<WorkerInfo>(x => x.WorkerId);
        }
    }
}
