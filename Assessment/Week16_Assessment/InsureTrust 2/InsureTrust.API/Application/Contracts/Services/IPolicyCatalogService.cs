using InsureTrust.API.Application.DTOs.PolicyCatalog;

namespace InsureTrust.API.Application.Contracts.Services;

public interface IPolicyCatalogService
{
    Task<IReadOnlyCollection<PolicyCatalogItemDto>> GetCatalogAsync(PolicyCatalogQueryDto query, CancellationToken cancellationToken = default);
}
