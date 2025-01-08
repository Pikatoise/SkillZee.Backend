using SkillZee.Domain.Result;

namespace SkillZee.Domain.Interfaces.Services
{
    public interface IBaseEntityService<T> where T : class
    {
        Task<BaseResult<T>> GetById(Guid id);

        Task<BaseResult<T>> Turn(Guid id);

        Task<BaseResult<T>> Delete(Guid id);
    }
}
