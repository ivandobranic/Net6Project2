namespace Entities.Exceptions
{
    public sealed class ProductCategoryNotFoundException : NotFoundException
    {
        #region Constructors

        public ProductCategoryNotFoundException(Guid id)
        : base($"The product category with id: {id} doesn't exist in the database.")
        {
        }

        #endregion Constructors
    }
}