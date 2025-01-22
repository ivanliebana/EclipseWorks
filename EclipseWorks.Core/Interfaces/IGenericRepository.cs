using System.Linq.Expressions;

namespace EclipseWorks.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ExecuteQueryListAsync(IQueryable<T> query, CancellationToken ct);
        IQueryable<T> GetQuery(FindOptions findOptions = null);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, CancellationToken ct, FindOptions findOptions = null);
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> predicate, CancellationToken ct, FindOptions findOptions = null);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, FindOptions findOptions = null);
        Task AddAsync(T entity, CancellationToken ct);
        Task AddManyAsync(IEnumerable<T> entities, CancellationToken ct);
        void Update(T entity);
        void Delete(T entity);
        void DeleteMany(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);
    }
}