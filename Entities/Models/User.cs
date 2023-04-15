using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        #region Properties

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        #endregion Properties
    }
}