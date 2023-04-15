using AutoMapper;
using Common.DataTransferObjects;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        #region Constructors

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            Logger = logger;
            Mapper = mapper;
            UserManager = userManager;
            Configuration = configuration;
        }

        #endregion Constructors

        #region Properties

        public ILoggerManager Logger { get; set; }
        public IMapper Mapper { get; set; }

        public UserManager<User> UserManager { get; set; }

        public IConfiguration Configuration { get; set; }

        #endregion Properties

        #region Methods

        public async Task<IdentityResult> CreateUser(UserCreateDto createUser)
        {
            var user = Mapper.Map<User>(createUser);
            var result = await UserManager.CreateAsync(user, createUser.Password);
            if (result.Succeeded)
                await UserManager.AddToRolesAsync(user, createUser.Roles);
            return result;
        }

        #endregion Methods
    }
}