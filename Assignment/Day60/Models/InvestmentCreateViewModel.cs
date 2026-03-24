using System.ComponentModel.DataAnnotations;

namespace Day60.Models;

public class InvestmentCreateViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ticker is required")]
    [StringLength(10)]
    [Display(Name = "Ticker Symbol")]
    public string TickerSymbol { get; set; } = string.Empty;

    [Required(ErrorMessage = "Asset name is required")]
    [StringLength(100)]
    [Display(Name = "Asset Name")]
    public string AssetName { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 1000000)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 10000)]
    public int Quantity { get; set; }

    [Display(Name = "Total Investment Value")]
    public string TotalValue => (Price * Quantity).ToString("C");
}
