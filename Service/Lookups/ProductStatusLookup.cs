using Common.Extensions;
using Contracts;
using Entities.Models;
using Microsoft.Extensions.Caching.Distributed;
using Service.Contracts;

namespace Service.Lookups
{
    public class ProductStatusLookup : IProductStatusLookup
    {
        #region Fields

        protected const string CacheKey = "ProductStatus-Lookup";

        #endregion Fields

        #region Constructors

        public ProductStatusLookup(IDistributedCache cache, IRepositoryManager repositoryManager)
        {
            Active = new Lazy<Task<ProductStatus?>>(async () =>
            {
                return (await GetItemsAsync()).SingleOrDefault(p => p.Abrv == "active");
            });

            Inactive = new Lazy<Task<ProductStatus?>>(async () =>
            {
                return (await GetItemsAsync()).SingleOrDefault(p => p.Abrv == "inactive");
            });

            Cache = cache;
            RepositoryManager = repositoryManager;
        }

        #endregion Constructors

        #region Properties

        public Lazy<Task<ProductStatus?>> Active { get; }

        public Lazy<Task<ProductStatus?>> Inactive { get; }

        public IRepositoryManager RepositoryManager { get; }

        private IDistributedCache Cache { get; }

        #endregion Properties

        #region Methods

        public virtual async Task<IEnumerable<ProductStatus>> GetItemsAsync()
        {
            return await Cache.TryGetValue<IEnumerable<ProductStatus>>(CacheKey) ?? await RepositoryManager.ProductStatusRepository.FindProductStatusAsync();
        }

        public virtual async Task InvalidateItemsAsync()
        {
            await Cache.RemoveAsync(CacheKey);
        }

        #endregion Methods
    }
}