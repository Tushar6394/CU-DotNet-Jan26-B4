using AutoMapper;
using InsureTrust.API.Application.Contracts.Repositories;
using InsureTrust.API.Application.Contracts.Services;
using InsureTrust.API.Application.DTOs.PolicyCatalog;

namespace InsureTrust.API.Application.Services;

public class PolicyCatalogService : IPolicyCatalogService
{
    private readonly IPolicyTypeReadRepository _policyTypeRepository;
    private readonly IMapper _mapper;

    public PolicyCatalogService(IPolicyTypeReadRepository policyTypeRepository, IMapper mapper)
    {
        _policyTypeRepository = policyTypeRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<PolicyCatalogItemDto>> GetCatalogAsync(PolicyCatalogQueryDto query, CancellationToken cancellationToken = default)
    {
        var policies = await _policyTypeRepository.GetAllActiveAsync(cancellationToken);

        if (!string.IsNullOrWhiteSpace(query.Category))
        {
            policies = policies
                .Where(x => string.Equals(x.Category, query.Category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var items = _mapper.Map<List<PolicyCatalogItemDto>>(policies);

        foreach (var item in items)
        {
            item.AnnualPremium = decimal.Round(item.BaseMonthlyPremium * 12, 2, MidpointRounding.AwayFromZero);
            item.BusinessDiscountPercentage = string.Equals(item.Category, "Business", StringComparison.OrdinalIgnoreCase) ? 3.0m : 0m;
            var discount = item.AnnualPremium * (item.BusinessDiscountPercentage / 100m);
            item.AnnualPremiumAfterDiscount = decimal.Round(item.AnnualPremium - discount, 2, MidpointRounding.AwayFromZero);
        }

        return items;
    }
}
