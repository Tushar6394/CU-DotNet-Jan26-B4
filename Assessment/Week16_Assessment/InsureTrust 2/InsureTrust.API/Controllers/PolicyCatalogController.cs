using InsureTrust.API.Application.Contracts.Services;
using InsureTrust.API.Application.DTOs.PolicyCatalog;
using InsureTrust.API.Common;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/v1/policy-catalog")]
public class PolicyCatalogController : ControllerBase
{
    private readonly IPolicyCatalogService _policyCatalogService;

    public PolicyCatalogController(IPolicyCatalogService policyCatalogService)
    {
        _policyCatalogService = policyCatalogService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<PolicyCatalogItemDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCatalog([FromQuery] PolicyCatalogQueryDto query, CancellationToken cancellationToken)
    {
        var result = await _policyCatalogService.GetCatalogAsync(query, cancellationToken);
        return Ok(ApiResponse<IReadOnlyCollection<PolicyCatalogItemDto>>.Ok(result, "Policy catalog fetched successfully."));
    }
}
