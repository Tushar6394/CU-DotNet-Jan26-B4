using Day63.DAL;
using Day63.Models;

namespace Day63.BLL;

public class StudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public List<Student> GetAllStudents()
    {
        return _repository.GetAll();
    }

    public Student? GetStudentById(int id)
    {
        if (id <= 0)
        {
            return null;
        }

        return _repository.GetById(id);
    }

    public string? AddStudent(Student student)
    {
        string? validationError = Validate(student);
        if (validationError is not null)
        {
            return validationError;
        }

        bool added = _repository.Add(student);
        return added ? null : "Student with this Id already exists.";
    }

    public string? UpdateStudent(Student student)
    {
        string? validationError = Validate(student);
        if (validationError is not null)
        {
            return validationError;
        }

        bool updated = _repository.Update(student);
        return updated ? null : "Student not found.";
    }

    public bool DeleteStudent(int id)
    {
        if (id <= 0)
        {
            return false;
        }

        return _repository.Delete(id);
    }

    private static string? Validate(Student student)
    {
        if (student.Id <= 0)
        {
            return "Id must be greater than 0.";
        }

        if (string.IsNullOrWhiteSpace(student.Name))
        {
            return "Name is required.";
        }

        if (student.Grade < 0 || student.Grade > 100)
        {
            return "Grade must be between 0 and 100.";
        }

        return null;
    }
}