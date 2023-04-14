using Common.RequestFeatures;
using Entities.Models;

namespace Contracts
{
    public interface IProductCategoryRepository
    {
        #region Methods

        Task<PagedList<ProductCategory>> FindProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges);

        Task<ProductCategory?> GetProductCategoryAsync(Guid id, bool trackChanges);

        void CreateProductCategory(ProductCategory productCategory);

        #endregion Methods
    }
}