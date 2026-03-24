using LoanManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementApi.Data;

public class LoanDbContext(DbContextOptions<LoanDbContext> options) : DbContext(options)
{
    public DbSet<Loan> Loans => Set<Loan>();
}
