using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMVC7.Data;
using WebAppMVC7.Models;

namespace WebAppMVC7.Controllers;

public class EmployeesController(AppDbContext context) : Controller
{
    private const string StorageLocation = "Docker volume webappmvc7_webappmvc7-postgres-data mounted at /var/lib/docker/volumes/webappmvc7_webappmvc7-postgres-data/_data";

    public async Task<IActionResult> Index()
    {
        var employees = await context.Employees
            .OrderBy(employee => employee.EmpId)
            .ToListAsync();

        return View(new EmployeesIndexViewModel
        {
            Employees = employees,
            StorageLocation = StorageLocation
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeesIndexViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var employees = await context.Employees
                .OrderBy(employee => employee.EmpId)
                .ToListAsync();

            return View("Index", new EmployeesIndexViewModel
            {
                Employees = employees,
                NewEmployee = model.NewEmployee,
                StorageLocation = StorageLocation
            });
        }

        context.Employees.Add(new Emp
        {
            EmpName = model.NewEmployee.EmpName,
            City = model.NewEmployee.City,
            Salary = model.NewEmployee.Salary
        });

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await context.Employees.FindAsync(id);

        if (employee is not null)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await context.Employees.FindAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Emp employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        var existingEmployee = await context.Employees.FindAsync(employee.EmpId);

        if (existingEmployee is null)
        {
            return NotFound();
        }

        existingEmployee.EmpName = employee.EmpName;
        existingEmployee.City = employee.City;
        existingEmployee.Salary = employee.Salary;

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}