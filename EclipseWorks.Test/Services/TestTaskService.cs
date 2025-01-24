using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Enums;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Infrastructure;
using EclipseWorks.Services.Interfaces;
using EclipseWorks.Test.MockData;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.Test.Services
{
    public class TestTaskService : IClassFixture<DependencySetupFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public TestTaskService(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task GetAllTaskByProjectAsync_ShouldHaveCollectionWithThreeProjects()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddRangeAsync(ProjectMockData.GetProjects());
                await _context.Task.AddRangeAsync(TaskMockData.GetTasks());
                await _context.SaveChangesAsync(ct);

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                var result = await sut.GetAllByProjectAsync(1, ct);

                /// Assert
                result.Should().HaveCount(3);
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task AddTaskAsync_ShouldSatisfyTaskModel()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddRangeAsync(ProjectMockData.GetProjects());
                await _context.SaveChangesAsync(ct);

                var newTask = TaskMockData.NewTask();

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                var result = await sut.AddAsync(newTask, ct);

                /// Assert
                result.Should().Satisfy<TaskModel>(p =>
                {
                    p.ProjectId = 1;
                    p.TaskStatusId = (short)eTaskStatus.Pending;
                    p.TaskPriorityId = (short)eTaskPriority.Low;
                    p.Title = "Task 4";
                    p.Description = "Description for Task 4";
                    p.DueDate = DateTime.Now.AddDays(30);
                    p.Active = true;
                });
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task AddTaskAsync_ShouldThrowException_WhenInvalidTitle()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddRangeAsync(ProjectMockData.GetProjects());
                await _context.SaveChangesAsync(ct);

                var newTask = TaskMockData.NewTaskWithInvalidTitle();

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                Func<Task> verifyProject = async () => await sut.AddAsync(newTask, ct);

                /// Assert
                await verifyProject.Should()
                        .ThrowExactlyAsync<CustomException>()
                        .WithMessage(Message.MSG0015("Title", 3));
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task AddTaskAsync_ShouldThrowException_WhenInvalidProjectId()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddRangeAsync(ProjectMockData.GetProjects());
                await _context.SaveChangesAsync(ct);

                var newTask = TaskMockData.NewTaskWithInvalidProjectId();

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                Func<Task> verifyProject = async () => await sut.AddAsync(newTask, ct);

                /// Assert
                await verifyProject.Should()
                        .ThrowExactlyAsync<CustomException>()
                        .WithMessage(Message.MSG0049("Project", "Id"));
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task AddTaskAsync_ShouldThrowException_WhenMoreThan20RegisteredTasks()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddRangeAsync(ProjectMockData.GetProjects());
                await _context.Task.AddRangeAsync(TaskMockData.Get20Tasks());
                await _context.SaveChangesAsync(ct);

                var newTask = TaskMockData.NewTask();

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                Func<Task> verifyProject = async () => await sut.AddAsync(newTask, ct);

                /// Assert
                await verifyProject.Should()
                        .ThrowExactlyAsync<CustomException>()
                        .WithMessage("It is not possible to register the task as the maximum limit of 20 tasks has been reached");
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task UpdateTaskAsync_ShouldSatisfyTaskModel()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddAsync(ProjectMockData.UpdateProject());
                await _context.Task.AddAsync(TaskMockData.UpdateTask());
                await _context.SaveChangesAsync(ct);

                var updateTask = TaskMockData.UpdateTask();
                updateTask.Title = "Task 5";
                updateTask.Description = "Description for Task 5";

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                var result = await sut.UpdateAsync(updateTask, ct);

                /// Assert
                result.Should().Satisfy<TaskModel>(p =>
                {
                    p.Title = "Task 5";
                    p.Description = "Description for Task 5";
                });
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task DeleteTaskAsync_ShouldBeTrue()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                await _context.Database.EnsureDeletedAsync();
                await _context.Database.EnsureCreatedAsync();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddAsync(ProjectMockData.UpdateProject());
                await _context.Task.AddAsync(TaskMockData.UpdateTask());

                await _context.SaveChangesAsync(ct);

                var sut = scope.ServiceProvider.GetService<ITaskService>();

                /// Act
                var result = await sut.DeleteByIdAsync(1, ct);

                /// Assert
                result.Should().BeTrue();
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }
    }
}
