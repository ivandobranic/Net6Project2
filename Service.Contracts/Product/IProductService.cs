using Common.DataTransferObjects.Product;
using Common.RequestFeatures;

namespace Service.Contracts
{
    public interface IProductService
    {
        #region Methods

        Task<(IEnumerable<ProductDto> products, MetaData metaData)> FindProductsAsync(ProductParameters productParameters, bool trackChanges);

        Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);

        Task<ProductDto> CreateProductAsync(Guid productCategoryId, ProductCreateDto product, bool trackChanges);

        Task DeleteProductAsync(Guid id, bool trackChanges);

        Task UpdateProductAsync(Guid id, ProductUpdateDto product, bool trackChanges);

        #endregion Methods
    }
}