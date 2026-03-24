using System.ComponentModel.DataAnnotations;

namespace Day56.Models;

public class Loan
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Borrower name is required.")]
    [Display(Name = "Borrower Name")]
    public string BorrowerName { get; set; } = string.Empty;

    [Display(Name = "Lender Name")]
    public string LenderName { get; set; } = string.Empty;

    [Range(1, 500000, ErrorMessage = "Amount must be between 1 and 500,000.")]
    public double Amount { get; set; }

    [Display(Name = "Settled")]
    public bool IsSettled { get; set; }
}
