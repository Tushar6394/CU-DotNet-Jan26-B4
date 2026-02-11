using System.Security.Cryptography.X509Certificates;

class Student
{
    public int Id;
    public string Name;
    public string Class;
    public int Marks;

    public override string ToString()
    {
        return $"{Name}, {Class}, {Marks}";
    }
}

class Employee
{
    public int Id;
    public string Name;
    public string Dept;
    public double Salary;
    public DateTime JoinDate;
}

internal class Demo05LINQOperations
{
    static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
        };

        
        

        // //filter students with marks > 80
        // var moreThan80 = students.Where(s => s.Marks > 80).ToList();

        // foreach(var student in moreThan80)
        // {
        //     Console.WriteLine(student);
        // }
        // //display total marks for the collection of students
        // var totalMarks = students.Sum(s => s.Marks);
        // Console.WriteLine("Total Marks: " + totalMarks);

        // Console.WriteLine("------------------- Projection -----------------");

        // var selectedProperties = students.Select(s => new { s.Name, s.Marks }).ToList();
        // foreach(var s in selectedProperties)
        // {
        //     Console.WriteLine($"{s.Name} - {s.Marks}");
        // }

        // //grouping 
        // Console.WriteLine("------------------- Grouping -------------------");

        // var studentClasses = students.GroupBy(s => s.Class);
        // foreach(var group in studentClasses)
        // {
        //     Console.WriteLine(group.Key + " - " + group.Count());
        //         foreach(var stud in group)
        //         {
        //             Console.WriteLine("\t" + stud.Name);
        //         }
        // }


        // var nameWithH = students.Where(s => s.Name.Contains("h"));
        // foreach(var stud in nameWithH)
        // {
        //     Console.WriteLine(stud.Name);
        // }


        // var topThree = students.OrderByDescending(o => o.Marks).Take(3);
        // foreach(var stud in topThree)
        // {
        //     Console.WriteLine(stud.Name + " - " + stud.Marks);
        // }


        // var firstNameWithH = students.FirstOrDefault(s => s.Name.Contains("h"));
        // Console.WriteLine(firstNameWithH?.Name);

        //Display class with avg in the class
        var classAvg = students.GroupBy(g => g.Class)
                                .Select(g=> 
                                new { Class = g.Key, 
                                Avg = g.Average(s => s.Marks) }
                                );
        foreach(var avg in classAvg)
        {
            Console.WriteLine(avg.Class + " - " + avg.Avg);
        }

        //select field_list from table
        //sql filtering - row and column(row -- selecting and column -- projection)


        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
        };

        var empJoinedAfter2020 = employees.
                        Where(e=>e.JoinDate.Year > 2020);
        foreach(var emp in empJoinedAfter2020)
        {
            Console.WriteLine("Emplyees joined after 2020: " + emp.Name);
        }
        Console.WriteLine("Done");


    }
}

