using EclipseWorks.Core.Models;
using EclipseWorks.Helper.Enums;
using System.Collections.Generic;

namespace EclipseWorks.Test.MockData
{
    public class TaskMockData
    {
        public static List<TaskModel> GetTasks()
        {
            return [
                 new TaskModel{
                     ProjectId = 1,
                     TaskPriorityId = (short)eTaskPriority.Low,
                     TaskStatusId = (short)eTaskStatus.Pending,
                     Title = "Task 1",
                     Description = "Description for Task 1",
                     DueDate = DateTime.Now.AddDays(10),
                     Active = true,
                 },
                 new TaskModel{
                     ProjectId = 1,
                     TaskPriorityId = (short)eTaskPriority.Medium,
                     TaskStatusId = (short)eTaskStatus.Pending,
                     Title = "Task 2",
                     Description = "Description for Task 2",
                     DueDate = DateTime.Now.AddDays(20),
                     Active = true,
                 },
                 new TaskModel{
                     ProjectId = 1,
                     TaskPriorityId = (short)eTaskPriority.Medium,
                     TaskStatusId = (short)eTaskStatus.Completed,
                     Title = "Task 3",
                     Description = "Description for Task 3",
                     DueDate = DateTime.Now.AddDays(20),
                     Active = true,
                 }
             ];
        }

        public static List<TaskModel> GetPendingTasks()
        {
            return [
                 new TaskModel{
                     Id = 1,
                     ProjectId = 1,
                     TaskPriorityId = (short)eTaskPriority.Low,
                     TaskStatusId = (short)eTaskStatus.Pending,
                     Title = "Task 1",
                     Description = "Description for Task 1",
                     DueDate = DateTime.Now.AddDays(10),
                     Active = true,
                 },
                 new TaskModel{
                     Id = 2,
                     ProjectId = 1,
                     TaskPriorityId = (short)eTaskPriority.Medium,
                     TaskStatusId = (short)eTaskStatus.Completed,
                     Title = "Task 2",
                     Description = "Description for Task 2",
                     DueDate = DateTime.Now.AddDays(20),
                     Active = true,
                 },
                 new TaskModel{
                     Id = 3,
                     ProjectId = 1,
                     TaskPriorityId = (short)eTaskPriority.Medium,
                     TaskStatusId = (short)eTaskStatus.Completed,
                     Title = "Task 3",
                     Description = "Description for Task 3",
                     DueDate = DateTime.Now.AddDays(20),
                     Active = true,
                 }
             ];
        }

        public static List<ProjectModel> GetEmptyProjects()
        {
            return [];
        }

        public static TaskModel NewTask()
        {
            return new TaskModel
            {
                ProjectId = 1,
                TaskPriorityId = (short)eTaskPriority.Low,
                Title = "Task 4",
                Description = "Description for Task 4",
                DueDate = DateTime.Now.AddDays(30)
            };
        }

        public static TaskModel NewTaskWithInvalidTitle()
        {
            return new TaskModel
            {
                ProjectId = 1,
                TaskPriorityId = (short)eTaskPriority.Low,
                Title = "Ta",
                Description = "Description for Task 4",
                DueDate = DateTime.Now.AddDays(30)
            };
        }

        public static TaskModel NewTaskWithInvalidProjectId()
        {
            return new TaskModel
            {
                ProjectId = 1000,
                TaskPriorityId = (short)eTaskPriority.Low,
                Title = "Ta",
                Description = "Description for Task 4",
                DueDate = DateTime.Now.AddDays(30)
            };
        }

        public static List<TaskModel> Get20Tasks()
        {
            List<TaskModel> taskList = [];

            for (int i = 1; i <= 20; i++)
            {
                taskList.Add(
                new TaskModel
                {
                    ProjectId = 1,
                    TaskPriorityId = (short)eTaskPriority.Low,
                    TaskStatusId = (short)eTaskStatus.Pending,
                    Title = $"Task {i}",
                    Description = $"Description for Task {i}",
                    DueDate = DateTime.Now.AddDays(10),
                    Active = true,
                });
            }

            return taskList;
        }

        public static TaskModel UpdateTask()
        {
            return new TaskModel
            {
                Id = 1,
                ProjectId = 1,
                TaskStatusId = (short)eTaskStatus.Completed,
                Title = "Task Test",
                Description = "Description for Task Test"
            };
        }
    }
}
