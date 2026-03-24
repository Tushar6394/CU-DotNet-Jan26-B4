using Day63.Models;

namespace Day63.DAL;

public interface IStudentRepository
{
    List<Student> GetAll();
    Student? GetById(int id);
    bool Add(Student student);
    bool Update(Student student);
    bool Delete(int id);
}