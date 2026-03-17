using Day55.Models;

namespace Day55.Services;

public interface IPulseDashboardService
{
    List<Employee> GetEmployees();
    Employee? GetEmployeeById(int id);
    Employee AddEmployee(Employee employee);
    bool UpdateEmployee(Employee employee);
    bool DeleteEmployee(int id);
    string GetDepartmentName();
    string GetServerStatus();
    bool IsDepartmentActive();
    string GetDailyAnnouncement();
    DateTime GetLastUpdated();
}