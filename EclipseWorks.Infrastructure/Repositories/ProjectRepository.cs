using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.Infrastructure.Repositories
{
    public class ProjectRepository(DbContextClass dbContext) : GenericRepository<ProjectModel>(dbContext), IProjectRepository
    {
        public async Task<IEnumerable<ProjectModel>> FindAllByUserAsync(long userId, CancellationToken ct)
        {
            return await _dbContext
                .Set<ProjectModel>()
                .AsNoTracking()
                .Include(i => i.User)
                .Where(x => x.UserId == userId && x.Active)
                .ToListAsync(ct);
        }

        public async Task<ProjectModel> FindByIdAsync(long id, CancellationToken ct, bool includeReference = true)
        {
            if (includeReference)
            {
                return await _dbContext
                .Set<ProjectModel>()
                .AsNoTracking()
                .Include(i => i.Task)
                .FirstOrDefaultAsync(x => x.Id == id && x.Active,
                    cancellationToken: ct);
            }
            else
            {
                return await _dbContext
                    .Set<ProjectModel>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id && x.Active,
                        cancellationToken: ct);
            }
        }

        public async Task<ProjectModel> FindByTitleAsync(string title, CancellationToken ct)
        {
            title = title.RemoveDiacritics();

            return await _dbContext
                .Set<ProjectModel>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Title.ToLower().Equals(title.ToLower())
                    && x.Active,
                    cancellationToken: ct);
        }
    }
}
