using System.Text.Json;
using Day63.Models;

namespace Day63.DAL;

public class JsonStudentRepository : IStudentRepository
{
    private readonly string _filePath;
    private readonly List<Student> _students;
    private readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public JsonStudentRepository(string? filePath = null)
    {
        _filePath = filePath ?? Path.Combine(Directory.GetCurrentDirectory(), "students.json");
        _students = LoadFromFile();
    }

    public List<Student> GetAll()
    {
        return _students.Select(Clone).ToList();
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
        SaveToFile();
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
        SaveToFile();
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
        SaveToFile();
        return true;
    }

    private List<Student> LoadFromFile()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Student>();
        }

        try
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(json, _jsonOptions) ?? new List<Student>();
        }
        catch
        {
            return new List<Student>();
        }
    }

    private void SaveToFile()
    {
        string json = JsonSerializer.Serialize(_students, _jsonOptions);
        File.WriteAllText(_filePath, json);
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