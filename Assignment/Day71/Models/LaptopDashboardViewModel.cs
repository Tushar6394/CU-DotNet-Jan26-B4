namespace Day71.Models;

public sealed class LaptopDashboardViewModel
{
    public Laptop NewLaptop { get; set; } = new();

    public IReadOnlyList<Laptop> Laptops { get; set; } = Array.Empty<Laptop>();
}
