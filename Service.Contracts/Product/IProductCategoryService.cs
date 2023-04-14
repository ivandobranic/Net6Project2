using Common.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductCategoryService
    {
        #region Methods

        Task<IEnumerable<ProductCategoryDto>> FindProductCategoriesAsync(bool trackChanges);

        Task<ProductCategoryDto> GetProductCategoryAsync(Guid id, bool trackChanges);

        Task<ProductCategoryDto> CreateProductCategoryAsync(ProductCategoryCreateDto productCategory);

        #endregion Methods
    }
}