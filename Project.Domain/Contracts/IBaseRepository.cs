using System.Linq.Expressions;

namespace Project.Domain.Repositories
{
    /// <summary>
    /// Generic repository is used for CRUD operations
    /// Can be added more methods depending on requirements
    /// </summary>
    /// <typeparam name="T">Entity class</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        IQueryable<T> GetAll();

        Task<T?> GetById(object id);

        Task<T?> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
