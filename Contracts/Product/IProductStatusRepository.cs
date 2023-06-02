using Entities.Models;

namespace Contracts.Product
{
    public interface IProductStatusRepository
    {
        #region Methods

        Task<IEnumerable<ProductStatus>> FindProductStatusAsync();

        #endregion Methods
    }
}