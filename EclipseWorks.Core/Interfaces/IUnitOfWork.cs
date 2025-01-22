namespace EclipseWorks.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOperationLogRepository OperationLog { get; }
        IProjectRepository Project { get; }
        ITaskRepository Task { get; }
        ITaskCommentRepository TaskComment { get; }
        IUserRepository User { get; }

        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}