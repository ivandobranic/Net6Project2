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
    }
}