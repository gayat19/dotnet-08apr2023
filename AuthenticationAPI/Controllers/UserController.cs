using AuthenticationAPI.Models.DTO;
using AuthenticationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(UserDTO userDTO)
        {
            var result = await _userService.Login(userDTO);
            if(result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(UserDTO userDTO)
        {
            var result = await _userService.Register(userDTO);
            if (result == null)
            {
                return BadRequest("Unable to register");
            }
            return Ok(result);
        }
    }
}
