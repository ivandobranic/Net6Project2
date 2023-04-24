namespace Common.DataTransferObjects.Product
{
    public record ProductUpdateDto(string Name, decimal Price, bool IsActive);
}