using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Services.Repositories;
using NorthwindCatalog.Services.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

var northwindConnection = builder.Configuration.GetConnectionString("NorthwindConnection")
    ?? throw new InvalidOperationException("Connection string 'NorthwindConnection' was not found.");

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(northwindConnection));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// API + MVC routes
app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();