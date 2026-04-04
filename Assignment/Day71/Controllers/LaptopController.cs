using Day71.Models;
using Day71.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day71.Controllers;

public class LaptopController : Controller
{
    private readonly LaptopService _laptopService;

    public LaptopController(LaptopService laptopService)
    {
        _laptopService = laptopService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var laptops = await _laptopService.GetAsync();
        var viewModel = new LaptopDashboardViewModel
        {
            Laptops = laptops
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LaptopDashboardViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Laptops = await _laptopService.GetAsync();
            return View("Index", viewModel);
        }

        await _laptopService.CreateAsync(viewModel.NewLaptop);
        TempData["SuccessMessage"] = "Laptop successfully saved to MongoDB.";
        return RedirectToAction(nameof(Index));
    }
}
