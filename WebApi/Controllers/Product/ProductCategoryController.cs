using Common.DataTransferObjects;
using Common.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Text.Json;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    [Route("api/product-categories")]
    public class ProductCategoryController : ControllerBase
    {
        #region Constructors

        public ProductCategoryController(IServiceManager serviceManager) => ServiceManager = serviceManager;

        #endregion Constructors

        #region Properties

        protected IServiceManager ServiceManager { get; set; }

        #endregion Properties

        #region Methods

        [HttpGet]
        public async Task<IActionResult> FindProductCategoriesAsync([FromQuery] ProductCategoryParameters productCategoryParameters)
        {
            var pagedResult = await ServiceManager.ProductCategoryService.FindProductCategoriesAsync(productCategoryParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.productCategories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductCategoryAsync(Guid id)
        {
            var productCategory = await ServiceManager.ProductCategoryService.GetProductCategoryAsync(id, trackChanges: false);
            return Ok(productCategory);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProductCategoryAsync([FromBody] ProductCategoryCreateDto productCategory)
        {
            var createdProductCategory = await ServiceManager.ProductCategoryService.CreateProductCategoryAsync(productCategory);
            return CreatedAtRoute("ProductCategoryById", new { id = createdProductCategory.Id }, createdProductCategory);
        }

        #endregion Methods
    }
}