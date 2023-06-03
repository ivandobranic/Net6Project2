namespace Service.Contracts
{
    public interface IServiceManager
    {
        #region Properties

        IProductCategoryService ProductCategoryService { get; }

        IProductService ProductService { get; }

        IAuthenticationService AuthenticationService { get; }

        IProductStatusLookup ProductStatusLookup { get; }

        #endregion Properties
    }
}