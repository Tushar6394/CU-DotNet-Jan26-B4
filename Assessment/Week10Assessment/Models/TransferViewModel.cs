using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models;

public class TransferViewModel
{
    [Display(Name = "From Account")]
    [Required]
    public int? FromAccountId { get; set; }

    [Display(Name = "To Account")]
    [Required]
    public int? ToAccountId { get; set; }

    [Range(0.01, 1000000000)]
    public double Amount { get; set; }

    [StringLength(120)]
    [Display(Name = "Note")]
    public string Description { get; set; } = "Fund transfer";

    [DataType(DataType.Date)]
    [Display(Name = "Transfer Date")]
    public DateTime Date { get; set; } = DateTime.Today;
}
