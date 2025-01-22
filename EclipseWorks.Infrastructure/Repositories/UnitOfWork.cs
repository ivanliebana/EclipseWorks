using EclipseWorks.Core.Interfaces;

namespace EclipseWorks.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;

        public IProjectRepository Project { get; }
        public IOperationLogRepository OperationLog { get; }
        public ITaskRepository Task { get; }
        public ITaskCommentRepository TaskComment { get; }
        public IUserRepository User { get; }

        public UnitOfWork(DbContextClass dbContext,
                          IOperationLogRepository operationLog,
                          IProjectRepository project,
                          ITaskRepository task,
                          ITaskCommentRepository taskComment,
                          IUserRepository user)
        {
            _dbContext = dbContext;

            OperationLog = operationLog;
            Project = project;
            Task = task;
            TaskComment = taskComment;
            User = user;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return await _dbContext.SaveChangesAsync(ct);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}