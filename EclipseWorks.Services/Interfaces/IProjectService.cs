using EclipseWorks.Core.Models;

namespace EclipseWorks.Services.Interfaces
{
    public interface IProjectService : IGenericService<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> GetAllByUserAsync(long userId, CancellationToken ct);
    }
}
