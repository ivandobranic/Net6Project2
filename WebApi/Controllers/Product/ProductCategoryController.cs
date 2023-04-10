using Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
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
        public IActionResult FindProductCategories()
        {
            var productCategories = ServiceManager.ProductCategoryService.FindProductCategories(trackChanges: false);
            return Ok(productCategories);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProductCategory(Guid id)
        {
            var productCategory = ServiceManager.ProductCategoryService.GetProductCategory(id, trackChanges: false);
            return Ok(productCategory);
        }

        [HttpPost]
        public IActionResult CreateProductCategory([FromBody] ProductCategoryCreateDto productCategory)
        {
            if (productCategory is null)
                return BadRequest("productCategory object is null");
            var createdProductCategory = ServiceManager.ProductCategoryService.CreateProductCategory(productCategory);
            return CreatedAtRoute("ProductCategoryById", new { id = createdProductCategory.Id }, createdProductCategory);
        }

        #endregion Methods
    }
}