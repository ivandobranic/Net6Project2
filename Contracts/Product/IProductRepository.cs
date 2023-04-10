using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        #region Methods

        IEnumerable<Product> FindProducts(bool trackChanges);

        Product? GetProduct(Guid id, bool trackChanges);

        #endregion Methods
    }
}