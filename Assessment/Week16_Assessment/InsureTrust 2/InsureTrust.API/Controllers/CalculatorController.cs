using InsureTrust.API.DTOs.Calculator;
using InsureTrust.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _svc;
    public CalculatorController(ICalculatorService svc) => _svc = svc;

    [HttpPost("estimate")]
    public IActionResult Estimate([FromBody] CalculatorRequestDto dto)
    {
        var result = _svc.Estimate(dto);
        return Ok(result);
    }
}
