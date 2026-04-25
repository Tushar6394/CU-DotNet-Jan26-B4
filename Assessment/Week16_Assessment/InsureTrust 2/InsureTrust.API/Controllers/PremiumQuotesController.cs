using InsureTrust.API.Application.Contracts.Services;
using InsureTrust.API.Application.DTOs.PremiumQuote;
using InsureTrust.API.Common;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/v1/premium-quotes")]
public class PremiumQuotesController : ControllerBase
{
    private readonly IPremiumQuoteService _premiumQuoteService;

    public PremiumQuotesController(IPremiumQuoteService premiumQuoteService)
    {
        _premiumQuoteService = premiumQuoteService;
    }

    [HttpPost("calculate")]
    [ProducesResponseType(typeof(ApiResponse<PremiumQuoteResultDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Calculate([FromBody] PremiumQuoteRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _premiumQuoteService.CalculateAsync(request, cancellationToken);
        return Ok(ApiResponse<PremiumQuoteResultDto>.Ok(result, "Premium quote calculated successfully."));
    }
}
