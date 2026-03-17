using Day55.Models;

namespace Day55.Services;

public class PulseDashboardService : IPulseDashboardService
{
    private readonly object _syncRoot = new();
    private readonly List<Employee> _employees =
    [
        new Employee { Id = 101, Name = "Ittan Sahil", Position = "Software Engineer", Salary = 75000m },
        new Employee { Id = 102, Name = "Mayank Sharma", Position = "QA Analyst", Salary = 62000m },
        new Employee { Id = 103, Name = "Hrithik", Position = "Project Manager", Salary = 98000m },
        new Employee { Id = 104, Name = "Aaroh", Position = "UI/UX Designer", Salary = 70000m },
        new Employee { Id = 105, Name = "Tushar Singh", Position = "Cloud Engineer", Salary = 88000m }
    ];

    public List<Employee> GetEmployees()
    {
        lock (_syncRoot)
        {
            return _employees
                .OrderBy(e => e.Id)
                .Select(Clone)
                .ToList();
        }
    }

    public Employee? GetEmployeeById(int id)
    {
        lock (_syncRoot)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return employee is null ? null : Clone(employee);
        }
    }

    public Employee AddEmployee(Employee employee)
    {
        lock (_syncRoot)
        {
            var nextId = _employees.Count == 0 ? 101 : _employees.Max(e => e.Id) + 1;
            var newEmployee = new Employee
            {
                Id = nextId,
                Name = employee.Name.Trim(),
                Position = employee.Position.Trim(),
                Salary = employee.Salary
            };

            _employees.Add(newEmployee);
            return Clone(newEmployee);
        }
    }

    public bool UpdateEmployee(Employee employee)
    {
        lock (_syncRoot)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing is null)
            {
                return false;
            }

            existing.Name = employee.Name.Trim();
            existing.Position = employee.Position.Trim();
            existing.Salary = employee.Salary;
            return true;
        }
    }

    public bool DeleteEmployee(int id)
    {
        lock (_syncRoot)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing is null)
            {
                return false;
            }

            _employees.Remove(existing);
            return true;
        }
    }

    public string GetDepartmentName() => "Engineering";

    public string GetServerStatus() => "Healthy";

    public bool IsDepartmentActive() => true;

    public string GetDailyAnnouncement() => "Quarterly town hall starts at 4:00 PM in Auditorium A.";

    public DateTime GetLastUpdated() => DateTime.Now;

    private static Employee Clone(Employee employee)
    {
        return new Employee
        {
            Id = employee.Id,
            Name = employee.Name,
            Position = employee.Position,
            Salary = employee.Salary
        };
    }
}