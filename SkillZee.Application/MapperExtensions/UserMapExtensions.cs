using SkillZee.Domain.DTO.User;
using SkillZee.Domain.Entities;

namespace SkillZee.Application.MapperExtensions
{
    public static class UserMapExtensions
    {
        public static UserDto ToDto(this User user) => new UserDto()
        {
            Id = user.Id,
            Nickname = user.Nickname,
            LastOnline = user.LastOnline,
            CreatedAt = user.CreatedAt,
            AvatarUri = user.AvatarUri,
            IsActive = user.IsActive,
            IsWorker = user.IsWorker,
            SuccessOrders = user.SuccessOrders,
            WorkerInfo = user.WorkerInfo.ToDto()
        };
    }
}
