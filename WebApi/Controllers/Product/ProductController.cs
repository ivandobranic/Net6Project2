using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Constructors

        public ProductController(IServiceManager serviceManager) => ServiceManager = serviceManager;

        #endregion Constructors

        #region Properties

        protected IServiceManager ServiceManager { get; set; }

        #endregion Properties

        #region Methods

        [HttpGet]
        public IActionResult FindProducts()
        {
            var products = ServiceManager.ProductService.FindProducts(trackChanges: false);
            return Ok(products);
        }

        [HttpGet("{id:guid}", Name = "ProductCategoryById")]
        public IActionResult GetProduct(Guid id)
        {
            var product = ServiceManager.ProductService.GetProduct(id, trackChanges: false);
            return Ok(product);
        }

        #endregion Methods
    }
}