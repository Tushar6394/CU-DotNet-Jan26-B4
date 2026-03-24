using System.ComponentModel.DataAnnotations;

namespace Day61.Models;

public class Car
{
    public int Id { get; set; }

    [Required]
    [StringLength(60)]
    public string Brand { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    public string Model { get; set; } = string.Empty;

    [Range(1900, 2100)]
    public int Year { get; set; }

    [Range(0, 100000000)]
    public decimal Price { get; set; }
}
