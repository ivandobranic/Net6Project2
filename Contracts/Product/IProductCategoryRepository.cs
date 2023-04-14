using Entities.Models;

namespace Contracts
{
    public interface IProductCategoryRepository
    {
        #region Methods

        Task<IEnumerable<ProductCategory>> FindProductCategoriesAsync(bool trackChanges);

        Task<ProductCategory?> GetProductCategoryAsync(Guid id, bool trackChanges);

        void CreateProductCategory(ProductCategory productCategory);

        #endregion Methods
    }
}