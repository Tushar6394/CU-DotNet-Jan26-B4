using System.ComponentModel.DataAnnotations;

namespace Day55.Models;

public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(60, ErrorMessage = "Name cannot exceed 60 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Position is required.")]
    [StringLength(60, ErrorMessage = "Position cannot exceed 60 characters.")]
    public string Position { get; set; } = string.Empty;

    [Range(1000, 1000000, ErrorMessage = "Salary should be between 1,000 and 1,000,000.")]
    public decimal Salary { get; set; }
}