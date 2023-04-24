using System.ComponentModel.DataAnnotations;

namespace Common.DataTransferObjects.Product
{
    public record ProductCreateDto(
        [Required(ErrorMessage = "Name is a required field.")] string Name,
        [Range(1, 1000000, ErrorMessage = "Price is required and it can't be lower than 1")] decimal Price,
        bool IsActive);
}