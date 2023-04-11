namespace Common.DataTransferObjects
{
    public record ProductCreateDto(string Name, decimal Price, bool IsActive);
}