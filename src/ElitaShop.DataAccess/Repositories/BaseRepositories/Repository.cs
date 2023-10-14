using ElitaShop.DataAccess.Paginations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElitaShop.DataAccess.Repositories.BaseRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ElitaShopDbContext _dbContext;
        protected DbSet<T> _entitySet;
        public Repository(ElitaShopDbContext elitaShopDbContext)
        {
            _dbContext = elitaShopDbContext;
            _entitySet = _dbContext.Set<T>();

        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddRangeAsync(entities, cancellationToken);
        }

        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return _entitySet.AsNoTracking().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entitySet.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _entitySet.Where(expression).AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetPageItemsAsync(PaginationParams paginationParams)
        {
            return await _entitySet.Skip(paginationParams.GetSkipCount()).Take(paginationParams.PageSize).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entitySet.ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitySet.Where(expression).ToListAsync(cancellationToken);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitySet.FirstOrDefaultAsync(expression, cancellationToken);
        }

        public void Remove(T entity)
        {
            _entitySet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entitySet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _entitySet.Update(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
            
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _entitySet.UpdateRange(entities);
        }
    }
}
