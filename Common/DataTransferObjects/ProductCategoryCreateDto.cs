namespace Common.DataTransferObjects
{
    public record ProductCategoryCreateDto(string Name, bool IsActive, IEnumerable<ProductCreateDto> Products);
}