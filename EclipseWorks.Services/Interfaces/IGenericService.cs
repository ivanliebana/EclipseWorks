namespace EclipseWorks.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetByIdAsync(long id, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
        Task<T> AddAsync(T entity, CancellationToken ct);
        Task<bool> DeleteAsync(T entity, CancellationToken ct);
        Task<bool> DeleteByIdAsync(long id, CancellationToken ct);
        Task<T> UpdateAsync(T entity, CancellationToken ct);
    }
}
