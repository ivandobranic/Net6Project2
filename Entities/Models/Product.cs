using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product : BaseModel
    {
        #region Properties

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(ProductCategory))]
        public Guid ProductCategoryId { get; set; }

        public ProductCategory? ProductCategory { get; set; }

        #endregion Properties
    }
}