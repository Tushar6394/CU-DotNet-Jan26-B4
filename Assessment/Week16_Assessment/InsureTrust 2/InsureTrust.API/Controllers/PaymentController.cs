using System.Security.Claims;
using InsureTrust.API.DTOs.Payment;
using InsureTrust.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _svc;
    public PaymentController(IPaymentService svc) => _svc = svc;

    [HttpPost("initiate")]
    public async Task<IActionResult> Initiate([FromBody] InitiatePaymentDto dto)
    {
        var payment = await _svc.InitiateAsync(dto, GetUserId());
        return Ok(payment);
    }

    [HttpGet("history")]
    public async Task<IActionResult> History() => Ok(await _svc.GetHistoryAsync(GetUserId()));

    private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}
