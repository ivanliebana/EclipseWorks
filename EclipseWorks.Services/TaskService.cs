using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Enums;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Services.Interfaces;
using System.Transactions;

namespace EclipseWorks.Services
{
    public class TaskService(
        IUnitOfWork unitOfWork,
        IProjectService projectService,
        IUserService userService) : ITaskService
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IProjectService _projectService = projectService;
        private readonly IUserService _userService = userService;

        public async Task<TaskModel> AddAsync(TaskModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            entity.TaskStatusId = (short)eTaskStatus.Pending;

            await Validation(entity, ct);

            await _unitOfWork.Task.AddAsync(entity, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            scope.Complete();

            return entity;
        }

        public async Task<bool> DeleteAsync(TaskModel entity, CancellationToken ct)
        {
            CustomException.When(entity.Id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.Task.FindOneAsync(x => x.Id == entity.Id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Tasks", "Id"));

            _unitOfWork.Task.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(long id, CancellationToken ct)
        {
            CustomException.When(id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.Task.FindOneAsync(x => x.Id == id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Task", "Id"));

            obj.Active = false;

            _unitOfWork.Task.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync(CancellationToken ct)
        {
            var list = await _unitOfWork.Task.FindListAsync(x => x.Id > 0, ct);
            return list;
        }

        public async Task<IEnumerable<TaskModel>> GetAllByProjectAsync(long projectId, CancellationToken ct)
        {
            CustomException.When(projectId <= 0, Message.MSG0016("Project Id"));
            var project = await _projectService.GetByIdAsync(projectId, ct);
            CustomException.When(project == null || project.Id <= 0, Message.MSG0049("Project", "Id"));

            return await _unitOfWork.Task.FindAllByProjectAsync(projectId, ct);
        }

        public async Task<IEnumerable<TaskModel>> GetAllPendindByProjectAsync(long projectId, CancellationToken ct)
        {
            CustomException.When(projectId <= 0, Message.MSG0016("Project Id"));
            var project = await _projectService.GetByIdAsync(projectId, ct);
            CustomException.When(project == null || project.Id <= 0, Message.MSG0049("Project", "Id"));

            return await _unitOfWork.Task.FindAllPendingByProjectAsync(projectId, ct);
        }

        public async Task<TaskModel> GetByIdAsync(long id, CancellationToken ct)
        {
            if (id > 0)
            {
                var Tasks = await _unitOfWork.Task.FindOneAsync(x => x.Id == id, ct);

                if (Tasks != null)
                    return Tasks;
            }

            return null;
        }

        public async Task<TaskModel> UpdateAsync(TaskModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            var obj = await _unitOfWork.Task.FindOneAsync(x => x.Id == entity.Id, ct, new Core.FindOptions { IsAsNoTracking = true });
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Task", "Id"));

            obj.Title = entity.Title;
            obj.Description = entity.Description;
            obj.TaskStatusId = entity.TaskStatusId;

            if (entity.TaskStatusId != obj.TaskStatusId)
            {
                obj.CompletionDate = null;

                if (entity.TaskStatusId == (short)eTaskStatus.Completed)
                    obj.CompletionDate = DateTime.Now;
            }

            _unitOfWork.Task.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return obj;
        }

        public async Task<bool> ValidateIfTitleAlreadyExists(string title, long id, CancellationToken ct)
        {
            title = title?.Trim();

            if (!title.IsNullOrEmpty())
            {
                var obj = await GetByTitleAsync(title, ct);

                if (obj != null)
                    return obj.Id != id;
            }

            return false;
        }

        public async Task<TaskModel> GetByTitleAsync(string title, CancellationToken ct)
        {
            if (!title.IsNullOrEmpty())
            {
                var obj = await _unitOfWork.Task.FindByTitleAsync(title, ct);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        private async Task Validation(TaskModel entity, CancellationToken ct)
        {
            CustomException.When(entity == null, "'Task' information not filled in correctly.");

            #region PROJECT

            if (entity.Id <= 0)
            {
                CustomException.When(entity.ProjectId <= 0, Message.MSG0016("Project Id"));
                var project = await _projectService.GetByIdAsync(entity.ProjectId, ct);
                CustomException.When(project == null || project.Id <= 0 || !project.Active, Message.MSG0049("Project", "Id"));

                var totalRegisteredTasks = 1 + await _unitOfWork.Task.CountAsync(x => x.ProjectId == entity.ProjectId && x.Active, ct);
                CustomException.When(totalRegisteredTasks > 20, "It is not possible to register the task as the maximum limit of 20 tasks has been reached");
            }
            else
            {
                var project = await _projectService.GetByIdAsync(entity.ProjectId, ct);
                CustomException.When(project == null || project.Id <= 0 || !project.Active, Message.MSG0049("Project", "Id"));
                entity.AuthorId = project.UserId;
            }

            #endregion

            #region DUE DATE

            if (entity.Id <= 0)
                CustomException.When(entity.DueDate.Date <= DateTime.Now.Date, Message.MSG0047("Due Date"));

            #endregion

            #region PRIORITY

            if (entity.Id <= 0)
            {
                CustomException.When(entity.TaskPriorityId <= 0, Message.MSG0016("Priority Id"));
                CustomException.When(!EnumLoad.LoadTaskPriority().Any(a => a.Value == entity.TaskPriorityId), Message.MSG0049("Priority", "Id"));
            }

            #endregion

            #region STATUS

            CustomException.When(entity.TaskStatusId <= 0, Message.MSG0016("Status Id"));
            CustomException.When(!EnumLoad.LoadTaskStatus().Any(a => a.Value == entity.TaskStatusId), Message.MSG0049("Status", "Id"));

            #endregion

            #region TITLE

            entity.Title = entity.Title?.Trim();

            CustomException.Required(entity.Title, Message.MSG0016("Title"));
            CustomException.MaxLength(entity.Title.Length, 150, Message.MSG0014("Title", 150));
            CustomException.MinLength(entity.Title.Length, 3, Message.MSG0015("Title", 3));

            var titleAlreadyExists = await ValidateIfTitleAlreadyExists(entity.Title, entity.Id, ct);
            CustomException.When(titleAlreadyExists, Message.MSG0055("Title"));

            #endregion

            #region DESCRIPTION

            entity.Description = entity.Description?.Trim();

            CustomException.Required(entity.Description, Message.MSG0016("Description"));
            CustomException.MaxLength(entity.Description.Length, 800, Message.MSG0014("Description", 800));
            CustomException.MinLength(entity.Description.Length, 3, Message.MSG0015("Description", 3));

            #endregion
        }

        public async Task RemoveAllByProjectAsync(long projectId, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await _unitOfWork.Task.RemoveAllByProjectAsync(projectId, ct);

            await _unitOfWork.SaveChangesAsync(ct);
            scope.Complete();
        }

        public async Task UpdateStatusAsync(TaskModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            CustomException.When(entity.TaskStatusId <= 0, Message.MSG0016("Status Id"));
            CustomException.When(!EnumLoad.LoadTaskStatus().Any(a => a.Value == entity.TaskStatusId), Message.MSG0049("Status", "Id"));

            var obj = await _unitOfWork.Task.FindOneAsync(x => x.Id == entity.Id, ct, new Core.FindOptions { IsAsNoTracking = true });
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Task", "Id"));

            if (entity.TaskStatusId != obj.TaskStatusId)
            {
                obj.CompletionDate = null;

                if (entity.TaskStatusId == (short)eTaskStatus.Completed)
                    obj.CompletionDate = DateTime.Now;
            }

            obj.TaskStatusId = entity.TaskStatusId;

            _unitOfWork.Task.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();
        }

        public async Task<IEnumerable<TaskPerformanceLast30DaysModel>> GetPerformanceLast30Days(long applicantUserId, CancellationToken ct)
        {
            List<TaskPerformanceLast30DaysModel> resultList = [];

            var applicanteUser = await _userService.GetByIdAsync(applicantUserId, ct);

            CustomException.When(applicanteUser == null || applicanteUser.Id <= 0, Message.MSG0049("User", "Id"));
            CustomException.When(applicanteUser != null && applicanteUser.Id > 0 && !applicanteUser.IsManager, Message.MSG0030);

            var tasksInLast30Days = await _unitOfWork.Task.FindByLast30Days(ct);

            var tasksPerUser = tasksInLast30Days
                    .GroupBy(t => t.Project.UserId)
                    .Select(g => new { UserId = g.Key, TaskCount = g.Count() })
                    .ToList();

            if (tasksPerUser == null || tasksPerUser.Count <= 0)
                return resultList;

            foreach (var task in tasksPerUser)
            {
                var userId = task.UserId;
                var userName = tasksInLast30Days.FirstOrDefault(x => x.Project.UserId == userId).Project.User.Name;
                var numberTasksCompleted = task.TaskCount;
                var averageNumberTasksCompleted = task.TaskCount / 30.0;

                var objTaskPerformanceLast30Days = new TaskPerformanceLast30DaysModel
                {
                    UserName = userName,
                    UserId = userId,
                    NumberTasksCompleted = numberTasksCompleted,
                    AverageNumberTasksCompleted = averageNumberTasksCompleted,
                    ResultText = $"User with 'Name' {userName} and 'Id' {userId} has {numberTasksCompleted} completed tasks in the last 30 days, which is {averageNumberTasksCompleted:F2} completed tasks per day."
                };

                resultList.Add(objTaskPerformanceLast30Days);
            }

            return resultList;
        }
    }
}
