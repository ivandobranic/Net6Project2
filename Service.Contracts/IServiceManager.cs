namespace Service.Contracts
{
    public interface IServiceManager
    {
        #region Properties

        public IProductCategoryService ProductCategoryService { get; }

        public IProductService ProductService { get; }

        #endregion Properties
    }
}