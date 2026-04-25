using AutoMapper;
using InsureTrust.API.Application.Contracts.Repositories;
using InsureTrust.API.Application.Contracts.Services;
using InsureTrust.API.Application.DTOs.PremiumQuote;
using InsureTrust.API.Exceptions;

namespace InsureTrust.API.Application.Services;

public class PremiumQuoteService : IPremiumQuoteService
{
    private readonly IPolicyTypeReadRepository _policyTypeRepository;
    private readonly IMapper _mapper;

    public PremiumQuoteService(IPolicyTypeReadRepository policyTypeRepository, IMapper mapper)
    {
        _policyTypeRepository = policyTypeRepository;
        _mapper = mapper;
    }

    public async Task<PremiumQuoteResultDto> CalculateAsync(PremiumQuoteRequestDto request, CancellationToken cancellationToken = default)
    {
        var policyType = await _policyTypeRepository.GetByIdAsync(request.PolicyTypeId, cancellationToken)
            ?? throw new NotFoundException("Policy type not found or inactive.");

        if (request.TenureMonths < policyType.MinTenureMonths || request.TenureMonths > policyType.MaxTenureMonths)
        {
            throw new BadRequestException($"Tenure must be between {policyType.MinTenureMonths} and {policyType.MaxTenureMonths} months for this policy.");
        }

        var result = _mapper.Map<PremiumQuoteResultDto>(policyType);

        var ageLoadingPct = GetAgeLoadingPercentage(request.Age);
        var tenureDiscountPct = GetTenureDiscountPercentage(request.TenureMonths);
        var riskMultiplier = GetRiskMultiplier(request.CoverageAmount);

        var monthly = policyType.BaseMonthlyPremium * (1 + ageLoadingPct) * riskMultiplier;
        monthly = decimal.Round(monthly, 2, MidpointRounding.AwayFromZero);

        var gross = decimal.Round(monthly * request.TenureMonths, 2, MidpointRounding.AwayFromZero);
        var discount = decimal.Round(gross * tenureDiscountPct, 2, MidpointRounding.AwayFromZero);
        var finalPremium = decimal.Round(gross - discount, 2, MidpointRounding.AwayFromZero);

        result.AgeLoadingPercentage = ageLoadingPct * 100;
        result.RiskMultiplier = riskMultiplier;
        result.TenureDiscountPercentage = tenureDiscountPct * 100;
        result.MonthlyPremium = monthly;
        result.GrossPremium = gross;
        result.DiscountAmount = discount;
        result.FinalPremium = finalPremium;

        return result;
    }

    internal static decimal GetAgeLoadingPercentage(int age) => age switch
    {
        <= 30 => 0.00m,
        <= 45 => 0.10m,
        <= 60 => 0.25m,
        _ => 0.45m
    };

    internal static decimal GetTenureDiscountPercentage(int tenureMonths) => tenureMonths switch
    {
        >= 120 => 0.10m,
        >= 60 => 0.05m,
        _ => 0.00m
    };

    internal static decimal GetRiskMultiplier(decimal coverageAmount) => coverageAmount switch
    {
        <= 500000 => 1.00m,
        <= 1000000 => 1.08m,
        _ => 1.15m
    };
}
