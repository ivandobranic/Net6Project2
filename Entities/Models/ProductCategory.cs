using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ProductCategory : BaseModel
    {
        #region Properties

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        public bool IsActive { get; set; }
        public ICollection<Product>? Products { get; set; }

        #endregion Properties
    }
}