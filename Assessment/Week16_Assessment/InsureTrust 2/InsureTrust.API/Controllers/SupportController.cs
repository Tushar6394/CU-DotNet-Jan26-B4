using System.Security.Claims;
using InsureTrust.API.DTOs.Support;
using InsureTrust.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SupportController : ControllerBase
{
    private readonly ISupportService _svc;
    public SupportController(ISupportService svc) => _svc = svc;

    [HttpGet("my-queries")]
    public async Task<IActionResult> GetMyQueries() => Ok(await _svc.GetMyQueriesAsync(GetUserId()));

    [Authorize(Roles = "Admin")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllQueriesAsync());

    [HttpPost("submit")]
    public async Task<IActionResult> Submit([FromForm] CreateSupportQueryDto dto)
    {
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        var query = await _svc.SubmitQueryAsync(dto, GetUserId(), uploadPath);
        return Ok(new { message = "Query submitted", query });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("update/{ticketId}")]
    public async Task<IActionResult> UpdateStatus(int ticketId, [FromBody] InsureTrust.API.DTOs.Support.UpdateSupportStatusDto dto)
    {
        var result = await _svc.UpdateStatusAsync(ticketId, dto);
        return Ok(result);
    }

    private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}
