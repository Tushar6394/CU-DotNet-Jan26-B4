using FluentValidation;
using InsureTrust.API.Application.DTOs.PolicyCatalog;

namespace InsureTrust.API.Application.Validation;

public class PolicyCatalogQueryValidator : AbstractValidator<PolicyCatalogQueryDto>
{
    public PolicyCatalogQueryValidator()
    {
        RuleFor(x => x.Category)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.Category));
    }
}
