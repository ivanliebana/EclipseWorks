using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;

namespace EclipseWorks.Infrastructure.Repositories
{
    public class OperationLogRepository(DbContextClass dbContext) : GenericRepository<OperationLogModel>(dbContext), IOperationLogRepository
    {
    }
}