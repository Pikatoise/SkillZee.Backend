using Microsoft.EntityFrameworkCore;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Interfaces.Repositories;

namespace SkillZee.Infrastructure.DAL.Repositories
{
    public class BaseRepository<TEntity>(SkillZeeDbContext dbContext): IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SkillZeeDbContext _dbContext = dbContext;

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            await _dbContext.AddAsync(entity);

            return entity;
        }

        public TEntity Disable(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            entity.IsActive = false;

            _dbContext.Update(entity);

            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            _dbContext.Update(entity);

            return entity;
        }
    }
}
