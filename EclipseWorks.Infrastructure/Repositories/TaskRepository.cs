using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper.Enums;
using EclipseWorks.Helper.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.Infrastructure.Repositories
{
    public class TaskRepository(DbContextClass dbContext) : GenericRepository<TaskModel>(dbContext), ITaskRepository
    {
        public async Task<IEnumerable<TaskModel>> FindAllByProjectAsync(long projectId, CancellationToken ct)
        {
            return await _dbContext
                .Set<TaskModel>()
                .AsNoTracking()
                .Include(i => i.Project)
                .Where(x => x.ProjectId == projectId && x.Active)
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<TaskModel>> FindAllPendingByProjectAsync(long projectId, CancellationToken ct)
        {
            return await _dbContext
                .Set<TaskModel>()
                .AsNoTracking()
                .Include(i => i.Project)
                .Where(x => 
                    x.ProjectId == projectId &&
                    x.Active &&
                    (x.TaskStatusId == (short)eTaskStatus.Pending || x.TaskStatusId == (short)eTaskStatus.InProgress))
                .ToListAsync(ct);
        }

        public async Task<TaskModel> FindByTitleAsync(string title, CancellationToken ct)
        {
            title = title.RemoveDiacritics();

            return await _dbContext
                .Set<TaskModel>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Title.ToLower().Equals(title.ToLower())
                    && x.Active,
                    cancellationToken: ct);
        }

        public async Task RemoveAllByProjectAsync(long projectId, CancellationToken ct)
        {
            var list = await _dbContext
                 .Set<TaskModel>()
                 .AsNoTracking()
                 .Where(x => x.ProjectId == projectId && x.Active)
                 .ToListAsync(ct);

            if (list != null && list.Count > 0)
            {
                list.ForEach(a =>
                {
                    a.Active = false;
                    Update(a);
                });
            }
        }
    }
}
