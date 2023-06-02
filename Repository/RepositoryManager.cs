using Contracts;
using Contracts.Product;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        #region Fields

        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IProductStatusRepository> _productStatusRepository;

        #endregion Fields

        #region Constructors

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new
            ProductCategoryRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new
            ProductRepository(repositoryContext));
            _productStatusRepository = new Lazy<IProductStatusRepository>(() => new
           ProductStatusRepository(repositoryContext));
        }

        #endregion Constructors

        #region Properties

        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository.Value;
        public IProductRepository ProductRepository => _productRepository.Value;
        public IProductStatusRepository ProductStatusRepository => _productStatusRepository.Value;

        #endregion Properties

        #region Methods

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        #endregion Methods
    }
}