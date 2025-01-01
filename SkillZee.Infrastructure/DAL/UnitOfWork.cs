using Microsoft.EntityFrameworkCore.Storage;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Interfaces.Repositories;

namespace SkillZee.Infrastructure.DAL
{
    public class UnitOfWork(
        SkillZeeDbContext dbContext,
        IBaseRepository<User> users,
        IBaseRepository<WorkerInfo> workerInfos,
        IBaseRepository<Tip> tips,
        IBaseRepository<Skill> skills,
        IBaseRepository<OrderSpeed> orderSpeeds,
        IBaseRepository<OrderResult> orderResults,
        IBaseRepository<Order> orders,
        IBaseRepository<BalanceTransaction> balanceTransactions,
        IBaseRepository<Area> areas)
    {
        readonly SkillZeeDbContext _dbContext = dbContext;

        public IBaseRepository<User> Users { get; } = users;
        public IBaseRepository<WorkerInfo> Workerinfos { get; } = workerInfos;
        public IBaseRepository<Tip> Tips { get; } = tips;
        public IBaseRepository<Skill> Skills { get; } = skills;
        public IBaseRepository<OrderSpeed> OrderSpeeds { get; } = orderSpeeds;
        public IBaseRepository<OrderResult> OrderResults { get; } = orderResults;
        public IBaseRepository<Order> Orders { get; } = orders;
        public IBaseRepository<BalanceTransaction> BalanceTransactions { get; } = balanceTransactions;
        public IBaseRepository<Area> Areas { get; } = areas;

        public async Task<IDbContextTransaction> BeginTransactionAsync() =>
            await _dbContext.Database.BeginTransactionAsync();

        public async Task<int> SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}
