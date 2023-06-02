using Contracts.Product;

namespace Contracts
{
    public interface IRepositoryManager
    {
        #region Properties

        IProductCategoryRepository ProductCategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        IProductStatusRepository ProductStatusRepository { get; }

        #endregion Properties

        #region Methods

        Task SaveAsync();

        #endregion Methods
    }
}