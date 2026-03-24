using System.ComponentModel.DataAnnotations;

namespace LoanManagementApi.Models;

public class Loan
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string BorrowerName { get; set; } = string.Empty;

    [Range(1, 1_000_000_000)]
    public decimal Amount { get; set; }

    [Range(1, 480)]
    public int LoanTermMonths { get; set; }

    public bool IsApproved { get; set; }
}
