using Microsoft.AspNetCore.Mvc;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers;

public class MarketController : Controller
{
    public IActionResult Summary()
    {
        ViewBag.MarketStatus = DateTime.Now.Hour is >= 9 and <= 16 ? "Market Open" : "Market Closed";
        ViewData["TopGainer"] = "NVDA +4.8%";
        ViewData["Volume"] = 128903450L;
        ViewBag.RecentSignals = new List<Transaction>
        {
            new() { Id = 101, Description = "ETF Buy Momentum", Amount = 1200.45, Category = "Income", Date = DateTime.Today },
            new() { Id = 102, Description = "Sector Rotation Cost", Amount = 410.20, Category = "Expense", Date = DateTime.Today.AddDays(-1) }
        };

        return View();
    }

    [HttpGet("Analyze/{ticker}/{days:int?}")]
    public IActionResult Analyze(string ticker, int? days)
    {
        var finalDays = days ?? 30;
        ViewBag.Ticker = ticker.ToUpperInvariant();
        ViewBag.Days = finalDays;

        return View();
    }
}
