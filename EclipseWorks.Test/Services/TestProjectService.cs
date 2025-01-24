using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Infrastructure;
using EclipseWorks.Services.Interfaces;
using EclipseWorks.Test.MockData;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.Test.Services
{
    public class TestProjectService : IClassFixture<DependencySetupFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public TestProjectService(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task GetAllProjectByUserAsync_ShouldHaveCollectionWithTwoProjects()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.Project.AddRangeAsync(ProjectMockData.GetProjects(), ct);
                await _context.SaveChangesAsync(ct);

                var sut = scope.ServiceProvider.GetService<IProjectService>();

                /// Act
                var result = await sut.GetAllByUserAsync(1, ct);

                /// Assert
                result.Should().HaveCount(2);
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task AddProjectAsync_ShouldSatisfyProjectModel()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.SaveChangesAsync(ct);

                var newProject = ProjectMockData.NewProject();

                var sut = scope.ServiceProvider.GetService<IProjectService>();

                /// Act
                var result = await sut.AddAsync(newProject, ct);

                /// Assert
                result.Should().Satisfy<ProjectModel>(p =>
                {
                    p.UserId = 1;
                    p.Title = "Project Test";
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
        public async Task AddProjectAsync_ShouldThrowException_InvalidTitle()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.SaveChangesAsync(ct);

                var newProject = ProjectMockData.NewProjectWithInvalidTitle();

                var sut = scope.ServiceProvider.GetService<IProjectService>();

                /// Act
                Func<Task> verifyProject = async () => await sut.AddAsync(newProject, ct);

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
        public async Task AddProjectAsync_ShouldThrowException_InvalidUserId()
        {
            using var scope = _serviceProvider.CreateScope();
            var ct = new CancellationToken();
            var _context = scope.ServiceProvider.GetService<DbContextClass>();

            try
            {
                /// Arrange
                _context.Database.EnsureCreated();

                await _context.User.AddRangeAsync(UserMockData.GetUsers());
                await _context.SaveChangesAsync(ct);

                var newProject = ProjectMockData.NewProjectWithInvalidUserId();

                var sut = scope.ServiceProvider.GetService<IProjectService>();

                /// Act
                Func<Task> verifyProject = async () => await sut.AddAsync(newProject, ct);

                /// Assert
                await verifyProject.Should()
                        .ThrowExactlyAsync<CustomException>()
                        .WithMessage(Message.MSG0049("User", "Id"));
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task UpdateProjectAsync_ShouldSatisfyProjectModel()
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
                await _context.SaveChangesAsync(ct);

                var updateProject = ProjectMockData.UpdateProject();
                updateProject.Title = "Project 2";

                var sut = scope.ServiceProvider.GetService<IProjectService>();

                /// Act
                var result = await sut.UpdateAsync(updateProject, ct);

                /// Assert
                result.Should().Satisfy<ProjectModel>(p =>
                {
                    p.Id = 1;
                    p.UserId = 1;
                    p.Title = "Project Test";
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
        public async Task DeleteProjectAsync_ShouldBeTrue()
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

                await _context.SaveChangesAsync(ct);

                var sut = scope.ServiceProvider.GetService<IProjectService>();

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

        [Fact]
        public async Task DeleteProjectAsync_ShouldThrowException_PendingTaks()
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
                await _context.Task.AddRangeAsync(TaskMockData.GetPendingTasks());

                await _context.SaveChangesAsync(ct);

                var sut = scope.ServiceProvider.GetService<IProjectService>();

                /// Act
                Func<Task> verifyProject = async () => await sut.DeleteByIdAsync(1, ct);

                /// Assert
                await verifyProject.Should()
                                    .ThrowExactlyAsync<CustomException>()
                                    .WithMessage("The project cannot be removed because there are still pending tasks associated with it. Please complete or remove pending tasks before proceeding");
            }
            finally
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }
    }
}
