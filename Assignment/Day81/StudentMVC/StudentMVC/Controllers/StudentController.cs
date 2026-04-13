using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using StudentMVC.Models;
using System.Net.Http.Json;

public class StudentController : Controller
{
    HttpClient client = new HttpClient();
    string baseUrl = "https://studentapi-tushar-001.azurewebsites.net/";

    // INDEX
    public async Task<IActionResult> Index()
    {
        var students = await client.GetFromJsonAsync<List<Student>>(baseUrl + "api/students");
        return View(students);
    }

    // DETAILS
    public async Task<IActionResult> Details(int id)
    {
        var student = await client.GetFromJsonAsync<Student>(baseUrl + $"api/students/{id}");
        return View(student);
    }

    // CREATE (GET)
    public IActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        await client.PostAsJsonAsync(baseUrl + "api/students", student);
        return RedirectToAction("Index");
    }

    // EDIT (GET)
    public async Task<IActionResult> Edit(int id)
    {
        var student = await client.GetFromJsonAsync<Student>(baseUrl + $"api/students/{id}");
        return View(student);
    }

    // EDIT (POST)
    [HttpPost]
    public async Task<IActionResult> Edit(Student student)
    {
        await client.PutAsJsonAsync(baseUrl + $"api/students/{student.Id}", student);
        return RedirectToAction("Index");
    }

    // DELETE
    public async Task<IActionResult> Delete(int id)
    {
        await client.DeleteAsync(baseUrl + $"api/students/{id}");
        return RedirectToAction("Index");
    }
}