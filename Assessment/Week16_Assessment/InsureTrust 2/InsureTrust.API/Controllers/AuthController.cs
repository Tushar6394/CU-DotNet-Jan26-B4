using System.Security.Claims;
using InsureTrust.API.DTOs.Auth;
using InsureTrust.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _svc;
    public AuthController(IAuthService svc) => _svc = svc;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterDto dto)
    {
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        var user = await _svc.RegisterAsync(dto, uploadPath);
        return Ok(new { message = "Registration successful", user });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _svc.LoginAsync(dto);
        return Ok(new { token });
    }

    [HttpPost("admin-login")]
    public async Task<IActionResult> AdminLogin([FromBody] LoginDto dto)
    {
        var token = await _svc.AdminLoginAsync(dto);
        return Ok(new { token });
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto dto)
    {
        var token = await _svc.GoogleLoginAsync(dto);
        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = GetUserId();
        var user = await _svc.GetProfileAsync(userId);
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _svc.GetAllUsersAsync();
        return Ok(users);
    }

    private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}
