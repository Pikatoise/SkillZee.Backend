using SkillZee.Domain.DTO.Order;
using SkillZee.Domain.Entities;

namespace SkillZee.Application.MapperExtensions
{
    public static class OrderMapExtension
    {
        public static OrderDto ToDto(this Order order) => new OrderDto()
        {
            Id = order.Id,
            Title = order.Title,
            Reward = order.Reward,
            CreatedAt = order.CreatedAt,
            Description = order.Description,
            IsActive = order.IsActive,
            Area = order.Area.ToDto(),
            OrderSpeed = order.OrderSpeed.ToDto(),
            Customer = order.Customer.ToDto()
        };
    }
}
