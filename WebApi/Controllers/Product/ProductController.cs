using Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/products")]
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

        [HttpPost]
        public IActionResult CreateProduct(Guid productCategoryId, [FromBody] ProductCreateDto product)
        {
            if (product is null)
                return BadRequest("ProductCreateDto object is null");
            var createdProduct = ServiceManager.ProductService.CreateProduct(productCategoryId, product, trackChanges: false);
            return CreatedAtRoute("GetEmployeeForCompany", new
            {
                productCategoryId,
                id = createdProduct.Id
            },
            createdProduct);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            ServiceManager.ProductService.DeleteProduct(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductUpdateDto product)
        {
            if (product is null)
                return BadRequest("ProductUpdateDto object is null");
            ServiceManager.ProductService.UpdateProduct(id, product, trackChanges: true);
            return NoContent();
        }

        #endregion Methods
    }
}