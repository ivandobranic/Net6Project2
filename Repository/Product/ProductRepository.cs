using Contracts;
using Entities.Models;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        #region Constructors

        public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Methods

        public IEnumerable<Product> FindProducts(bool trackChanges) =>
            FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToList();

        public Product? GetProduct(Guid id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
           .SingleOrDefault();

        public void CreateProduct(Guid productCategoryId, Product product)
        {
            product.ProductCategoryId = productCategoryId;
            OnEntityCreateOrUpdate(product);
            Create(product);
        }

        public void DeleteProduct(Product product) => Delete(product);

        #endregion Methods
    }
}