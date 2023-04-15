using Common.RequestFeatures;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Fields

        protected RepositoryContext RepositoryContext;

        #endregion Fields

        #region Constructors

        public RepositoryBase(RepositoryContext repositoryContext)
        => RepositoryContext = repositoryContext;

        #endregion Constructors

        #region Methods

        public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
        RepositoryContext.Set<T>()
        .AsNoTracking() :
        RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges ?
        RepositoryContext.Set<T>()
        .Where(expression)
        .AsNoTracking() :
        RepositoryContext.Set<T>()
        .Where(expression);

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public void OnEntityCreateOrUpdate(BaseModel productCategory)
        {
            var now = DateTime.UtcNow;
            if (productCategory.DateCreated.Equals(DateTime.MinValue))
            {
                productCategory.DateCreated = now;
            }
            productCategory.DateUpdated = now;
            productCategory.TimeStamp = now;
        }

        protected async Task<PagedList<T>> TransformResultAsync(IQueryable<T> query, RequestParameters parameters)
        {
            var totalCount = await query.CountAsync();
            var entities = await query.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize).ToListAsync();
            return new PagedList<T>(entities, totalCount, parameters.PageNumber, parameters.PageSize);
        }

        #endregion Methods
    }
}