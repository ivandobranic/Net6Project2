namespace Entities.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        #region Constructors

        protected BadRequestException(string message)
        : base(message)
        {
        }

        #endregion Constructors
    }
}