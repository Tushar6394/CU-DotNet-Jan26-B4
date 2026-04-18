using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers;

public class SummaryController : Controller
{
    private readonly HttpClient _client;

    public SummaryController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5287/");
    }

    public async Task<IActionResult> Index()
    {
        var summary = await _client.GetFromJsonAsync<List<CategorySummaryDto>>(
            "api/products/summary");

        return View(summary);
    }
}