using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    [StringLength(120)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 1000000000)]
    public double Amount { get; set; }

    [Required]
    [StringLength(40)]
    public string Category { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Today;
}
