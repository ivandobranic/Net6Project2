namespace Entities.Exceptions
{
    public sealed class RefreshTokenBadRequest : BadRequestException
    {
        #region Constructors

        public RefreshTokenBadRequest()
        : base("Invalid client request. The tokenDto has some invalid values.")
        {
        }

        #endregion Constructors
    }
}