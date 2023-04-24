using Common.DataTransferObjects.User;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Constructors

        public AuthenticationController(IServiceManager serviceManager)
        {
            ServiceManager = serviceManager;
        }

        #endregion Constructors

        #region Properties

        public IServiceManager ServiceManager { get; set; }

        #endregion Properties

        #region Methods

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserCreateDto userForRegistration)
        {
            var result = await ServiceManager.AuthenticationService.CreateUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await ServiceManager.AuthenticationService.ValidateUser(user))
            {
                return Unauthorized();
            }
            var tokenDto = await ServiceManager.AuthenticationService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }

        #endregion Methods
    }
}