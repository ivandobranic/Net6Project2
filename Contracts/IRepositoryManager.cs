namespace Contracts
{
    public interface IRepositoryManager
    {
        #region Properties

        IProductCategoryRepository ProductCategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        #endregion Properties

        #region Methods

        void Save();

        #endregion Methods
    }
}