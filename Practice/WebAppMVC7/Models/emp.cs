using System.ComponentModel.DataAnnotations;

namespace WebAppMVC7.Models
{
    public class Emp
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Employee name must be at least 3 characters long.")]
        public string EmpName { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Range(typeof(decimal), "20000", "50000", ErrorMessage = "Salary must be between 20000 and 50000.")]
        public decimal Salary { get; set; }
    }
}