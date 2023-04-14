﻿using AutoMapper;
using Common.DataTransferObjects;
using Common.RequestFeatures;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        #region Constructors

        public ProductService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            RepositoryManager = repositoryManager;
            LoggerManager = logger;
            Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        public IRepositoryManager RepositoryManager { get; set; }

        public ILoggerManager LoggerManager { get; set; }

        public IMapper Mapper { get; set; }

        #endregion Properties

        #region Methods

        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> FindProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await RepositoryManager.ProductRepository.FindProductsAsync(productParameters, trackChanges);
            var productsDto = Mapper.Map<IEnumerable<ProductDto>>(products);
            return (products: productsDto, metaData: products.MetaData);
        }

        public async Task<ProductDto> GetProductAsync(Guid id, bool trackChanges)
        {
            var product = await RepositoryManager.ProductRepository.GetProductAsync(id, trackChanges);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }
            return Mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(Guid productCategoryId, ProductCreateDto product, bool trackChanges)
        {
            var productEntity = Mapper.Map<Entities.Models.Product>(product);
            RepositoryManager.ProductRepository.CreateProduct(productCategoryId, productEntity);
            await RepositoryManager.SaveAsync();
            return Mapper.Map<ProductDto>(productEntity);
        }

        public async Task DeleteProductAsync(Guid id, bool trackChanges)
        {
            var product = await RepositoryManager.ProductRepository.GetProductAsync(id, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(id);
            RepositoryManager.ProductRepository.DeleteProduct(product);
            await RepositoryManager.SaveAsync();
        }

        public async Task UpdateProductAsync(Guid id, ProductUpdateDto productUpdate, bool trackChanges)
        {
            var productEntity = await RepositoryManager.ProductRepository.GetProductAsync(id, trackChanges);
            if (productEntity is null)
                throw new ProductNotFoundException(id);
            Mapper.Map(productUpdate, productEntity);
            RepositoryManager.ProductRepository.OnEntityCreateOrUpdate(productEntity);
            await RepositoryManager.SaveAsync();
        }

        #endregion Methods
    }
}