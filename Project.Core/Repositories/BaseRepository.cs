using Project.Core.Repositories.Interfaces;

namespace Project.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        // Add the DbContext and DbSet in the constructor
        public BaseRepository()
        {
            
        }

        public Task Add(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public Task Save(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(params T[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
