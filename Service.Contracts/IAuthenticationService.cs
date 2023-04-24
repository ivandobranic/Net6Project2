using Common.DataTransferObjects.User;
using Microsoft.AspNetCore.Identity;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        #region Methods

        Task<IdentityResult> CreateUser(UserCreateDto user);

        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

        Task<TokenDto> CreateToken(bool populateExp);

        #endregion Methods
    }
}