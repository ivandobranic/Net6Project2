using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Service.Lookups;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        #region Fields

        private readonly Lazy<IProductCategoryService> _productCategoryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IProductStatusLookup> _productStatusLookup;

        #endregion Fields

        #region Constructors

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IDistributedCache cache)
        {
            _productCategoryService = new Lazy<IProductCategoryService>(() => new ProductCategoryService(repositoryManager, logger, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
            _productStatusLookup = new Lazy<IProductStatusLookup>(() => new ProductStatusLookup(cache, repositoryManager));
        }

        #endregion Constructors

        #region Properties

        public IProductCategoryService ProductCategoryService => _productCategoryService.Value;
        public IProductService ProductService => _productService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IProductStatusLookup ProductStatusLookup => _productStatusLookup.Value;

        #endregion Properties
    }
}