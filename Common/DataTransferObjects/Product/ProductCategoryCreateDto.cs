namespace Common.DataTransferObjects.Product
{
    public record ProductCategoryCreateDto(string Name, bool IsActive, IEnumerable<ProductCreateDto> Products);
}