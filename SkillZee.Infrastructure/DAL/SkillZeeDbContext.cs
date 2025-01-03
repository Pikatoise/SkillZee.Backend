using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SkillZee.Infrastructure.DAL;

public class SkillZeeDbContext: DbContext
{
    public SkillZeeDbContext(DbContextOptions<SkillZeeDbContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
