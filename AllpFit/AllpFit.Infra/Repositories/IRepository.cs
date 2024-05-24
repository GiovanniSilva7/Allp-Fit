using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AllpFit.Infra.Repositories
{
    public interface IRepository<T, Y> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        void Delete(T entity);
        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Y id);
        Task<T> GetByIdAsync(params object[] keyValues);
        Task<List<T>> ListAsync();
        Task<List<T>> ListNoTrackingAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> ListNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
    }
}
