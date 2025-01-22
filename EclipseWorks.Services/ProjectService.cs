using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Enums;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Services.Interfaces;
using System.Transactions;

namespace EclipseWorks.Services
{
    public class ProjectService(
        IUnitOfWork unitOfWork,
        IUserService userService,
        Lazy<ITaskService> taskService) : IProjectService
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserService _userService = userService;
        private readonly Lazy<ITaskService> _taskService = taskService;

        public async Task<ProjectModel> AddAsync(ProjectModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            await _unitOfWork.Project.AddAsync(entity, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            scope.Complete();

            return entity;
        }

        public async Task<bool> DeleteAsync(ProjectModel entity, CancellationToken ct)
        {
            CustomException.When(entity.Id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.Project.FindOneAsync(x => x.Id == entity.Id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Project", "Id"));
            CustomException.When(obj.Task != null && obj.Task.Where(x => x.TaskStatusId == (short)eTaskStatus.Pending || x.TaskStatusId == (short)eTaskStatus.InProgress).Any(), "The project cannot be removed because there are still pending tasks associated with it. Please complete or remove pending tasks before proceeding");

            obj.Active = false;

            await _taskService.Value.RemoveAllByProjectAsync(obj.Id, ct);

            _unitOfWork.Project.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(long id, CancellationToken ct)
        {
            CustomException.When(id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.Project.FindByIdAsync(id, ct, false);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Project", "Id"));
            CustomException.When(obj.Task != null && obj.Task.Where(x => x.TaskStatusId == (short)eTaskStatus.Pending || x.TaskStatusId == (short)eTaskStatus.InProgress).Any(), "The project cannot be removed because there are still pending tasks associated with it. Please complete or remove pending tasks before proceeding");

            obj.Active = false;

            await _taskService.Value.RemoveAllByProjectAsync(obj.Id, ct);

            _unitOfWork.Project.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync(CancellationToken ct)
        {
            var list = await _unitOfWork.Project.FindListAsync(x => x.Id > 0, ct);
            return list;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllByUserAsync(long userId, CancellationToken ct)
        {
            CustomException.When(userId <= 0, Message.MSG0016("UserId"));
            var user = await _userService.GetByIdAsync(userId, ct);
            CustomException.When(user == null || user.Id <= 0, Message.MSG0049("User", "Id"));

            return await _unitOfWork.Project.FindAllByUserAsync(userId, ct);
        }

        public async Task<ProjectModel> GetByIdAsync(long id, CancellationToken ct)
        {
            if (id > 0)
            {
                var obj = await _unitOfWork.Project.FindByIdAsync(id, ct);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        public async Task<ProjectModel> UpdateAsync(ProjectModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            var obj = await _unitOfWork.Project.FindOneAsync(x => x.Id == entity.Id, ct, new Core.FindOptions { IsAsNoTracking = true });
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Projects", "Id"));

            obj.Title = entity.Title;

            _unitOfWork.Project.Update(obj);

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

        public async Task<ProjectModel> GetByTitleAsync(string title, CancellationToken ct)
        {
            if (!title.IsNullOrEmpty())
            {
                var obj = await _unitOfWork.Project.FindByTitleAsync(title, ct);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        private async Task Validation(ProjectModel entity, CancellationToken ct)
        {
            CustomException.When(entity == null, "'Project' information not filled in correctly.");

            #region USER

            if (entity.Id <= 0)
            {
                CustomException.When(entity.UserId <= 0, Message.MSG0016("UserId"));
                var user = await _userService.GetByIdAsync(entity.UserId, ct);
                CustomException.When(user == null || user.Id <= 0, Message.MSG0049("User", "Id"));
            }

            #endregion

            #region TITLE

            entity.Title = entity.Title?.Trim();

            CustomException.Required(entity.Title, Message.MSG0016("Title"));
            CustomException.MaxLength(entity.Title.Length, 150, Message.MSG0014("Title", 150));
            CustomException.MinLength(entity.Title.Length, 3, Message.MSG0015("Title", 3));

            var titleAlreadyExists = await ValidateIfTitleAlreadyExists(entity.Title, entity.Id, ct);
            CustomException.When(titleAlreadyExists, Message.MSG0055("Title"));

            #endregion
        }
    }
}
