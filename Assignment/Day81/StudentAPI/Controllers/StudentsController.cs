using Microsoft.AspNetCore.Mvc;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students.ToList());
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var data = _context.Students.Find(id);
            if (data == null) return NotFound();

            data.Name = student.Name;
            data.Age = student.Age;
            data.Course = student.Course;

            _context.SaveChanges();
            return Ok(data);
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Students.Find(id);
            if (data == null) return NotFound();

            _context.Students.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}