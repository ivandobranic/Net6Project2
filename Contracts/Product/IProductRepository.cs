using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        #region Methods

        IEnumerable<Product> FindProducts(bool trackChanges);

        Product? GetProduct(Guid id, bool trackChanges);

        void CreateProduct(Guid productCategoryId, Entities.Models.Product product);

        void DeleteProduct(Product product);

        void OnEntityCreateOrUpdate(BaseModel productCategory);

        #endregion Methods
    }
}