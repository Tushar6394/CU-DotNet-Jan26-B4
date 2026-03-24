using Day60.Data;
using Day60.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day60.Controllers;

public class InvestmentsController : Controller
{
    private readonly PortfolioContext _context;

    public InvestmentsController(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var investments = await _context.Investments
            .OrderByDescending(i => i.PurchaseDate)
            .ToListAsync();

        return View(investments);
    }

    public IActionResult Create()
    {
        return View(new InvestmentCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InvestmentCreateViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var model = new Investment
        {
            TickerSymbol = vm.TickerSymbol,
            AssetName = vm.AssetName,
            PurchasePrice = vm.Price,
            Quantity = vm.Quantity,
            PurchaseDate = DateTime.Now
        };

        _context.Investments.Add(model);
        await _context.SaveChangesAsync();

        ModelState.Clear();
        return View(vm);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var investment = await _context.Investments.FindAsync(id);
        if (investment == null)
        {
            return NotFound();
        }

        var vm = new InvestmentCreateViewModel
        {
            Id = investment.Id,
            TickerSymbol = investment.TickerSymbol,
            AssetName = investment.AssetName,
            Price = investment.PurchasePrice,
            Quantity = investment.Quantity
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, InvestmentCreateViewModel vm)
    {
        var investment = await _context.Investments.FindAsync(id);
        if (investment == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        investment.TickerSymbol = vm.TickerSymbol;
        investment.AssetName = vm.AssetName;
        investment.PurchasePrice = vm.Price;
        investment.Quantity = vm.Quantity;

        _context.Investments.Update(investment);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var investment = await _context.Investments.FindAsync(id);
        if (investment == null)
        {
            return NotFound();
        }

        _context.Investments.Remove(investment);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
