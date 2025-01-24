using EclipseWorks.Core.Models;

namespace EclipseWorks.Test.MockData
{
    public class ProjectMockData
    {
        public static List<ProjectModel> GetProjects()
        {
            return [
                 new ProjectModel{
                     UserId = 1,
                     Title = "Project 1"
                 },
                 new ProjectModel{
                     UserId = 2,
                     Title = "Project 2"
                 },
                 new ProjectModel{
                     UserId = 1,
                     Title = "Project 3"
                 },
             ];
        }

        public static List<ProjectModel> GetEmptyProjects()
        {
            return [];
        }

        public static ProjectModel NewProject()
        {
            return new ProjectModel
            {
                UserId = 1,
                Title = "Project Test"
            };
        }

        public static ProjectModel NewProjectWithInvalidTitle()
        {
            return new ProjectModel
            {
                UserId = 1,
                Title = "Pr"
            };
        }

        public static ProjectModel NewProjectWithInvalidUserId()
        {
            return new ProjectModel
            {
                UserId = 1000,
                Title = "Project Test"
            };
        }

        public static ProjectModel UpdateProject()
        {
            return new ProjectModel
            {
                Id = 1,
                UserId = 1,
                Title = "Project Test",
                Active = true
            };
        }
    }
}
