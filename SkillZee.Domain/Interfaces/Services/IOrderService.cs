using SkillZee.Domain.DTO.Order;
using SkillZee.Domain.Result;

namespace SkillZee.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<BaseResult<OrderDto>> CreateOrder(CreateOrderDto dto);
    }
}
