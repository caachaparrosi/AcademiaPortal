using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                var user = await _userService.RegisterAsync(registerUserDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
