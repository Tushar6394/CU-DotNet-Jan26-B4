using Microsoft.EntityFrameworkCore;
using Vagabond.Api.Models;

namespace Vagabond.Api.Data;

public class VagabondDbContext(DbContextOptions<VagabondDbContext> options) : DbContext(options)
{
    public DbSet<Destination> Destinations => Set<Destination>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(d => d.Id);
            entity.ToTable(table =>
            {
                table.HasCheckConstraint("CK_Destinations_Rating", "Rating >= 1 AND Rating <= 5");
            });

            entity.Property(d => d.CityName)
                .IsRequired();

            entity.Property(d => d.Country)
                .IsRequired();

            entity.Property(d => d.Description)
                .HasMaxLength(200);

            entity.Property(d => d.Rating)
                .HasDefaultValue(3);
        });

        base.OnModelCreating(modelBuilder);
    }
}
