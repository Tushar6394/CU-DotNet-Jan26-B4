using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementAPI.Data;
using StudentCourseManagementAPI.DTOs;
using StudentCourseManagementAPI.Models;

namespace StudentCourseManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnrollController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> EnrollStudent(EnrollmentDto dto)
    {
        var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
        if (!studentExists)
        {
            return NotFound($"Student with Id {dto.StudentId} not found.");
        }

        var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);
        if (!courseExists)
        {
            return NotFound($"Course with Id {dto.CourseId} not found.");
        }

        var alreadyEnrolled = await _context.StudentCourses
            .AnyAsync(sc => sc.StudentId == dto.StudentId && sc.CourseId == dto.CourseId);

        if (alreadyEnrolled)
        {
            return BadRequest("Student is already enrolled in this course.");
        }

        _context.StudentCourses.Add(new StudentCourse
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        });

        await _context.SaveChangesAsync();
        return Ok("Enrollment successful.");
    }
}
