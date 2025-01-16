using Microsoft.EntityFrameworkCore;
using SkillZee.Domain.Entities;
using SkillZee.Infrastructure.DAL;
using Testcontainers.PostgreSql;

namespace SkillZee.Integration
{
    public class TestDbContextFactory: IDisposable
    {
        private readonly PostgreSqlContainer _postgresContainer;
        public SkillZeeDbContext DbContext { get; private set; }

        public TestDbContextFactory()
        {
            _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("root")
            .WithPassword("root")
            .Build();

            _postgresContainer.StartAsync().GetAwaiter().GetResult();

            var options = new DbContextOptionsBuilder<SkillZeeDbContext>()
                .UseNpgsql(_postgresContainer.GetConnectionString())
                .UseSeeding((context, seed) => Seed(context))
                .Options;

            DbContext = new SkillZeeDbContext(options);
        }

        private async void Seed(DbContext dbContext)
        {
            var areas = new List<Area>()
            {
                new Area { Title = "Web sites" },
                new Area { Title = "Logo design" },
                new Area { Title = "Web parsing" }
            };

            var skills = new List<Skill>()
            {
                new Skill { Title = "Communication" },
                new Skill { Title = "Adaptability" },
                new Skill { Title = "Creativity" }
            };

            var users = new List<User>()
            {
                new User
                {
                    Email = "test1@mail.ru",
                    Password = "testPassword1",
                    Nickname = "test1",
                    Balance = 500,
                    AvatarUri = "userAvatars/empty.jpg",
                    LastOnline = new DateTime(2025, 01, 15, 20, 30, 50, DateTimeKind.Utc)
                },
                new User
                {
                    Email = "test2@mail.ru",
                    Password = "testPassword2",
                    Nickname = "test2",
                    Balance = 250,
                    AvatarUri = "userAvatars/empty.jpg",
                    LastOnline = new DateTime(2025, 01, 15, 20, 30, 51, DateTimeKind.Utc),
                    SuccessOrders = 1
                },
                new User
                {
                    Email = "test3@mail.ru",
                    Password = "testPassword3",
                    Nickname = "test3",
                    Balance = 150,
                    AvatarUri = "userAvatars/empty.jpg",
                    LastOnline = new DateTime(2025, 01, 15, 20, 30, 50, DateTimeKind.Utc),
                    IsWorker = true,
                    SuccessOrders = 1,
                },
            };

            var workerInfos = new List<WorkerInfo>()
            {
                new WorkerInfo()
                {
                    Description = "test description 1",
                    WorkerAreas = new List<Area>() { areas[0] },
                    WorkerSkills = new List<Skill>() { skills[0], skills[1], skills[2] },
                    WorkerId = users[2].Id
                }
            };

            users[2].WorkerInfoId = workerInfos[0].Id;

            var orders = new List<Order>()
            {
                new Order()
                {
                    CreatedAt = new DateTime(2025, 01, 16, 13, 11, 40, DateTimeKind.Utc),
                    Title = "Test order 1",
                    Description = "Test decription 1",
                    Reward = 150,
                    OrderSpeedId = Guid.Parse("019f5b79-1fe2-435d-99f3-837e38047036"),
                    AreaId = areas[0].Id,
                    CustomerId = users[1].Id,
                    WorkerId = users[2].Id,
                },
                new Order()
                {
                    CreatedAt = new DateTime(2025, 01, 17, 22, 13, 1, DateTimeKind.Utc),
                    Title = "Test order 2",
                    Description = "Test decription 2",
                    Reward = 500,
                    OrderSpeedId = Guid.Parse("019f5b79-1fe2-435d-99f3-837e38047036"),
                    AreaId = areas[1].Id,
                    CustomerId = users[0].Id
                },
            };

            var orderResponses = new List<OrderResponse>()
            {
                new OrderResponse()
                {
                    OrderId = orders[0].Id,
                    WorkerId = users[2].Id
                }
            };

            var orderResults = new List<OrderResult>()
            {
                new OrderResult()
                {
                    TotalReward = 150,
                    WorkingTime = new DateTime(2025, 01, 17, 15, 32, 01, DateTimeKind.Utc) - orders[0].CreatedAt,
                    WorkerScore = 5,
                    CustomerScore = 5,
                    OrderId = orders[0].Id
                }
            };

            orders[0].ResultId = orderResults[0].Id;

            var balanceTransactions = new List<BalanceTransaction>()
            {
                new BalanceTransaction()
                {
                    Amount = 500,
                    UserId = users[0].Id,
                },
                new BalanceTransaction()
                {
                    Amount = 400,
                    UserId = users[1].Id,
                },
                new BalanceTransaction()
                {
                    Amount = -150,
                    UserId = users[1].Id,
                },
                new BalanceTransaction()
                {
                    Amount = 150,
                    UserId = users[2].Id,
                }
            };

            await dbContext.AddRangeAsync(areas);
            await dbContext.AddRangeAsync(skills);
            await dbContext.AddRangeAsync(users);
            await dbContext.AddRangeAsync(workerInfos);
            await dbContext.AddRangeAsync(orders);
            await dbContext.AddRangeAsync(orderResponses);
            await dbContext.AddRangeAsync(orderResults);
            await dbContext.AddRangeAsync(balanceTransactions);

            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            _postgresContainer.StopAsync().GetAwaiter().GetResult();
        }
    }
}
