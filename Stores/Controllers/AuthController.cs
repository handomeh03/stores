using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Auth;
using Stores.DataAccess;
using Stores.Services.Interfaces;

namespace Stores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly UserRepository _userRepository;

        public AuthController(AuthService authService, ITokenService tokenService, UserRepository userRepository)
        {
            _authService = authService;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto.Name, dto.Email, dto.Password, dto.Phone);

            if (result == null)
            {
                return BadRequest(new { message = "Email is already in use or registration failed" });
            }

            return Ok(new { message = "Account created successfully" });
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto.Email, dto.Password);

            if (result == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            var roleName = await _userRepository.GetRoleNameByIdAsync(result.RoleId);

            var token = _tokenService.GenerateToken(result.Id, roleName);

            return Ok(new
            {
                message = "Login successful",
                Token = token,
            });
        }
    }

   

   
}