using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        #region Methods

        Task<IEnumerable<Product>> FindProductsAsync(bool trackChanges);

        Task<Product?> GetProductAsync(Guid id, bool trackChanges);

        void CreateProduct(Guid productCategoryId, Entities.Models.Product product);

        void DeleteProduct(Product product);

        void OnEntityCreateOrUpdate(BaseModel productCategory);

        #endregion Methods
    }
}