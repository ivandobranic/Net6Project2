using Entities.Models;

namespace Service.Contracts
{
    public interface IProductStatusLookup
    {
        #region Properties

        Lazy<Task<ProductStatus?>> Active { get; }

        Lazy<Task<ProductStatus?>> Inactive { get; }

        #endregion Properties
    }
}