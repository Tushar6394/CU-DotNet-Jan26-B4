using Microsoft.EntityFrameworkCore;
using InsureTrust.API.Models;

namespace InsureTrust.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<PolicyType> PolicyTypes { get; set; }
    public DbSet<PolicyTerm> PolicyTerms { get; set; }
    public DbSet<PolicyRequiredField> PolicyRequiredFields { get; set; }
    public DbSet<UserPolicy> UserPolicies { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<SupportQuery> SupportQueries { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.UserNumber).IsUnique();
        modelBuilder.Entity<UserPolicy>().HasIndex(up => up.PolicyNumber).IsUnique();
        modelBuilder.Entity<Claim>().HasIndex(c => c.ClaimNumber).IsUnique();
        modelBuilder.Entity<SupportQuery>().HasIndex(s => s.TicketNumber).IsUnique();
        modelBuilder.Entity<Payment>().HasIndex(p => p.PaymentNumber).IsUnique();

        modelBuilder.Entity<User>().Property(u => u.Balance).HasPrecision(18, 2);
        modelBuilder.Entity<UserPolicy>().Property(up => up.PackageAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Claim>().Property(c => c.MaturityAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Payment>().Property(p => p.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<PolicyType>().Property(pt => pt.BaseMonthlyPremium).HasPrecision(18, 2);

        // Seed Admin
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            UserNumber = "ADMIN001",
            Name = "System Admin",
            Email = "admin@insuretrust.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            Role = "Admin",
            PhoneNo = "9999999999",
            PanCard = "ADMIN1234A",
            KycStatus = "Verified",
            Balance = 0,
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        });

        // Seed Policy Types
        modelBuilder.Entity<PolicyType>().HasData(
            new PolicyType { Id = 1, Name = "Term Life", Category = "Personal", Icon = "shield", Description = "Comprehensive life coverage protecting your family's financial future.", CoverageDetails = "Death benefit, Terminal illness rider, Accidental death benefit", BaseMonthlyPremium = 5000, MinTenureMonths = 12, MaxTenureMonths = 360, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PolicyType { Id = 2, Name = "Health", Category = "Personal", Icon = "heart", Description = "Complete medical coverage for hospitalization, surgeries, and outpatient care.", CoverageDetails = "Hospitalization, Day care procedures, Pre & post hospitalization", BaseMonthlyPremium = 3000, MinTenureMonths = 12, MaxTenureMonths = 60, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PolicyType { Id = 3, Name = "Vehicle", Category = "Personal", Icon = "car", Description = "Full coverage for cars and bikes against accidents, theft, and damage.", CoverageDetails = "Own damage, Third party liability, Personal accident cover", BaseMonthlyPremium = 2000, MinTenureMonths = 12, MaxTenureMonths = 36, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PolicyType { Id = 4, Name = "Home", Category = "Personal", Icon = "home", Description = "Protect your home and belongings against fire, flood, and burglary.", CoverageDetails = "Structure damage, Contents, Liability protection", BaseMonthlyPremium = 1500, MinTenureMonths = 12, MaxTenureMonths = 120, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PolicyType { Id = 5, Name = "Property", Category = "Business", Icon = "building", Description = "Commercial property insurance for businesses and investment properties.", CoverageDetails = "Building damage, Business interruption, Liability", BaseMonthlyPremium = 8000, MinTenureMonths = 12, MaxTenureMonths = 120, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PolicyType { Id = 6, Name = "Employee Group Benefits", Category = "Business", Icon = "users", Description = "Group insurance plans covering all employees under a single policy.", CoverageDetails = "Group health, Group life, Disability coverage", BaseMonthlyPremium = 15000, MinTenureMonths = 12, MaxTenureMonths = 60, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new PolicyType { Id = 7, Name = "Engineering", Category = "Business", Icon = "settings", Description = "Specialized coverage for construction projects, equipment, and machinery.", CoverageDetails = "Equipment breakdown, Contractors risk, Erection all risks", BaseMonthlyPremium = 12000, MinTenureMonths = 12, MaxTenureMonths = 60, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        // Seed Terms
        modelBuilder.Entity<PolicyTerm>().HasData(
            new PolicyTerm { Id = 1, PolicyTypeId = 1, TermText = "Policy is valid for the tenure period specified at purchase." },
            new PolicyTerm { Id = 2, PolicyTypeId = 1, TermText = "Premium must be paid monthly without grace period exceeding 30 days." },
            new PolicyTerm { Id = 3, PolicyTypeId = 1, TermText = "Death claims require submission within 90 days of the event." },
            new PolicyTerm { Id = 4, PolicyTypeId = 2, TermText = "Pre-existing diseases are covered after a 2-year waiting period." },
            new PolicyTerm { Id = 5, PolicyTypeId = 2, TermText = "Cashless treatment available at 5000+ network hospitals." },
            new PolicyTerm { Id = 6, PolicyTypeId = 3, TermText = "Vehicle must be registered in India and in roadworthy condition." },
            new PolicyTerm { Id = 7, PolicyTypeId = 3, TermText = "Claims must be filed within 7 days of the incident." }
        );

        // Seed Required Fields
        modelBuilder.Entity<PolicyRequiredField>().HasData(
            new PolicyRequiredField { Id = 1, PolicyTypeId = 1, FieldName = "Nominee Name", FieldType = "text", IsMandatory = true },
            new PolicyRequiredField { Id = 2, PolicyTypeId = 1, FieldName = "Nominee Relation", FieldType = "text", IsMandatory = true },
            new PolicyRequiredField { Id = 3, PolicyTypeId = 1, FieldName = "Date of Birth", FieldType = "date", IsMandatory = true },
            new PolicyRequiredField { Id = 4, PolicyTypeId = 2, FieldName = "Date of Birth", FieldType = "date", IsMandatory = true },
            new PolicyRequiredField { Id = 5, PolicyTypeId = 2, FieldName = "Existing Medical Conditions", FieldType = "text", IsMandatory = false },
            new PolicyRequiredField { Id = 6, PolicyTypeId = 3, FieldName = "Vehicle Registration Number", FieldType = "text", IsMandatory = true },
            new PolicyRequiredField { Id = 7, PolicyTypeId = 3, FieldName = "Vehicle Make & Model", FieldType = "text", IsMandatory = true },
            new PolicyRequiredField { Id = 8, PolicyTypeId = 4, FieldName = "Property Address", FieldType = "text", IsMandatory = true },
            new PolicyRequiredField { Id = 9, PolicyTypeId = 4, FieldName = "Property Value (₹)", FieldType = "text", IsMandatory = true }
        );
    }
}
