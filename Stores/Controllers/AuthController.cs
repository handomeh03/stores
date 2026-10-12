using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Auth;

namespace Stores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto.Name, dto.Email, dto.Password, dto.Phone);

            if (result == null)
            {
                return BadRequest(new { message = "Email is already in use or registration failed" });
            }

            return Ok(new { message = "Account created successfully", email = result });
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto.Email, dto.Password);

            if (result == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            return Ok(new { message = "Login successful", email = result });
        }
    }

   

   
}