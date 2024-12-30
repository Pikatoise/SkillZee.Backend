using Microsoft.EntityFrameworkCore;
using SkillZee.Domain.Entities;

namespace SkillZee.Infrastructure.DAL;

public sealed class SkillZeeDbContext: DbContext
{
    public SkillZeeDbContext(DbContextOptions<SkillZeeDbContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    public DbSet<User> Users { get; set; } = null!;
}
