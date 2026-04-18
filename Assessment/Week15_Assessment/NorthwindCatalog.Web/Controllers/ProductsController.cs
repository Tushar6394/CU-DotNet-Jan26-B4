using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers;

public class ProductsController : Controller
{
    private readonly HttpClient _client;

    public ProductsController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5287/");
    }

    public async Task<IActionResult> ByCategory(int id)
    {
        var products = await _client.GetFromJsonAsync<List<ProductDto>>(
            $"api/products/by-category/{id}");

        return View(products);
    }
}