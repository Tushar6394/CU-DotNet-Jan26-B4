using Microsoft.EntityFrameworkCore;
using WebAppMVC7.Models;

namespace WebAppMVC7.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Emp> Employees => Set<Emp>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emp>(entity =>
        {
            entity.ToTable("Employees");
            entity.HasKey(employee => employee.EmpId);
            entity.Property(employee => employee.EmpName).HasMaxLength(100).IsRequired();
            entity.Property(employee => employee.City).HasMaxLength(100).IsRequired();
            entity.Property(employee => employee.Salary).HasColumnType("numeric(12,2)");
        });
    }
}