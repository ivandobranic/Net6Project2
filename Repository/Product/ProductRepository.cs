using Common.RequestFeatures;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Entities.Models.Product>, IProductRepository
    {
        #region Constructors

        public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Methods

        public async Task<PagedList<Entities.Models.Product>> FindProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = FindAll(trackChanges);
            OnIncludeAsync(ref products, productParameters);
            OnFindFilterAsync(ref products, productParameters);
            OnFindSorterAsync(ref products, productParameters);
            return await TransformResultAsync(products, productParameters);
        }

        public async Task<Entities.Models.Product?> GetProductAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateProduct(Guid productCategoryId, Entities.Models.Product product)
        {
            product.ProductCategoryId = productCategoryId;
            OnEntityCreateOrUpdate(product);
            Create(product);
        }

        public void DeleteProduct(Entities.Models.Product product) => Delete(product);

        private static void OnFindFilterAsync(ref IQueryable<Entities.Models.Product> query, ProductParameters productParameters)
        {
            if (!string.IsNullOrEmpty(productParameters.Search))
            {
                query = query.Where(x => x.Name == productParameters.Search);
            }
            if (productParameters.ProductCategoryId.HasValue)
            {
                query = query.Where(x => x.ProductCategoryId == productParameters.ProductCategoryId.Value);
            }
            if (productParameters.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == productParameters.IsActive.Value);
            }
        }

        private static void OnIncludeAsync(ref IQueryable<Entities.Models.Product> query, ProductParameters productParameters)
        {
            if (!string.IsNullOrEmpty(productParameters.Include))
            {
                if (productParameters.Include.Contains(nameof(Entities.Models.Product.ProductCategory)))
                {
                    query = query.Include(x => x.ProductCategory);
                }
            }
        }

        private static void OnFindSorterAsync(ref IQueryable<Entities.Models.Product> query, ProductParameters productParameters)
        {
            if (!string.IsNullOrEmpty(productParameters.SortBy))
            {
                if (productParameters.SortBy.Equals(nameof(Entities.Models.Product.Name)))
                {
                    query = productParameters.IsAscending == false ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                }
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }
        }

        #endregion Methods
    }
}