using Common.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductService
    {
        #region Methods

        IEnumerable<ProductDto> FindProducts(bool trackChanges);

        ProductDto GetProduct(Guid id, bool trackChanges);

        ProductDto CreateProduct(Guid productCategoryId, ProductCreateDto product, bool trackChanges);

        void DeleteProduct(Guid id, bool trackChanges);

        void UpdateProduct(Guid id, ProductUpdateDto product, bool trackChanges);

        #endregion Methods
    }
}