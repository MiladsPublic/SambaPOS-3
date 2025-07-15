using Microsoft.AspNetCore.Mvc;
using Samba.WebApi.DTOs;

namespace Samba.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                // TODO: Integrate with existing user authentication service
                // For now, simulate basic authentication
                if (string.IsNullOrEmpty(request.PinCode))
                {
                    return BadRequest(new LoginResponseDto 
                    { 
                        Success = false, 
                        Message = "PIN code is required" 
                    });
                }

                // Simulate successful login for demo purposes
                var response = new LoginResponseDto
                {
                    Success = true,
                    Token = GenerateSimpleToken(),
                    User = new UserDto
                    {
                        Id = 1,
                        Name = "Demo User",
                        PinCode = request.PinCode,
                        UserRole = "Manager"
                    },
                    Message = "Login successful"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500, new LoginResponseDto 
                { 
                    Success = false, 
                    Message = "Internal server error" 
                });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // TODO: Implement token invalidation
            return Ok(new { success = true, message = "Logged out successfully" });
        }

        private string GenerateSimpleToken()
        {
            // Simple token generation for demo - should use proper JWT in production
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"user_{DateTime.UtcNow.Ticks}"));
        }
    }
}