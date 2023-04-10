using Common.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductCategoryService
    {
        #region Methods

        IEnumerable<ProductCategoryDto> FindProductCategories(bool trackChanges);

        ProductCategoryDto GetProductCategory(Guid id, bool trackChanges);

        #endregion Methods
    }
}