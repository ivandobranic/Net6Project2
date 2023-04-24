using Common.DataTransferObjects.Product;
using Common.RequestFeatures;

namespace Service.Contracts
{
    public interface IProductCategoryService
    {
        #region Methods

        Task<(IEnumerable<ProductCategoryDto> productCategories, MetaData metaData)> FindProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges);

        Task<ProductCategoryDto> GetProductCategoryAsync(Guid id, bool trackChanges);

        Task<ProductCategoryDto> CreateProductCategoryAsync(ProductCategoryCreateDto productCategory);

        #endregion Methods
    }
}