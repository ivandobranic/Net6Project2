using Contracts;
using Entities.Models;

namespace Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        #region Constructors

        public ProductCategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #endregion Constructors
    }
}