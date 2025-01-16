using Microsoft.EntityFrameworkCore;
using SkillZee.Application.Services;
using SkillZee.Domain.DTO.Order;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Interfaces.Services;
using SkillZee.Infrastructure.DAL.Repositories;

namespace SkillZee.Integration
{
    public class OrderTests: IDisposable
    {
        readonly TestDbContextFactory _factory;
        readonly IOrderService _orderService;
        readonly UnitOfWork _unitOfWork;

        public OrderTests()
        {
            _factory = new TestDbContextFactory();
            _unitOfWork = new UnitOfWork(_factory.DbContext);

            _orderService = new OrderService(_unitOfWork);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldAddOrderToDatabase()
        {
            // Arrange
            var area = await _unitOfWork.Areas.GetAll().FirstOrDefaultAsync();
            var customer = await _unitOfWork.Users.GetAll().FirstOrDefaultAsync(x => x.IsWorker == false);
            var orderSpeed = await _unitOfWork.OrderSpeeds.GetAll().FirstOrDefaultAsync();

            var orderDto = new CreateOrderDto
            {
                Title = "Test Order 1",
                Description = "Test description",
                Reward = 300.0,
                AreaId = area.Id,
                CustomerId = customer.Id,
                OrderSpeedId = orderSpeed.Id
            };

            // Act
            var result = await _orderService.CreateOrder(orderDto);

            // Assert
            var orderFromDb = result.Data != null ?
                _factory.DbContext.Set<Order>().FirstOrDefault(x => x.Title.Equals(result.Data.Title))
                : null;

            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.NotNull(orderFromDb);

            Assert.Equal(orderFromDb.Id, result.Data.Id);
        }

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
