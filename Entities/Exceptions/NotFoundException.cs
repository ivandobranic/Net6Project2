namespace Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        #region Constructors

        protected NotFoundException(string message)
        : base(message)
        { }

        #endregion Constructors
    }
}