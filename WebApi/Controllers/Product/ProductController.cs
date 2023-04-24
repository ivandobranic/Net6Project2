using Common.DataTransferObjects.Product;
using Common.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Text.Json;
using WebApi.ActionFilters;

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
        [Authorize]
        public async Task<IActionResult> FindProductsAsync([FromQuery] ProductParameters productParameters)
        {
            var pagedResult = await ServiceManager.ProductService.FindProductsAsync(productParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.products);
        }

        [HttpGet("{id:guid}", Name = "ProductCategoryById")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await ServiceManager.ProductService.GetProductAsync(id, trackChanges: false);
            return Ok(product);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProductAsync(Guid productCategoryId, [FromBody] ProductCreateDto product)
        {
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProductAsync(Guid id, [FromBody] ProductUpdateDto product)
        {
            await ServiceManager.ProductService.UpdateProductAsync(id, product, trackChanges: true);
            return NoContent();
        }

        #endregion Methods
    }
}