using System.ComponentModel.DataAnnotations;

namespace Day60.Models;

public class PortfolioTrackerEntry
{
    public int Id { get; set; }

    [Display(Name = "Tracked On")]
    public DateTime TrackedOn { get; set; }

    [Range(0, 1000000000)]
    [Display(Name = "Portfolio Value")]
    public decimal PortfolioValue { get; set; }

    [Range(0, 1000000000)]
    [Display(Name = "Cash Reserve")]
    public decimal CashReserve { get; set; }

    [StringLength(200)]
    public string? Notes { get; set; }

    [Display(Name = "Net Worth")]
    public decimal NetWorth => PortfolioValue + CashReserve;
}
