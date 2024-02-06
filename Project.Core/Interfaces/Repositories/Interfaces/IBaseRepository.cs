namespace Project.Core.Interfaces.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        IQueryable<T> GetAll();

        Task<T> Get(object id, CancellationToken cancellationToken = default);

        void Remove(T entity);

        void RemoveRange(params T[] entities);

        void Update(T entity);

        void UpdateRange(params T[] entities);

        Task Save(CancellationToken cancellationToken = default);
    }
}
