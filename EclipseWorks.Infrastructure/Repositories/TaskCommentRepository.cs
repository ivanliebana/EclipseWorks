using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;

namespace EclipseWorks.Infrastructure.Repositories
{
    public class TaskCommentRepository(DbContextClass dbContext) : GenericRepository<TaskCommentModel>(dbContext), ITaskCommentRepository
    {
    }
}
