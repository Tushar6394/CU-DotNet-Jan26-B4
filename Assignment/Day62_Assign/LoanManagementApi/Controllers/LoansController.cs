using LoanManagementApi.Data;
using LoanManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController(LoanDbContext context) : ControllerBase
{
    private readonly LoanDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
    {
        return Ok(await _context.Loans.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Loan>> GetLoan(int id)
    {
        var loan = await _context.Loans.FindAsync(id);

        if (loan is null)
        {
            return NotFound();
        }

        return Ok(loan);
    }

    [HttpPost]
    public async Task<ActionResult<Loan>> CreateLoan(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, loan);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLoan(int id, Loan loan)
    {
        if (id != loan.Id)
        {
            return BadRequest("Route id and payload id must match.");
        }

        var existingLoan = await _context.Loans.FindAsync(id);
        if (existingLoan is null)
        {
            return NotFound();
        }

        existingLoan.BorrowerName = loan.BorrowerName;
        existingLoan.Amount = loan.Amount;
        existingLoan.LoanTermMonths = loan.LoanTermMonths;
        existingLoan.IsApproved = loan.IsApproved;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLoan(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan is null)
        {
            return NotFound();
        }

        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
