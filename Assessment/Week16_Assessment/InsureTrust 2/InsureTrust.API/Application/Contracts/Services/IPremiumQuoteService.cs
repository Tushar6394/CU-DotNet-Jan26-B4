using InsureTrust.API.Application.DTOs.PremiumQuote;

namespace InsureTrust.API.Application.Contracts.Services;

public interface IPremiumQuoteService
{
    Task<PremiumQuoteResultDto> CalculateAsync(PremiumQuoteRequestDto request, CancellationToken cancellationToken = default);
}
