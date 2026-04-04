using Microsoft.AspNetCore.Mvc;
using Vagabond.Mvc.Services;

namespace Vagabond.Mvc.Controllers;

public class TravelController(IDestinationService destinationService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var destinations = await destinationService.GetAllAsync();
        return View(destinations);
    }
}
