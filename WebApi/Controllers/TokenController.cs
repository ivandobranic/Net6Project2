using Common.DataTransferObjects.User;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region Constructors

        public TokenController(IServiceManager serviceManager)
        {
            ServiceManager = serviceManager;
        }

        #endregion Constructors

        #region Properties

        public IServiceManager ServiceManager { get; set; }

        #endregion Properties

        #region Methods

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await ServiceManager.AuthenticationService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        #endregion Methods
    }
}