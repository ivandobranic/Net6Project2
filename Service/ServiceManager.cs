using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        #region Fields

        private readonly Lazy<IProductCategoryService> _productCategoryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        #endregion Fields

        #region Constructors

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _productCategoryService = new Lazy<IProductCategoryService>(() => new ProductCategoryService(repositoryManager, logger, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        #endregion Constructors

        #region Properties

        public IProductCategoryService ProductCategoryService => _productCategoryService.Value;
        public IProductService ProductService => _productService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        #endregion Properties
    }
}