using FluentValidation;
using InsureTrust.API.Application.DTOs.PremiumQuote;

namespace InsureTrust.API.Application.Validation;

public class PremiumQuoteRequestValidator : AbstractValidator<PremiumQuoteRequestDto>
{
    public PremiumQuoteRequestValidator()
    {
        RuleFor(x => x.PolicyTypeId)
            .GreaterThan(0);

        RuleFor(x => x.Age)
            .InclusiveBetween(18, 75);

        RuleFor(x => x.CoverageAmount)
            .GreaterThan(0)
            .LessThanOrEqualTo(100000000);

        RuleFor(x => x.TenureMonths)
            .InclusiveBetween(12, 360);
    }
}
