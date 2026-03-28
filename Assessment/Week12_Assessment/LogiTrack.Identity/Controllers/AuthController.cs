using LogiTrack.Identity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace LogiTrack.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly List<User> _testUsers = new List<User>
        {
            new User { UserId = 1, Username = "manager_john", Password = "password123", Email = "john@logitrack.com", Role = "Manager" },
            new User { UserId = 2, Username = "driver_jane", Password = "password123", Email = "jane@logitrack.com", Role = "Driver" }
        };

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Login endpoint that generates a JWT token
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate input
            if (string.IsNullOrEmpty(request?.Username) || string.IsNullOrEmpty(request?.Password))
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    Message = "Username and password are required"
                });
            }

            // Find user (hardcoded for demo)
            var user = _testUsers.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                });
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);

            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Login successful",
                AccessToken = token,
                TokenType = "Bearer"
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpirationMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
