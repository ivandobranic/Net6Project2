using Common.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        #region Methods

        Task<IdentityResult> CreateUser(UserCreateDto user);

        #endregion Methods
    }
}