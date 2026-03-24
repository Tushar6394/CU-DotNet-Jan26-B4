using Microsoft.AspNetCore.Mvc;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers;

[Route("Portfolio")]
public class PortfolioController : Controller
{
    private static readonly List<Asset> Assets =
    [
        new Asset { Id = 1, Ticker = "AAPL", Name = "Apple Inc.", Value = 186.35, Units = 12, Sector = "Technology" },
        new Asset { Id = 2, Ticker = "MSFT", Name = "Microsoft Corp.", Value = 419.80, Units = 6, Sector = "Technology" },
        new Asset { Id = 3, Ticker = "XOM", Name = "Exxon Mobil", Value = 109.12, Units = 20, Sector = "Energy" },
        new Asset { Id = 4, Ticker = "HDFCBANK", Name = "HDFC Bank", Value = 61.41, Units = 35, Sector = "Financial Services" }
    ];

    private static readonly List<Transaction> Movements =
    [
        new Transaction { Id = 1, Description = "Dividend Reinvestment", Amount = 250.75, Category = "Income", Date = DateTime.Today.AddDays(-3) },
        new Transaction { Id = 2, Description = "Brokerage Fee", Amount = 32.10, Category = "Expense", Date = DateTime.Today.AddDays(-1) }
    ];

    [HttpGet("")]
    [HttpGet("Index")]
    public IActionResult Index()
    {
        ViewData["Total"] = Assets.Sum(a => a.Value * a.Units);
        ViewBag.LastMovement = Movements.OrderByDescending(m => m.Date).FirstOrDefault();
        return View(Assets.OrderBy(a => a.Ticker).ToList());
    }

    [HttpGet("Asset/Info/{id:int}")]
    [Route("/Asset/Info/{id:int}")]
    public IActionResult Details(int id)
    {
        var asset = Assets.FirstOrDefault(a => a.Id == id);
        if (asset is null)
        {
            return NotFound();
        }

        return View(asset);
    }

    [HttpPost("Asset/Delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var asset = Assets.FirstOrDefault(a => a.Id == id);
        if (asset is not null)
        {
            Assets.Remove(asset);
            TempData["Message"] = $"Asset {asset.Ticker} was removed from your portfolio.";
        }

        return RedirectToAction(nameof(Index));
    }
}
