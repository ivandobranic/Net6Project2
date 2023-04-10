using AutoMapper;
using Common.DataTransferObjects;
using Contracts;
using Entities.Exceptions;
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

        public IEnumerable<ProductCategoryDto> FindProductCategories(bool trackChanges)
        {
            var productCategories = RepositoryManager.ProductCategoryRepository.FindProductCategories(trackChanges);
            var productCategoryDto = Mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories);
            return productCategoryDto;
        }

        public ProductCategoryDto GetProductCategory(Guid id, bool trackChanges)
        {
            var productCategory = RepositoryManager.ProductCategoryRepository.GetProductCategory(id, trackChanges);
            if (productCategory is null)
            {
                throw new ProductCategoryNotFoundException(id);
            }
            var productCategoryDto = Mapper.Map<ProductCategoryDto>(productCategory);
            return productCategoryDto;
        }

        #endregion Methods
    }
}