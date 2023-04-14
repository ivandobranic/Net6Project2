using Common.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductService
    {
        #region Methods

        Task<IEnumerable<ProductDto>> FindProductsAsync(bool trackChanges);

        Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);

        Task<ProductDto> CreateProductAsync(Guid productCategoryId, ProductCreateDto product, bool trackChanges);

        Task DeleteProductAsync(Guid id, bool trackChanges);

        Task UpdateProductAsync(Guid id, ProductUpdateDto product, bool trackChanges);

        #endregion Methods
    }
}