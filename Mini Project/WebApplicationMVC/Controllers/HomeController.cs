using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ShowName()
    {
        string myName = "Tushar";
        ViewBag.myName = myName;

        ViewBag.age1 = 20;

        string city = "Lucknow";
        ViewData["City"] = city;
        ViewData["Age2"] = 21;

        int Salary = 50000;
        TempData["Salary"] = Salary;
        return View();

    }
      
    [HttpGet]
    public IActionResult ShowSalary()
    { 
        ViewBag.Salary = TempData.Peek("Salary");
        return View();
    }

    [HttpGet]
    public IActionResult ShowSalary2()
    {
        TempData["Salary"] = 25000;
        return RedirectToAction("ShowSalary");
    }  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
