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
    public DbSet<WorkerInfo> WorkerInfos { get; set; } = null!;
    public DbSet<Tip> Tips { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<OrderSpeed> OrderSpeeds { get; set; } = null!;
    public DbSet<OrderResult> OrderResults { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<BalanceTransaction> BalanceTransactions { get; set; } = null!;
    public DbSet<Area> Areas { get; set; } = null!;

}
