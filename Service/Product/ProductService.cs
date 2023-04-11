using AutoMapper;
using Common.DataTransferObjects;
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

        public IEnumerable<ProductDto> FindProducts(bool trackChanges)
        {
            var products = RepositoryManager.ProductRepository.FindProducts(trackChanges);
            return Mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProduct(Guid id, bool trackChanges)
        {
            var product = RepositoryManager.ProductRepository.GetProduct(id, trackChanges);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }
            return Mapper.Map<ProductDto>(product);
        }

        public ProductDto CreateProduct(Guid productCategoryId, ProductCreateDto product, bool trackChanges)
        {
            var productEntity = Mapper.Map<Entities.Models.Product>(product);
            RepositoryManager.ProductRepository.CreateProduct(productCategoryId, productEntity);
            RepositoryManager.Save();
            return Mapper.Map<ProductDto>(productEntity);
        }

        public void DeleteProduct(Guid id, bool trackChanges)
        {
            var product = RepositoryManager.ProductRepository.GetProduct(id, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(id);
            RepositoryManager.ProductRepository.DeleteProduct(product);
            RepositoryManager.Save();
        }

        public void UpdateProduct(Guid id, ProductUpdateDto productUpdate, bool trackChanges)
        {
            var productEntity = RepositoryManager.ProductRepository.GetProduct(id, trackChanges);
            if (productEntity is null)
                throw new ProductNotFoundException(id);
            Mapper.Map(productUpdate, productEntity);
            RepositoryManager.ProductRepository.OnEntityCreateOrUpdate(productEntity);
            RepositoryManager.Save();
        }

        #endregion Methods
    }
}