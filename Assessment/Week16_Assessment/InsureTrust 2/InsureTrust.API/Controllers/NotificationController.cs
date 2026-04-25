using System.Security.Claims;
using InsureTrust.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _svc;
    public NotificationController(INotificationService svc) => _svc = svc;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetUserNotificationsAsync(GetUserId()));

    [HttpGet("unread-count")]
    public async Task<IActionResult> UnreadCount() => Ok(new { count = await _svc.GetUnreadCountAsync(GetUserId()) });

    [HttpPut("mark-read/{id}")]
    public async Task<IActionResult> MarkRead(int id)
    {
        await _svc.MarkReadAsync(id, GetUserId());
        return Ok(new { message = "Marked as read" });
    }

    [HttpPut("mark-all-read")]
    public async Task<IActionResult> MarkAllRead()
    {
        await _svc.MarkAllReadAsync(GetUserId());
        return Ok(new { message = "All marked as read" });
    }

    private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}
