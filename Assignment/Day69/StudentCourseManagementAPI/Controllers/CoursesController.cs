using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementAPI.Data;
using StudentCourseManagementAPI.DTOs;
using StudentCourseManagementAPI.Models;

namespace StudentCourseManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
    {
        var courses = await _context.Courses
            .Include(c => c.StudentCourses)
            .ThenInclude(sc => sc.Student)
            .Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                Students = c.StudentCourses.Select(sc => new StudentSummaryDto
                {
                    Id = sc.Student.Id,
                    Name = sc.Student.Name,
                    Email = sc.Student.Email
                }).ToList()
            })
            .ToListAsync();

        return Ok(courses);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseDto>> GetCourse(int id)
    {
        var course = await _context.Courses
            .Include(c => c.StudentCourses)
            .ThenInclude(sc => sc.Student)
            .Where(c => c.Id == id)
            .Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                Students = c.StudentCourses.Select(sc => new StudentSummaryDto
                {
                    Id = sc.Student.Id,
                    Name = sc.Student.Name,
                    Email = sc.Student.Email
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (course is null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> CreateCourse(CreateCourseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            return BadRequest("Title is required.");
        }

        var course = new Course
        {
            Title = dto.Title.Trim(),
            Credits = dto.Credits
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        var response = new CourseDto
        {
            Id = course.Id,
            Title = course.Title,
            Credits = course.Credits
        };

        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            return BadRequest("Title is required.");
        }

        var course = await _context.Courses.FindAsync(id);
        if (course is null)
        {
            return NotFound();
        }

        course.Title = dto.Title.Trim();
        course.Credits = dto.Credits;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course is null)
        {
            return NotFound();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
