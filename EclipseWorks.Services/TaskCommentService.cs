using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Services.Interfaces;
using System.Transactions;

namespace EclipseWorks.Services
{
    public class TaskCommentService(
        IUnitOfWork unitOfWork,
        ITaskService taskService,
        IUserService userService,
        IProjectService projectService) : ITaskCommentService
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITaskService _taskService = taskService;
        private readonly IUserService _userService = userService;
        private readonly IProjectService _projectService = projectService;

        public async Task<TaskCommentModel> AddAsync(TaskCommentModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            await _unitOfWork.TaskComment.AddAsync(entity, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            scope.Complete();

            return entity;
        }

        public async Task<bool> DeleteAsync(TaskCommentModel entity, CancellationToken ct)
        {
            CustomException.When(entity.Id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.TaskComment.FindOneAsync(x => x.Id == entity.Id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("TaskComments", "Id"));

            _unitOfWork.TaskComment.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(long id, CancellationToken ct)
        {
            CustomException.When(id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.TaskComment.FindOneAsync(x => x.Id == id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("TaskComments", "Id"));

            _unitOfWork.TaskComment.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<IEnumerable<TaskCommentModel>> GetAllAsync(CancellationToken ct)
        {
            var list = await _unitOfWork.TaskComment.FindListAsync(x => x.Id > 0, ct);
            return list;
        }

        public async Task<TaskCommentModel> GetByIdAsync(long id, CancellationToken ct)
        {
            if (id > 0)
            {
                var TaskComments = await _unitOfWork.TaskComment.FindOneAsync(x => x.Id == id, ct);

                if (TaskComments != null)
                    return TaskComments;
            }

            return null;
        }

        public async Task<TaskCommentModel> UpdateAsync(TaskCommentModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            var obj = await _unitOfWork.TaskComment.FindOneAsync(x => x.Id == entity.Id, ct, new Core.FindOptions { IsAsNoTracking = true });
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("TaskComments", "Id"));

            _unitOfWork.TaskComment.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return obj;
        }

        private async Task Validation(TaskCommentModel entity, CancellationToken ct)
        {
            CustomException.When(entity == null, "'TaskComment' information not filled in correctly.");

            #region TASK

            if (entity.Id <= 0)
            {
                CustomException.When(entity.TaskId <= 0, Message.MSG0016("Task Id"));
                var task = await _taskService.GetByIdAsync(entity.TaskId, ct);
                CustomException.When(task == null || task.Id <= 0 || !task.Active, Message.MSG0049("Task", "Id"));

                var project = await _projectService.GetByIdAsync(task.ProjectId, ct);
                CustomException.When(project == null || project.Id <= 0 || !project.Active, Message.MSG0049("Task", "Id"));
            }

            #endregion

            #region USER

            if (entity.Id <= 0)
            {
                CustomException.When(entity.AuthorId <= 0, Message.MSG0016("Author Id"));
                var user = await _userService.GetByIdAsync(entity.AuthorId, ct);
                CustomException.When(user == null || user.Id <= 0, Message.MSG0049("User", "Id"));
            }

            #endregion

            #region COMMENT

            entity.Comment = entity.Comment?.Trim();

            CustomException.Required(entity.Comment, Message.MSG0016("Comment"));
            CustomException.MaxLength(entity.Comment.Length, 800, Message.MSG0014("Comment", 800));
            CustomException.MinLength(entity.Comment.Length, 3, Message.MSG0015("Comment", 3));

            #endregion
        }
    }
}