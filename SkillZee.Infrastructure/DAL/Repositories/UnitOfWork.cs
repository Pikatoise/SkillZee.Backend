using Microsoft.EntityFrameworkCore.Storage;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Interfaces.Repositories;

namespace SkillZee.Infrastructure.DAL.Repositories
{
    public class UnitOfWork(SkillZeeDbContext dbContext)
    {
        readonly SkillZeeDbContext _dbContext = dbContext;

        public IBaseRepository<User> Users { get; } = new BaseRepository<User>(dbContext);
        public IBaseRepository<WorkerInfo> Workerinfos { get; } = new BaseRepository<WorkerInfo>(dbContext);
        public IBaseRepository<Tip> Tips { get; } = new BaseRepository<Tip>(dbContext);
        public IBaseRepository<Skill> Skills { get; } = new BaseRepository<Skill>(dbContext);
        public IBaseRepository<OrderSpeed> OrderSpeeds { get; } = new BaseRepository<OrderSpeed>(dbContext);
        public IBaseRepository<OrderResult> OrderResults { get; } = new BaseRepository<OrderResult>(dbContext);
        public IBaseRepository<Order> Orders { get; } = new BaseRepository<Order>(dbContext);
        public IBaseRepository<BalanceTransaction> BalanceTransactions { get; } = new BaseRepository<BalanceTransaction>(dbContext);
        public IBaseRepository<Area> Areas { get; } = new BaseRepository<Area>(dbContext);
        public IBaseRepository<OrderResponse> OrderResponses { get; } = new BaseRepository<OrderResponse>(dbContext);

        public async Task<IDbContextTransaction> BeginTransactionAsync() =>
            await _dbContext.Database.BeginTransactionAsync();

        public async Task<int> SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}
