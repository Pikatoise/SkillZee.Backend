using SkillZee.Domain.DTO.Area;
using SkillZee.Domain.DTO.OrderSpeed;
using SkillZee.Domain.DTO.User;

namespace SkillZee.Domain.DTO.Order
{
    public record OrderDto(
        Guid Id,
        DateTime CreatedAt,
        bool IsActive,

        string Title,
        string Description,
        double Reward,
        OrderSpeedDto OrderSpeed,
        AreaDto Area,
        UserDto Customer);
}
