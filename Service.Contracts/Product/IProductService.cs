using Common.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductService
    {
        #region Methods

        IEnumerable<ProductDto> FindProducts(bool trackChanges);

        ProductDto GetProduct(Guid id, bool trackChanges);

        #endregion Methods
    }
}