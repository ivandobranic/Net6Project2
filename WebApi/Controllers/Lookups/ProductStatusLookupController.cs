using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApi.Controllers.Lookups
{
    [Route("api/product-statuses")]
    [ApiController]
    public class ProductStatusLookupController : ControllerBase
    {
        #region Constructors

        public ProductStatusLookupController(IServiceManager serviceManager) => ServiceManager = serviceManager;

        #endregion Constructors

        #region Properties

        protected IServiceManager ServiceManager { get; set; }

        #endregion Properties

        #region Methods

        [HttpGet]
        public async Task<IActionResult> FindProductsAsync()
        {
            var result = await ServiceManager.ProductStatusLookup.GetItemsAsync();
            return Ok(result);
        }

        #endregion Methods
    }
}