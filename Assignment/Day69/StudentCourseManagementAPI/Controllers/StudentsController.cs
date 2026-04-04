using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementAPI.Data;
using StudentCourseManagementAPI.DTOs;
using StudentCourseManagementAPI.Models;

namespace StudentCourseManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
    {
        var students = await _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Courses = s.StudentCourses.Select(sc => new CourseSummaryDto
                {
                    Id = sc.Course.Id,
                    Title = sc.Course.Title,
                    Credits = sc.Course.Credits
                }).ToList()
            })
            .ToListAsync();

        return Ok(students);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentDto>> GetStudent(int id)
    {
        var student = await _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .Where(s => s.Id == id)
            .Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Courses = s.StudentCourses.Select(sc => new CourseSummaryDto
                {
                    Id = sc.Course.Id,
                    Title = sc.Course.Title,
                    Credits = sc.Course.Credits
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (student is null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Email))
        {
            return BadRequest("Name and Email are required.");
        }

        var emailExists = await _context.Students.AnyAsync(s => s.Email.ToLower() == dto.Email.ToLower());
        if (emailExists)
        {
            return BadRequest("Email must be unique.");
        }

        var student = new Student
        {
            Name = dto.Name.Trim(),
            Email = dto.Email.Trim(),
            Age = dto.Age
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        var response = new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Age = student.Age
        };

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Email))
        {
            return BadRequest("Name and Email are required.");
        }

        var student = await _context.Students.FindAsync(id);
        if (student is null)
        {
            return NotFound();
        }

        var emailExists = await _context.Students.AnyAsync(s => s.Id != id && s.Email.ToLower() == dto.Email.ToLower());
        if (emailExists)
        {
            return BadRequest("Email must be unique.");
        }

        student.Name = dto.Name.Trim();
        student.Email = dto.Email.Trim();
        student.Age = dto.Age;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student is null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
