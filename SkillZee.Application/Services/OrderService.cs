using SkillZee.Application.MapperExtensions;
using SkillZee.Domain;
using SkillZee.Domain.DTO.Order;
using SkillZee.Domain.Filters;
using SkillZee.Domain.Interfaces.Services;
using SkillZee.Domain.Result;
using SkillZee.Infrastructure.DAL.Repositories;

namespace SkillZee.Application.Services
{
    public class OrderService(UnitOfWork unitOfWork): IOrderService
    {
        readonly UnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResult<OrderDto>> CreateOrder(CreateOrderDto dto)
        {
            var entity = dto.ToEntity();

            await _unitOfWork.Orders.CreateAsync(entity);

            return new BaseResult<OrderDto>(entity.ToDto());
        }

        public Task<BaseResult<OrderDto>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<OrderDto>> GetAllOrders(OrderFilter filters, SortParams sorting, PageParams paging)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<OrderDto>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<bool>> ResponseToOrder(Guid orderId, Guid workerId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<OrderDto>> Turn(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
