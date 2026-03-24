using Day63.Models;

namespace Day63.DAL;

public class ListStudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new();

    public List<Student> GetAll()
    {
        return _students.Select(s => Clone(s)).ToList();
    }

    public Student? GetById(int id)
    {
        Student? student = _students.FirstOrDefault(s => s.Id == id);
        return student is null ? null : Clone(student);
    }

    public bool Add(Student student)
    {
        if (_students.Any(s => s.Id == student.Id))
        {
            return false;
        }

        _students.Add(Clone(student));
        return true;
    }

    public bool Update(Student student)
    {
        Student? existing = _students.FirstOrDefault(s => s.Id == student.Id);
        if (existing is null)
        {
            return false;
        }

        existing.Name = student.Name;
        existing.Grade = student.Grade;
        return true;
    }

    public bool Delete(int id)
    {
        Student? existing = _students.FirstOrDefault(s => s.Id == id);
        if (existing is null)
        {
            return false;
        }

        _students.Remove(existing);
        return true;
    }

    private static Student Clone(Student student)
    {
        return new Student
        {
            Id = student.Id,
            Name = student.Name,
            Grade = student.Grade
        };
    }
}