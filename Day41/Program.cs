class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
    public string City { get; set; }
}

class Course
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string CourseName { get; set; }
}
class Order
{
    public int OrderId { get; set; }
    public List<string> Items { get; set; }
}


internal class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var students = new List<Student>
                {
                    new Student{ Id=1, Name="Amit", Age=21, Marks=85, City="Delhi"},
                    new Student{ Id=2, Name="Riya", Age=19, Marks=92, City="Mumbai"},
                    new Student{ Id=3, Name="Karan", Age=22, Marks=75, City="Delhi"},
                    new Student{ Id=4, Name="Sneha", Age=20, Marks=88, City="Pune"},
                };

        var courses = new List<Course>
                {
                    new Course{ Id=1, StudentId=1, CourseName="C#"},
                    new Course{ Id=2, StudentId=2, CourseName="Java"},
                    new Course{ Id=3, StudentId=1, CourseName="SQL"},
                };
        
        var orders = new List<Order>
                {
                    new Order{ OrderId = 1, Items = new List<string>{"Laptop","Mouse"}},
                    new Order{ OrderId = 2, Items = new List<string>{"Keyboard"}}
            };
        //create a query to get all students with marks greater than 80 using Lambda expression and join
        var highScoringStudents = students.Where(s => s.Marks > 80);
        Console.WriteLine(string.Join(", ", highScoringStudents.Select(s => s.Name)));

        //create a query to get all students from Delhi using Lambda expression and join
        var studentsFromDelhi = students.Where(s => s.City == "Delhi");
        Console.WriteLine(string.Join(", ", studentsFromDelhi.Select(s => s.Name)));

        
        //create a query to display all odd numbers using Lambda expression and join
        var oddNumbers = numbers.Where(n => n % 2 != 0);
        Console.WriteLine(string.Join(", ", oddNumbers));

        //displat Even numbers in descending order using Lambda expression and join
        var evenNumbersDescending = numbers.Where(n => n % 2 == 0).OrderByDescending(n => n);
        Console.WriteLine(string.Join(", ", evenNumbersDescending));

        //show different cities from students list using Lambda expression and join
        var diffCities = students.Select(s => s.City).Distinct();
        Console.WriteLine(string.Join(", ", diffCities));

        //create a query to get all courses using lambda expression and join
        var allCourses = courses.Select(c => c.CourseName);
        Console.WriteLine(string.Join(", ", allCourses));

        //display name and city of students using lambda expression and join
        var nameAndCity = students.Select(s => new { s.Name, s.City });
        foreach (var item in nameAndCity)        
        {
            Console.WriteLine($"{item.Name} - {item.City}");
        }

        //create a query to get students along with their courses using lambda expression and join
        var studentsWithCourses = students.Join(courses, s => s.Id, c => c.StudentId, (s, c) => new { s.Name, c.CourseName });
        foreach (var item in studentsWithCourses)
        {
            Console.WriteLine($"{item.Name} - {item.CourseName}");
        }

        //display students having 'a' in their name using lambda expression and join
        var studentsWithA = students.Where(s => s.Name.Contains("a"));
        Console.WriteLine(string.Join(", ", studentsWithA.Select(s => s.Name)));
//from course list
        //display courses having 'C' in their name using lambda expression and join
        var coursesWithC = courses.Where(c => c.CourseName.Contains("C"));
        Console.WriteLine(string.Join(", ", coursesWithC.Select(c => c.CourseName)));

        //display students with marks greater than 80 and from Delhi using lambda expression and join
        var highScoringStudentsFromDelhi = students.Where(s => s.Marks > 80 && s.City == "Delhi");
        Console.WriteLine(string.Join(", ", highScoringStudentsFromDelhi.Select(s => s.Name)));
        
        //join question to get students along with their courses where marks are greater than 80 using lambda expression and join
        var highScoringStudentsWithCourses = students.Where(s => s.Marks > 80).Join(courses, s => s.Id, c => c.StudentId, (s, c) => new { s.Name, c.CourseName });
        foreach (var item in highScoringStudentsWithCourses)
        {
            Console.WriteLine($"{item.Name} - {item.CourseName}");
        }

        //display id and name for students not enrolled in any course using lambda expression and join
        var studentsNotEnrolled = students.GroupJoin(courses, s => s.Id, c => c.StudentId, (s, c) => new { Student = s, Courses = c })
                                         .Where(sc => !sc.Courses.Any())
                                         .Select(sc => new { sc.Student.Id, sc.Student.Name });
        foreach (var i in studentsNotEnrolled)
        {
            Console.WriteLine($"{i.Id} - {i.Name}");
        }


        //check if all studnts have age more than 18 using lambda expression and join
        var allAbove18 = students.All(s => s.Age > 18);
        Console.WriteLine(allAbove18 ? "Yes" : "No");

        //check if any studnts have age less than 18 using lambda expression and join
        var anyBelow18 = students.Any(s => s.Age < 18);
        Console.WriteLine(anyBelow18 ? "Yes" : "No");



//example of grouping



        //display city wise students count and sum also show name
        var cityWiseCount = students.GroupBy(s => s.City)
                                    .Select(g => new { g.Key, Count = g.Count(), Sum = g.Sum(s => s.Marks), Names = string.Join(", ", g.Select(s => s.Name)) });

        foreach (var i in cityWiseCount)
        {
            Console.WriteLine($"{i.Key} - {i.Count} - {i.Sum} - {i.Names}");
        }


        Console.WriteLine("--------------------------------------------------");
        List<int> list1 = new List<int> {3, 4, 5, 6, 7};
        List<int> list2 = new List<int> {6, 7, 8, 9, 10};
        var intersect = list1.Intersect(list2);
        Console.WriteLine(string.Join(", ", intersect));

        var union = list1.Union(list2);
        Console.WriteLine(string.Join(", ", union));

        var minus = list1.Except(list2);
        Console.WriteLine(string.Join(", ", minus));


        //Example of SelectMany in courses and students to get students with multiple courses
        var studentsWithMultipleCourses = students.Join(courses, s => s.Id, c => c.StudentId, (s, c) => new { s.Name, c.CourseName })
                                                 .GroupBy(sc => sc.Name)
                                                 .Where(g => g.Count() > 1)
                                                 .SelectMany(g => g.Select(sc => sc.CourseName));
        Console.WriteLine(string.Join(", ", studentsWithMultipleCourses));

        var result = orders.Select(o => o.Items);
        Console.WriteLine(string.Join(", ", result));
        foreach(var order in result)
        {
            foreach(var item in order)
            {
                Console.WriteLine(item);
            }
        }


        //Selec all with flatten the nested list
        var result2 = orders.SelectMany(o => o.Items);
        Console.WriteLine(string.Join(", ", result2));

        
        Console.WriteLine("Hello, LINQ!");
    }
}