using Microsoft.EntityFrameworkCore;
using Project.Domain.Repositories;
using Project.Persistence.Databases;
using System.Linq.Expressions;

namespace Project.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => true);
        }

        public async Task<T?> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
