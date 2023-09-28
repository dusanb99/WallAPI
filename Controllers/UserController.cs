using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WallAPI.DTO;
using WallAPI.Services.Interfaces;

namespace WallAPI.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO user)
        {
            TokenDTO tokenDto = await _userService.Login(user);

            if(tokenDto.Error.IsNullOrEmpty()) { 

                return Ok(tokenDto);
            }
            else
            {
                var retVal = tokenDto.Error.Contains("-1") ? "Bad username. " : "";
                retVal += tokenDto.Error.Contains("-2") ? "Bad password. " : "";
                 return BadRequest(retVal);
            }
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] UserRegisterDTO user)
        {
            UserOutDTO userToReturn = await _userService.Register(user);

            if (userToReturn != null)
            {
                return Ok(userToReturn);
            }
            else
            {
                return BadRequest("User already exists!");
            }
        }
    }
}
