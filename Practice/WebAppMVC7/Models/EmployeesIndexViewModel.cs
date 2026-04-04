namespace WebAppMVC7.Models;

public class EmployeesIndexViewModel
{
    public IReadOnlyList<Emp> Employees { get; init; } = [];
    public Emp NewEmployee { get; init; } = new();
    public string StorageLocation { get; init; } = string.Empty;
}