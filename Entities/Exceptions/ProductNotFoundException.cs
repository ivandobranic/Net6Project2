namespace Entities.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        #region Constructors

        public ProductNotFoundException(Guid id)
        : base($"The product with id: {id} doesn't exist in the database.")
        {
        }

        #endregion Constructors
    }
}