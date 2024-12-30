using Microsoft.EntityFrameworkCore;

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
}
