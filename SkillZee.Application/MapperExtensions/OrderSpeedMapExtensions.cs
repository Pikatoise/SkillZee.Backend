using SkillZee.Domain.DTO.OrderSpeed;
using SkillZee.Domain.Entities;

namespace SkillZee.Application.MapperExtensions
{
    public static class OrderSpeedMapExtensions
    {
        public static OrderSpeedDto ToDto(this OrderSpeed orderSpeed) => new OrderSpeedDto()
        {
            Id = orderSpeed.Id,
            CreatedAt = orderSpeed.CreatedAt,
            IsActive = orderSpeed.IsActive,
            Title = orderSpeed.Title,
            RewardMultiplier = orderSpeed.RewardMultiplier
        };
    }
}
