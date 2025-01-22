using EclipseWorks.Core.Models;

namespace EclipseWorks.Core.Interfaces
{
    public interface IProjectRepository : IGenericRepository<ProjectModel>
    {
        Task<ProjectModel> FindByIdAsync(long id, CancellationToken ct, bool includeReference = true);

        Task<ProjectModel> FindByTitleAsync(string title, CancellationToken ct);

        Task<IEnumerable<ProjectModel>> FindAllByUserAsync(long userId, CancellationToken ct);
    }
}
