using Entities.Models;

namespace Contracts
{
    public interface IProductCategoryRepository
    {
        #region Methods

        IEnumerable<ProductCategory> FindProductCategories(bool trackChanges);

        ProductCategory? GetProductCategory(Guid id, bool trackChanges);

        #endregion Methods
    }
}