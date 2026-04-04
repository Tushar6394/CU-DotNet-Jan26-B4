using Microsoft.EntityFrameworkCore;
using WebAppMVC7.Models;

namespace WebAppMVC7.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("DbInitializer");
        var context = serviceProvider.GetRequiredService<AppDbContext>();

        const int maxAttempts = 10;

        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                await context.Database.EnsureCreatedAsync();

                if (!await context.Employees.AnyAsync())
                {
                    context.Employees.AddRange(
                        new Emp { EmpName = "Aarav Mehta", City = "Pune", Salary = 55000.00m },
                        new Emp { EmpName = "Nisha Patel", City = "Ahmedabad", Salary = 62000.00m },
                        new Emp { EmpName = "Riya Sharma", City = "Bengaluru", Salary = 71000.00m });

                    await context.SaveChangesAsync();
                }

                return;
            }
            catch (Exception exception) when (attempt < maxAttempts)
            {
                logger.LogWarning(exception, "Database not ready on attempt {Attempt}. Retrying...", attempt);
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }

        await context.Database.EnsureCreatedAsync();
    }
}