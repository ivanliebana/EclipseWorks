using EclipseWorks.Core.Models;

namespace EclipseWorks.Services.Interfaces
{
    public interface ITaskService : IGenericService<TaskModel>
    {
        Task UpdateStatusAsync(TaskModel entity, CancellationToken ct);
        Task RemoveAllByProjectAsync(long projectId, CancellationToken ct);
        Task<IEnumerable<TaskModel>> GetAllByProjectAsync(long projectId, CancellationToken ct);
    }
}