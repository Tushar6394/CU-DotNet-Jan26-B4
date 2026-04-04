using Microsoft.EntityFrameworkCore;
using WebMinimalAPI.Models;

namespace WebMinimalAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Car entity configuration
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Make)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Year)
                .IsRequired();

            entity.Property(c => c.Price)
                .HasPrecision(18, 2)
                .IsRequired();
        });
    }
}
