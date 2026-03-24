using Day60.Data;
using Day60.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day60.Controllers;

public class TrackerController : Controller
{
    private readonly PortfolioContext _context;

    public TrackerController(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var entries = await _context.PortfolioTrackerEntries
            .OrderByDescending(e => e.TrackedOn)
            .ToListAsync();

        return View(entries);
    }

    public IActionResult Create()
    {
        return View(new PortfolioTrackerCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PortfolioTrackerCreateViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var entry = new PortfolioTrackerEntry
        {
            PortfolioValue = vm.PortfolioValue,
            CashReserve = vm.CashReserve,
            Notes = vm.Notes,
            TrackedOn = DateTime.Now
        };

        _context.PortfolioTrackerEntries.Add(entry);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
