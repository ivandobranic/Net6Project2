using Contracts;
using Repository.Product;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        #region Fields

        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<IProductRepository> _productRepository;

        #endregion Fields

        #region Constructors

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new
            ProductCategoryRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new
            ProductRepository(repositoryContext));
        }

        #endregion Constructors

        #region Properties

        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository.Value;
        public IProductRepository ProductRepository => _productRepository.Value;

        #endregion Properties

        #region Methods

        public void Save() => _repositoryContext.SaveChanges();

        #endregion Methods
    }
}