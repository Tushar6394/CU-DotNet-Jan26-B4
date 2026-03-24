using Day56.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day56.Controllers;

public class LoanController : Controller
{
    private static readonly List<Loan> Loans =
    [
        new Loan
        {
            Id = 1,
            BorrowerName = "Aarav Shah",
            LenderName = "Sunrise Capital",
            Amount = 180000,
            IsSettled = false
        },
        new Loan
        {
            Id = 2,
            BorrowerName = "Ira Nair",
            LenderName = "Northline Finance",
            Amount = 92000,
            IsSettled = true
        }
    ];

    public IActionResult Index()
    {
        return View(Loans.OrderByDescending(l => l.Id).ToList());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new Loan());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Loan loan)
    {
        if (!ModelState.IsValid)
        {
            return View(loan);
        }

        loan.Id = Loans.Count == 0 ? 1 : Loans.Max(l => l.Id) + 1;
        Loans.Add(loan);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var loan = Loans.FirstOrDefault(l => l.Id == id);
        if (loan is null)
        {
            return NotFound();
        }

        return View(new Loan
        {
            Id = loan.Id,
            BorrowerName = loan.BorrowerName,
            LenderName = loan.LenderName,
            Amount = loan.Amount,
            IsSettled = loan.IsSettled
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Loan loan)
    {
        if (!ModelState.IsValid)
        {
            return View(loan);
        }

        var existingLoan = Loans.FirstOrDefault(l => l.Id == loan.Id);
        if (existingLoan is null)
        {
            return NotFound();
        }

        existingLoan.BorrowerName = loan.BorrowerName;
        existingLoan.LenderName = loan.LenderName;
        existingLoan.Amount = loan.Amount;
        existingLoan.IsSettled = loan.IsSettled;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var loan = Loans.FirstOrDefault(l => l.Id == id);
        if (loan is not null)
        {
            Loans.Remove(loan);
        }

        return RedirectToAction(nameof(Index));
    }
}
