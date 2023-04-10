namespace Common.DataTransferObjects
{
    public record ProductDto(Guid Id, string Name, decimal Price, Guid ProductCategoryId);
}