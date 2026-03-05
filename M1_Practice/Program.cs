using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

class Student
{
    public int StudId { get; set; }
    public string SName { get; set; }

    public override int GetHashCode() => StudId;
    public override bool Equals(object obj) => obj is Student s && s.StudId == StudId;
}

class Program 
{
    static void Main()
    {
        var records = new Dictionary<Student, int>();

        void AddOrUpdate(Student student, int marks) 
        {
            if (records.TryGetValue(student, out int existing))
            {
                if (marks > existing)
                    records[student] = marks;
            }
            else
            {
                records.Add(student, marks);
            }
        }
        AddOrUpdate(new Student { StudId = 1, SName = "Tushar" }, 75);
        AddOrUpdate(new Student { StudId = 2, SName = "Singh"   }, 88);
        AddOrUpdate(new Student { StudId = 1, SName = "Tushar" }, 90); 
        AddOrUpdate(new Student { StudId = 2, SName = "Singh"   }, 70); 

        foreach (var (s, m) in records)
            Console.WriteLine($"{s.SName}: {m}");
    }
}
