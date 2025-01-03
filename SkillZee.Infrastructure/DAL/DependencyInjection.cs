using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Interfaces.Repositories;
using SkillZee.Infrastructure.DAL.Repositories;

namespace SkillZee.Infrastructure.DAL
{
    public static class DependencyInjection
    {
        public static void AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SkillZeeDbContext>((sp, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("postgresql"));
            });

            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<WorkerInfo>, BaseRepository<WorkerInfo>>();
            services.AddScoped<IBaseRepository<Tip>, BaseRepository<Tip>>();
            services.AddScoped<IBaseRepository<Skill>, BaseRepository<Skill>>();
            services.AddScoped<IBaseRepository<OrderSpeed>, BaseRepository<OrderSpeed>>();
            services.AddScoped<IBaseRepository<OrderResult>, BaseRepository<OrderResult>>();
            services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddScoped<IBaseRepository<BalanceTransaction>, BaseRepository<BalanceTransaction>>();
            services.AddScoped<IBaseRepository<Area>, BaseRepository<Area>>();

            services.AddScoped<UnitOfWork>();
        }
    }
}
