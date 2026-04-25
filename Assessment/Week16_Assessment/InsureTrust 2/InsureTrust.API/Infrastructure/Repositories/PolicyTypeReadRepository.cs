using InsureTrust.API.Application.Contracts.Repositories;
using InsureTrust.API.Data;
using InsureTrust.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InsureTrust.API.Infrastructure.Repositories;

public class PolicyTypeReadRepository : IPolicyTypeReadRepository
{
    private readonly AppDbContext _dbContext;

    public PolicyTypeReadRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PolicyType?> GetByIdAsync(int policyTypeId, CancellationToken cancellationToken = default)
    {
        return _dbContext.PolicyTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == policyTypeId && x.IsActive, cancellationToken);
    }

    public async Task<IReadOnlyCollection<PolicyType>> GetAllActiveAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.PolicyTypes
            .AsNoTracking()
            .Where(x => x.IsActive)
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
