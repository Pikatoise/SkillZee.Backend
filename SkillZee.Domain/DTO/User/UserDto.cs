using SkillZee.Domain.DTO.WorkerInfo;

namespace SkillZee.Domain.DTO.User
{
    public record UserDto(
        Guid Id,
        DateTime CreatedAt,
        bool IsActive,

        string Nickname,
        string AvatarUri,
        bool IsWorker,
        int SuccessOrders,
        DateTime LastOnline,
        WorkerInfoDto? WorkerInfo);
}
