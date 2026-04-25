using InsureTrust.API.Models;

namespace InsureTrust.API.Application.Contracts.Repositories;

public interface IPolicyTypeReadRepository
{
    Task<PolicyType?> GetByIdAsync(int policyTypeId, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<PolicyType>> GetAllActiveAsync(CancellationToken cancellationToken = default);
}
