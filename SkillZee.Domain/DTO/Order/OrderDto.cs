using SkillZee.Domain.DTO.Area;
using SkillZee.Domain.DTO.OrderSpeed;
using SkillZee.Domain.DTO.User;

namespace SkillZee.Domain.DTO.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public double Reward { get; set; }
        public required OrderSpeedDto OrderSpeed { get; set; }
        public required AreaDto Area { get; set; }
        public required UserDto Customer { get; set; }
    };
}
