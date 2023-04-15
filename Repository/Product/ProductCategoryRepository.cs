using Common.RequestFeatures;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        #region Constructors

        public ProductCategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Methods

        public async Task<PagedList<ProductCategory>> FindProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges)
        {
            var productCategories = FindAll(trackChanges);
            OnIncludeAsync(ref productCategories, productCategoryParameters);
            OnFindFilterAsync(ref productCategories, productCategoryParameters);
            OnFindSorterAsync(ref productCategories, productCategoryParameters);
            return await TransformResultAsync(productCategories, productCategoryParameters);
        }

        public async Task<ProductCategory?> GetProductCategoryAsync(Guid id, bool trackChanges) =>
           await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateProductCategory(ProductCategory productCategory)
        {
            OnEntityCreateOrUpdate(productCategory);
            if (productCategory.Products?.Any() == true)
            {
                foreach (var product in productCategory.Products)
                {
                    OnEntityCreateOrUpdate(product);
                }
            }
            Create(productCategory);
        }

        private static void OnFindFilterAsync(ref IQueryable<ProductCategory> query, ProductCategoryParameters productCategoryParameters)
        {
            if (!string.IsNullOrEmpty(productCategoryParameters.Search))
            {
                query = query.Where(x => x.Name == productCategoryParameters.Search);
            }
            if (productCategoryParameters.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == productCategoryParameters.IsActive.Value);
            }
        }

        private static void OnIncludeAsync(ref IQueryable<ProductCategory> query, ProductCategoryParameters productCategoryParameters)
        {
            if (!string.IsNullOrEmpty(productCategoryParameters.Include))
            {
                if (productCategoryParameters.Include.Contains(nameof(ProductCategory.Products)))
                {
                    query = query.Include(x => x.Products);
                }
            }
        }

        private static void OnFindSorterAsync(ref IQueryable<ProductCategory> query, ProductCategoryParameters productCategoryParameters)
        {
            if (!string.IsNullOrEmpty(productCategoryParameters.SortBy))
            {
                if (productCategoryParameters.SortBy.Equals(nameof(ProductCategory.Name)))
                {
                    query = productCategoryParameters.IsAscending == false ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
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