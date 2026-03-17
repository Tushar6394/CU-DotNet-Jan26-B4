using Day55.Models;

namespace Day55.ViewModels;

public class DashboardViewModel
{
    public List<Employee> Employees { get; set; } = [];
    public Employee FormEmployee { get; set; } = new();
    public bool IsEditMode { get; set; }
}