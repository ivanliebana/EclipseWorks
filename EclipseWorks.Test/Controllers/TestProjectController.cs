using AutoMapper;
using EclipseWorks.API.Controllers;
using EclipseWorks.API.Mappers;
using EclipseWorks.Services.Interfaces;
using EclipseWorks.Test.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EclipseWorks.Test.Controllers
{
    public class TestProjectController
    {
        [Fact]
        public async Task GetAllProjectByUserAsync_ShouldReturn200Status()
        {
            var ct = new CancellationToken();

            /// Arrange
            var projectService = new Mock<IProjectService>();
            projectService.Setup(_ => _.GetAllByUserAsync(1, ct)).ReturnsAsync(ProjectMockData.GetProjects());

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var sut = new ProjectController(projectService.Object, mapper);
            
            /// Act
            var result = (OkObjectResult)await sut.GetAllByUser(1, ct);

            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllProjectByUserAsync_ShouldReturn204NoContentStatus()
        {
            var ct = new CancellationToken();

            /// Arrange
            var projectService = new Mock<IProjectService>();
            projectService.Setup(_ => _.GetAllByUserAsync(1, ct)).ReturnsAsync(ProjectMockData.GetEmptyProjects());

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var sut = new ProjectController(projectService.Object, mapper);

            /// Act
            var result = (NoContentResult)await sut.GetAllByUser(1, ct);

            /// Assert
            result.StatusCode.Should().Be(204);
            projectService.Verify(_ => _.GetAllByUserAsync(1, ct), Times.Exactly(1));
        }
    }
}
