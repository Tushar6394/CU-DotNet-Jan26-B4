using System;
using System.Collections.Generic;

namespace StudentManagement
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        override public string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Marks: {Marks}";
        }
    }

    class StudentManager
    {
        Dictionary<int, Student> studentsData = new Dictionary<int, Student>();

        public bool AddStudent(Student student)
        {
            if (!studentsData.ContainsKey(student.Id))
            {
                studentsData.Add(student.Id, student);
                return true;
            }
            return false;
        }

        public bool UpdateStudent(int id, int marks)
        {
            Student foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int id)
        {
            return studentsData.Remove(id);
        }

        public Student SearchStudent(int id)
        {
            Student student = null;
            bool found = studentsData.TryGetValue(id, out student);
            return student;
        }

        public void DisplayAllStudents()
        {
            foreach (var student in studentsData)
            {
                Console.WriteLine(student.Value);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            int choice;

            do
            {
                Console.WriteLine("\n===== Student Management Menu =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student Marks");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Search Student");
                Console.WriteLine("5. Display All Students");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Student Marks: ");
                        int marks = Convert.ToInt32(Console.ReadLine());

                        bool added = manager.AddStudent(new Student()
                        {
                            Id = id,
                            Name = name,
                            Marks = marks
                        });

                        if (added)
                            Console.WriteLine("Student Added Successfully.");
                        else
                            Console.WriteLine("Student with this ID already exists.");
                        break;

                    case 2:
                        Console.Write("Enter Student ID to Update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Marks: ");
                        int newMarks = Convert.ToInt32(Console.ReadLine());

                        bool updated = manager.UpdateStudent(updateId, newMarks);

                        if (updated)
                            Console.WriteLine("Student Marks Updated Successfully.");
                        else
                            Console.WriteLine("Student Not Found.");
                        break;

                    case 3:
                        Console.Write("Enter Student ID to Delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        bool deleted = manager.DeleteStudent(deleteId);

                        if (deleted)
                            Console.WriteLine("Student Deleted Successfully.");
                        else
                            Console.WriteLine("Student Not Found.");
                        break;

                    case 4:
                        Console.Write("Enter Student ID to Search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());

                        Student foundStudent = manager.SearchStudent(searchId);

                        if (foundStudent != null)
                            Console.WriteLine("Student Found: " + foundStudent);
                        else
                            Console.WriteLine("Student Not Found.");
                        break;

                    case 5:
                        Console.WriteLine("\nAll Students List:");
                        manager.DisplayAllStudents();
                        break;

                    case 6:
                        Console.WriteLine("Exiting Program...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Try Again.");
                        break;
                }

            } while (choice != 6);
        }
    }
}