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
            var testArea = await _unitOfWork.Areas.CreateAsync(
                new Area
                {
                    Title = "Test Area"
                }
            );
            var testCustomer = await _unitOfWork.Users.CreateAsync(
                new User
                {
                    Email = "test1@mail.ru",
                    Nickname = "Test1",
                    Password = "TestPassword1",
                    AvatarUri = "userAvatars/empty.png",
                    Balance = 350,
                    LastOnline = DateTime.UtcNow
                }
            );
            var testOrderSpeed = await _unitOfWork.OrderSpeeds.CreateAsync(
                new OrderSpeed()
                {
                    Title = "Normal",
                    RewardMultiplier = 1.0
                }
            );

            var orderDto = new CreateOrderDto
            {
                Title = "Test Order 1",
                Description = "Test description",
                Reward = 300.0,
                AreaId = testArea.Id,
                CustomerId = testCustomer.Id,
                OrderSpeedId = testOrderSpeed.Id
            };

            await _unitOfWork.SaveChangesAsync();

            // Act
            var result = await _orderService.CreateOrder(orderDto);

            await _unitOfWork.SaveChangesAsync();

            // Assert
            var orderFromDb = _factory.DbContext.Set<Order>().Single();

            Assert.NotNull(result);
            Assert.NotNull(orderFromDb);
            Assert.NotNull(result.Data);

            Assert.Equal(orderFromDb.Id, result.Data.Id);
        }

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
