using EclipseWorks.Core;
using EclipseWorks.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EclipseWorks.Infrastructure.Repositories
{
    public abstract class GenericRepository<T>(DbContextClass context) : IGenericRepository<T> where T : class
    {
        protected readonly DbContextClass _dbContext = context;

        public async Task AddAsync(T entity, CancellationToken ct)
        {
            await _dbContext.Set<T>().AddAsync(entity, ct);
        }

        public async Task AddManyAsync(IEnumerable<T> entities, CancellationToken ct)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities, ct);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate, ct);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
        {
            return await _dbContext.Set<T>().CountAsync(predicate, ct);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteMany(Expression<Func<T, bool>> predicate)
        {
            var entities = Find(predicate);
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, FindOptions findOptions = null)
        {
            return Get(findOptions).Where(predicate);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, CancellationToken ct, FindOptions findOptions = null)
        {
            var entity = await Get(findOptions).FirstOrDefaultAsync(predicate, ct);

            if (findOptions != null && findOptions.DetachState)
                _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public IQueryable<T> GetQuery(FindOptions findOptions = null)
        {
            return Get(findOptions);
        }

        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> predicate, CancellationToken ct, FindOptions findOptions = null)
        {
            return await Get(findOptions).Where(predicate).ToListAsync(ct);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        private DbSet<T> Get(FindOptions findOptions = null)
        {
            findOptions ??= new FindOptions();
            var entity = _dbContext.Set<T>();

            if (findOptions.IsAsNoTracking && findOptions.IsIgnoreAutoIncludes)
                entity.IgnoreAutoIncludes().AsNoTracking();
            else if (findOptions.IsIgnoreAutoIncludes)
                entity.IgnoreAutoIncludes();
            else if (findOptions.IsAsNoTracking)
                entity.AsNoTracking();

            return entity;
        }

        public async Task<IEnumerable<T>> ExecuteQueryListAsync(IQueryable<T> query, CancellationToken ct)
        {
            return await query.ToListAsync(ct);
        }
    }
}
