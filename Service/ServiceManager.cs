using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        #region Fields

        private readonly Lazy<IProductCategoryService> _productCategoryService;
        private readonly Lazy<IProductService> _productService;

        #endregion Fields

        #region Constructors

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
        {
            _productCategoryService = new Lazy<IProductCategoryService>(() => new
            ProductCategoryService(repositoryManager, logger, mapper));
            _productService = new Lazy<IProductService>(() => new
            ProductService(repositoryManager, logger, mapper));
        }

        #endregion Constructors

        #region Properties

        public IProductCategoryService ProductCategoryService => _productCategoryService.Value;
        public IProductService ProductService => _productService.Value;

        #endregion Properties
    }
}