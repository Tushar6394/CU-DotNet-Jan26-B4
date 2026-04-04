using Microsoft.EntityFrameworkCore;
using Vagabond.Api.Data;
using Vagabond.Api.Middleware;
using Vagabond.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VagabondDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VagabondConnection")));

builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
