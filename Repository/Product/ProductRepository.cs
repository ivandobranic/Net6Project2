using Common.RequestFeatures;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PagedList<Product>> FindProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
            return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task<Product?> GetProductAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
           .SingleOrDefaultAsync();

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