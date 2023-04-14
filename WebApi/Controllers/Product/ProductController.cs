using Common.DataTransferObjects;
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
        public async Task<IActionResult> FindProductsAsync()
        {
            var products = await ServiceManager.ProductService.FindProductsAsync(trackChanges: false);
            return Ok(products);
        }

        [HttpGet("{id:guid}", Name = "ProductCategoryById")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await ServiceManager.ProductService.GetProductAsync(id, trackChanges: false);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(Guid productCategoryId, [FromBody] ProductCreateDto product)
        {
            if (product is null)
                return BadRequest("ProductCreateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdProduct = await ServiceManager.ProductService.CreateProductAsync(productCategoryId, product, trackChanges: false);
            return CreatedAtRoute("GetEmployeeForCompany", new
            {
                productCategoryId,
                id = createdProduct.Id
            },
            createdProduct);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            await ServiceManager.ProductService.DeleteProductAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductAsync(Guid id, [FromBody] ProductUpdateDto product)
        {
            if (product is null)
                return BadRequest("ProductUpdateDto object is null");
            await ServiceManager.ProductService.UpdateProductAsync(id, product, trackChanges: true);
            return NoContent();
        }

        #endregion Methods
    }
}