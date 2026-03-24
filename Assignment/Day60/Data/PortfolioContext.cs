using Day60.Models;
using Microsoft.EntityFrameworkCore;

namespace Day60.Data;

public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
    {
    }

    public DbSet<Investment> Investments => Set<Investment>();
    public DbSet<PortfolioTrackerEntry> PortfolioTrackerEntries => Set<PortfolioTrackerEntry>();
}
