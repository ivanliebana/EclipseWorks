using EclipseWorks.Core.Interfaces;
using EclipseWorks.Infrastructure;
using EclipseWorks.Infrastructure.Repositories;
using EclipseWorks.Services;
using EclipseWorks.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.Test
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DbContextClass>(options =>
            {
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });

            serviceCollection.AddScoped<Lazy<ITaskService>>(provider => new Lazy<ITaskService>(provider.GetService<ITaskService>));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
            serviceCollection.AddScoped<IProjectService, ProjectService>();

            serviceCollection.AddScoped<ITaskRepository, TaskRepository>();
            serviceCollection.AddScoped<ITaskService, TaskService>();

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserService, UserService>();

            serviceCollection.AddScoped<ITaskCommentRepository, TaskCommentRepository>();
            serviceCollection.AddScoped<ITaskCommentService, TaskCommentService>();

            serviceCollection.AddScoped<IOperationLogRepository, OperationLogRepository>();
            serviceCollection.AddScoped<IOperationLogService, OperationLogService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
