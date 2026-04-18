using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly HttpClient _client;

    public CategoriesController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5287/"); // set once
    }

    public async Task<IActionResult> Index()
    {
        var data = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories") ?? new List<CategoryDto>();

        var visibleCategories = data
            .Where(category =>
                !string.Equals(category.CategoryName?.Trim(), "Food", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(category.CategoryName?.Trim(), "Electronics", StringComparison.OrdinalIgnoreCase))
            .ToList();

        return View(visibleCategories);
    }
}