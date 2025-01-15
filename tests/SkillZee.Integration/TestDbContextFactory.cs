using Microsoft.EntityFrameworkCore;
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
                .Options;

            DbContext = new SkillZeeDbContext(options);
        }

        public void Dispose()
        {
            DbContext.Dispose();
            _postgresContainer.StopAsync().GetAwaiter().GetResult();
        }
    }
}
