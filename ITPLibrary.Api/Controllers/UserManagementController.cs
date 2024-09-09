using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userService.RegisterUserAsync(userRegistrationDto);
                return StatusCode(201, "User registered successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(409, ex.Message);
            }
        }
    }
}
