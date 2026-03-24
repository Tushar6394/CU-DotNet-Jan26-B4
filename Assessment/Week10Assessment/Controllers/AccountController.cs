using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Week10Assessment.Data;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers;

public class AccountController : Controller
{
    private readonly FinanceDbContext _context;
    private static readonly string[] AllowedAccountTypes = ["Savings", "Current", "Investment"];

    public AccountController(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var accounts = await _context.Accounts
            .OrderByDescending(a => a.OpenedOn)
            .ToListAsync();

        return View(accounts);
    }

    public async Task<IActionResult> Details(int id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        if (account is null)
        {
            return NotFound();
        }

        return View(account);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Account account)
    {
        account.AccountType = NormalizeAccountType(account.AccountType);
        if (!AllowedAccountTypes.Contains(account.AccountType))
        {
            ModelState.AddModelError(nameof(account.AccountType), "Account type must be Savings, Current, or Investment.");
        }

        if (!ModelState.IsValid)
        {
            return View(account);
        }

        _context.Accounts.Add(account);
        _context.Transactions.Add(new Transaction
        {
            Description = $"Opening record for {account.HolderName}",
            Amount = account.Balance,
            Category = account.Balance >= 0 ? "Income" : "Expense",
            Date = DateTime.Today
        });
        await _context.SaveChangesAsync();

        TempData["Success"] = $"Account for {account.HolderName} was created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account is null)
        {
            return NotFound();
        }

        return View(account);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Account account)
    {
        if (id != account.Id)
        {
            return NotFound();
        }

        account.AccountType = NormalizeAccountType(account.AccountType);
        if (!AllowedAccountTypes.Contains(account.AccountType))
        {
            ModelState.AddModelError(nameof(account.AccountType), "Account type must be Savings, Current, or Investment.");
        }

        if (!ModelState.IsValid)
        {
            return View(account);
        }

        _context.Update(account);
        await _context.SaveChangesAsync();
        TempData["Success"] = $"Account #{account.Id} was updated.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        if (account is null)
        {
            return NotFound();
        }

        return View(account);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account is not null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Account deleted successfully.";
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Transfer()
    {
        await PopulateAccountOptionsAsync();
        return View(new TransferViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Transfer(TransferViewModel model)
    {
        if (model.FromAccountId == model.ToAccountId)
        {
            ModelState.AddModelError(string.Empty, "Sender and receiver must be different accounts.");
        }

        if (!ModelState.IsValid)
        {
            await PopulateAccountOptionsAsync(model.FromAccountId, model.ToAccountId);
            return View(model);
        }

        var fromAccount = await _context.Accounts.FindAsync(model.FromAccountId!.Value);
        var toAccount = await _context.Accounts.FindAsync(model.ToAccountId!.Value);

        if (fromAccount is null || toAccount is null)
        {
            ModelState.AddModelError(string.Empty, "Selected account was not found.");
            await PopulateAccountOptionsAsync(model.FromAccountId, model.ToAccountId);
            return View(model);
        }

        if (fromAccount.Balance < model.Amount)
        {
            ModelState.AddModelError(nameof(model.Amount), "Insufficient balance in sender account.");
            await PopulateAccountOptionsAsync(model.FromAccountId, model.ToAccountId);
            return View(model);
        }

        fromAccount.Balance -= model.Amount;
        toAccount.Balance += model.Amount;

        var transferDate = model.Date == default ? DateTime.Today : model.Date;
        var note = string.IsNullOrWhiteSpace(model.Description) ? "Fund transfer" : model.Description.Trim();

        _context.Transactions.AddRange(
            new Transaction
            {
                Description = $"{note} | {fromAccount.HolderName} -> {toAccount.HolderName}",
                Amount = model.Amount,
                Category = "Debit",
                Date = transferDate
            },
            new Transaction
            {
                Description = $"{note} | {toAccount.HolderName} <- {fromAccount.HolderName}",
                Amount = model.Amount,
                Category = "Credit",
                Date = transferDate
            }
        );

        await _context.SaveChangesAsync();
        TempData["Success"] = $"Transfer completed: {fromAccount.HolderName} sent {model.Amount:C} to {toAccount.HolderName}.";
        return RedirectToAction(nameof(Transactions));
    }

    public async Task<IActionResult> Transactions(string? category, DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Transactions.AsQueryable();

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(t => t.Category == category);
        }

        if (fromDate.HasValue)
        {
            var from = fromDate.Value.Date;
            query = query.Where(t => t.Date.Date >= from);
        }

        if (toDate.HasValue)
        {
            var to = toDate.Value.Date;
            query = query.Where(t => t.Date.Date <= to);
        }

        ViewBag.SelectedCategory = category;
        ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
        ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

        var allTransactions = await query
            .OrderByDescending(t => t.Date)
            .ThenByDescending(t => t.Id)
            .ToListAsync();

        return View(allTransactions);
    }

    private async Task PopulateAccountOptionsAsync(int? fromAccountId = null, int? toAccountId = null)
    {
        var accounts = await _context.Accounts
            .OrderBy(a => a.HolderName)
            .Select(a => new
            {
                a.Id,
                Label = $"{a.HolderName} ({a.AccountType}) - {a.Balance:C}"
            })
            .ToListAsync();

        ViewBag.AccountOptions = new SelectList(accounts, "Id", "Label");
        ViewBag.FromAccountId = fromAccountId;
        ViewBag.ToAccountId = toAccountId;
    }

    private static string NormalizeAccountType(string? rawType)
    {
        if (string.IsNullOrWhiteSpace(rawType))
        {
            return string.Empty;
        }

        var value = rawType.Trim().ToLowerInvariant();
        return value switch
        {
            "saving" or "savings" => "Savings",
            "current" => "Current",
            "investment" or "investments" => "Investment",
            _ => rawType.Trim()
        };
    }
}
