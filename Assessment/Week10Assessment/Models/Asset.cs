using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models;

public class Asset
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string Ticker { get; set; } = string.Empty;

    [Required]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 1000000000)]
    public double Value { get; set; }

    [Range(1, int.MaxValue)]
    public int Units { get; set; }

    public string Sector { get; set; } = string.Empty;
}
