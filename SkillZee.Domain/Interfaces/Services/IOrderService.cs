using SkillZee.Domain.DTO.Order;
using SkillZee.Domain.Result;

namespace SkillZee.Domain.Interfaces.Services
{
    public interface IOrderService: IBaseEntityService<OrderDto>
    {
        Task<BaseResult<OrderDto>> CreateOrder(CreateOrderDto dto);

        Task<BaseResult<bool>> ResponseToOrder(Guid orderId, Guid workerId);
    }
}
