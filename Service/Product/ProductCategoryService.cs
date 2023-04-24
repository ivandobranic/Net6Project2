using AutoMapper;
using Common.DataTransferObjects.Product;
using Common.RequestFeatures;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    internal sealed class ProductCategoryService : IProductCategoryService
    {
        #region Constructors

        public ProductCategoryService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
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

        public async Task<(IEnumerable<ProductCategoryDto> productCategories, MetaData metaData)> FindProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges)
        {
            var productCategories = await RepositoryManager.ProductCategoryRepository.FindProductCategoriesAsync(productCategoryParameters, trackChanges);
            var productCategoryDto = Mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories);
            return (productCategories: productCategoryDto, metaData: productCategories.MetaData);
        }

        public async Task<ProductCategoryDto> GetProductCategoryAsync(Guid id, bool trackChanges)
        {
            var productCategory = await RepositoryManager.ProductCategoryRepository.GetProductCategoryAsync(id, trackChanges);
            if (productCategory is null)
            {
                throw new ProductCategoryNotFoundException(id);
            }
            var productCategoryDto = Mapper.Map<ProductCategoryDto>(productCategory);
            return productCategoryDto;
        }

        public async Task<ProductCategoryDto> CreateProductCategoryAsync(ProductCategoryCreateDto productCategory)
        {
            var productCategoryEntity = Mapper.Map<ProductCategory>(productCategory);
            RepositoryManager.ProductCategoryRepository.CreateProductCategory(productCategoryEntity);
            await RepositoryManager.SaveAsync();
            return Mapper.Map<ProductCategoryDto>(productCategoryEntity);
        }

        #endregion Methods
    }
}