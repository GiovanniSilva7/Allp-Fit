namespace AllpFit.Infra.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(bool dispatchEvents = true);
        void Reset();
        void ResetEntity<TEntity>(TEntity entity) where TEntity : class;
        void Clear();
    }
}
