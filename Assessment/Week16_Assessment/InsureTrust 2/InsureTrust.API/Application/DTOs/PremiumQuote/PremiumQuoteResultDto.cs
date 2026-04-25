namespace InsureTrust.API.Application.DTOs.PremiumQuote;

public class PremiumQuoteResultDto
{
    public int PolicyTypeId { get; set; }
    public string PolicyName { get; set; } = string.Empty;
    public decimal BaseMonthlyPremium { get; set; }
    public decimal MonthlyPremium { get; set; }
    public decimal GrossPremium { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalPremium { get; set; }
    public decimal AgeLoadingPercentage { get; set; }
    public decimal RiskMultiplier { get; set; }
    public decimal TenureDiscountPercentage { get; set; }
}
