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

        #region Methods

        public IEnumerable<ProductCategory> FindProductCategories(bool trackChanges) =>
             FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

        public ProductCategory? GetProductCategory(Guid id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

        public void CreateProductCategory(ProductCategory productCategory)
        {
            OnProductCategoryCreateOrUpdate(productCategory);
            Create(productCategory);
        }

        private void OnProductCategoryCreateOrUpdate(ProductCategory productCategory)
        {
            var now = DateTime.UtcNow;
            if (productCategory.DateCreated.Equals(DateTime.MinValue))
            {
                productCategory.DateCreated = now;
            }
            productCategory.DateUpdated = now;
            productCategory.TimeStamp = now;
        }

        #endregion Methods
    }
}