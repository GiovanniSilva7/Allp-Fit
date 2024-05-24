using AllpFit.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AllpFit.Infra.Repositories
{
    public class Repository<T, Y> : IRepository<T,Y> where T : class
    {
        #region Read-only fields

        protected readonly ApplicationDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion


        public virtual async Task AddAsync(T entity) =>
            await _dbContext.Set<T>().AddAsync(entity);

        public virtual async Task AddRangeAsync(List<T> entities) =>
            await _dbContext.Set<T>().AddRangeAsync(entities);

        public virtual async Task<bool> AnyAsync() =>
            await _dbContext.Set<T>().AnyAsync();

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().AnyAsync(expression);

        public virtual void Delete(T entity) =>
            _dbContext.Set<T>().Remove(entity);

        public virtual async Task<T> FirstOrDefaultAsync() =>
            await _dbContext.Set<T>().FirstOrDefaultAsync();

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().FirstOrDefaultAsync(expression);

        public virtual async Task<T> FirstOrDefaultNoTrackingAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);

        public virtual async Task<T> GetByIdAsync(Y id) =>
            await _dbContext.Set<T>().FindAsync(id);

        public virtual async Task<T> GetByIdAsync(params object[] keyValues) =>
            await _dbContext.Set<T>().FindAsync(keyValues);

        public virtual async Task<List<T>> ListAsync() =>
            await _dbContext.Set<T>().ToListAsync();
        public virtual async Task<List<T>> ListNoTrackingAsync() =>
            await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public virtual async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().Where(expression).ToListAsync();

        public virtual async Task<List<T>> ListNoTrackingAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();

        public virtual async Task<int> CountAsync() =>
            await _dbContext.Set<T>().CountAsync();

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().Where(expression).CountAsync();
    }
}
