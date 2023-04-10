using Contracts;

namespace Repository.Product
{
    public class ProductRepository : RepositoryBase<Entities.Models.Product>, IProductRepository
    {
        #region Constructors

        public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Methods

        public IEnumerable<Entities.Models.Product> FindProducts(bool trackChanges) =>
            FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToList();

        public Entities.Models.Product? GetProduct(Guid id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
           .SingleOrDefault();

        #endregion Methods
    }
}