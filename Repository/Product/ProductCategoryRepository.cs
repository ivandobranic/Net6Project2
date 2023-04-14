﻿using Common.RequestFeatures;
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
            var productCategories = await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
            return PagedList<ProductCategory>.ToPagedList(productCategories, productCategoryParameters.PageNumber, productCategoryParameters.PageSize);
        }

        public async Task<ProductCategory?> GetProductCategoryAsync(Guid id, bool trackChanges) =>
           await FindByCondition(c => c.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

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

        #endregion Methods
    }
}