namespace InsureTrust.API.Application.DTOs.PolicyCatalog;

public class PolicyCatalogItemDto
{
    public int PolicyTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal BaseMonthlyPremium { get; set; }
    public decimal AnnualPremium { get; set; }
    public decimal BusinessDiscountPercentage { get; set; }
    public decimal AnnualPremiumAfterDiscount { get; set; }
}
