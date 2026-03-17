using Microsoft.AspNetCore.Mvc;
using Day55.Models;
using Day55.Services;

namespace Day55.Controllers;

public class CompanyController : Controller
{
    private readonly IPulseDashboardService _pulseDashboardService;

    public CompanyController(IPulseDashboardService pulseDashboardService)
    {
        _pulseDashboardService = pulseDashboardService;
    }

    public IActionResult Dashboard()
    {
        var employees = _pulseDashboardService.GetEmployees();
        PopulateDashboardMetadata(employees);
        return View(employees);
    }

    private void PopulateDashboardMetadata(List<Employee> employees)
    {
        ViewBag.DailyAnnouncement = _pulseDashboardService.GetDailyAnnouncement();
        ViewBag.LastUpdated = _pulseDashboardService.GetLastUpdated().ToString("dd MMM yyyy, hh:mm tt");

        ViewData["DepartmentName"] = _pulseDashboardService.GetDepartmentName();
        ViewData["ServerStatus"] = _pulseDashboardService.GetServerStatus();
        ViewData["IsDepartmentActive"] = _pulseDashboardService.IsDepartmentActive();
        ViewData["TotalEmployees"] = employees.Count;
        ViewData["AverageSalary"] = employees.Count == 0 ? 0m : employees.Average(e => e.Salary);
    }
}