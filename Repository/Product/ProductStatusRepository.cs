using Contracts.Product;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductStatusRepository : RepositoryBase<ProductStatus>, IProductStatusRepository
    {
        #region Constructors

        public ProductStatusRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Methods

        public async Task<IEnumerable<ProductStatus>> FindProductStatusAsync()
        {
            return await FindAll(false).ToArrayAsync();
        }

        #endregion Methods
    }
}