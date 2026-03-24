using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models;

public class Account
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    [Display(Name = "Account Holder")]
    public string HolderName { get; set; } = string.Empty;

    [Required]
    [StringLength(40)]
    [Display(Name = "Account Type")]
    public string AccountType { get; set; } = string.Empty;

    [Range(0, 1000000000)]
    [Display(Name = "Current Balance")]
    public double Balance { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Opened On")]
    public DateTime OpenedOn { get; set; } = DateTime.Today;
}
