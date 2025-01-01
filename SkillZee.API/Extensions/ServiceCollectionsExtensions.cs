using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Interfaces.Repositories;
using SkillZee.Infrastructure.DAL;
using SkillZee.Infrastructure.DAL.Repositories;

namespace SkillZee.API.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SkillZee API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Url = new Uri("t.me/pikatoise")
                    }
                });

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return builder;
        }

        public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SkillZeeDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("SkillZeeDB"))
            );

            builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            builder.Services.AddScoped<IBaseRepository<WorkerInfo>, BaseRepository<WorkerInfo>>();
            builder.Services.AddScoped<IBaseRepository<Tip>, BaseRepository<Tip>>();
            builder.Services.AddScoped<IBaseRepository<Skill>, BaseRepository<Skill>>();
            builder.Services.AddScoped<IBaseRepository<OrderSpeed>, BaseRepository<OrderSpeed>>();
            builder.Services.AddScoped<IBaseRepository<OrderResult>, BaseRepository<OrderResult>>();
            builder.Services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            builder.Services.AddScoped<IBaseRepository<BalanceTransaction>, BaseRepository<BalanceTransaction>>();
            builder.Services.AddScoped<IBaseRepository<Area>, BaseRepository<Area>>();

            builder.Services.AddScoped<UnitOfWork>();

            return builder;
        }
    }
}
