using SkillZee.Domain.Entities;

namespace SkillZee.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> CreateAsync(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Disable(TEntity entity);
    }
}
