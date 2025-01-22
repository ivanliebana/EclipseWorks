using EclipseWorks.Core.Models;

namespace EclipseWorks.Core.Interfaces
{
    public interface ITaskRepository : IGenericRepository<TaskModel>
    {
        Task RemoveAllByProjectAsync(long projectId, CancellationToken ct);

        Task<IEnumerable<TaskModel>> FindAllByProjectAsync(long projectId, CancellationToken ct);

        Task<TaskModel> FindByTitleAsync(string title, CancellationToken ct);
    }
}