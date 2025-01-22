using EclipseWorks.Core.Interfaces;
using EclipseWorks.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseNpgsql(configuration.GetSection("ConnectionStringDefaultConnection").Value);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOperationLogRepository, OperationLogRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskCommentRepository, TaskCommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
