namespace InsureTrust.API.Application.DTOs.PremiumQuote;

public class PremiumQuoteRequestDto
{
    public int PolicyTypeId { get; set; }
    public int Age { get; set; }
    public decimal CoverageAmount { get; set; }
    public int TenureMonths { get; set; }
}
