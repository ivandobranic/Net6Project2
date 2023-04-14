using Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
        public async Task<IActionResult> FindProductCategoriesAsync()
        {
            var productCategories = await ServiceManager.ProductCategoryService.FindProductCategoriesAsync(trackChanges: false);
            return Ok(productCategories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductCategoryAsync(Guid id)
        {
            var productCategory = await ServiceManager.ProductCategoryService.GetProductCategoryAsync(id, trackChanges: false);
            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCategoryAsync([FromBody] ProductCategoryCreateDto productCategory)
        {
            if (productCategory is null)
                return BadRequest("productCategory object is null");
            var createdProductCategory = await ServiceManager.ProductCategoryService.CreateProductCategoryAsync(productCategory);
            return CreatedAtRoute("ProductCategoryById", new { id = createdProductCategory.Id }, createdProductCategory);
        }

        #endregion Methods
    }
}