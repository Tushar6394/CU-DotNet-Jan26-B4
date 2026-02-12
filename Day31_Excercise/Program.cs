using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// 1. Student Performance Analytics
/// </summary>
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
/// <summary>
/// 2. Employee Salary Processing System
/// </summary>

class Employee
{
    public int Id;
    public string Name;
    public string Dept;
    public double Salary;
    public DateTime JoinDate;
}
/// <summary>
/// 4. Library Book Management System
/// </summary>
class Book
{
    public string Title; 
    public string Author;
    public string Genre;
    public int Year;
    public double Price;
}

/// <summary>
/// 6. Movie Streaming Platform Query System
/// </summary>
class Movie
{
    public string Title;
    public string Genre;
    public double Rating;
    public int Year;
}
internal class Demo05LINQOperations
{
    static void Main(string[] args)
    {
///////////////////////////////////// Student Performance Analytics /////////////////////////////////////
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

        // //Display class with avg in the class
        // var classAvg = students.GroupBy(g => g.Class)
        //                         .Select(g=> 
        //                         new { Class = g.Key, 
        //                         Avg = g.Average(s => s.Marks) }
        //                         );
        // foreach(var avg in classAvg)
        // {
        //     Console.WriteLine(avg.Class + " - " + avg.Avg);
        // }

        //select field_list from table
        //sql filtering - row and column(row -- selecting and column -- projection)

//////////////////////////////////////// Employee Salary Processing System /////////////////////////////////////
        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
        };

        // var empJoinedAfter2020 = employees.
        //                 Where(e=>e.JoinDate.Year > 2020);
        // foreach(var emp in empJoinedAfter2020)
        // {
        //     Console.WriteLine("Emplyees joined after 2020: " + emp.Name);
        // }
        // Console.WriteLine("Done");


///////////////////////////////////// Library Book Management System /////////////////////////////////////


        var books = new List<Book>
        {
            new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
            new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
            new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
        };

        // //Find Book Published after 2015
        //  var PBooks = books.Where(b => b.Year > 2015);
        //  foreach(var book in PBooks)
        //  {
        //      Console.WriteLine("Books published after 2015: " + book.Title);
        //  }

        //  //Group by Genre and count books
        //  var genreGroups = books.GroupBy(g => g.Genre)
        //                         .Select(g => new { Genre = g.Key, Count = g.Count() });
        //  foreach(var group in genreGroups)
        //  {
        //      Console.WriteLine("Books Genre: " + group.Genre + ", Books Count: " + group.Count);
        //  }

        //  //Get most expensive book per genre
        //  var expensiveBooks = books.GroupBy(e=>e.Genre)
        //                             .Select(g => new { 
        //                             Genre = g.Key, ExpensiveBook = 
        //                             g.OrderByDescending(b => b.Price).FirstOrDefault() });
        // foreach(var book in expensiveBooks)
        // {
        //     Console.WriteLine("Most expensive book in Genre: " + book.Genre + " is " + book.ExpensiveBook.Title + " with price " + book.ExpensiveBook.Price);
        // }

        // //Return distinct authors list
        // var distinctAuthors = books.Select(d=>d.Author).Distinct();
        // foreach(var author in distinctAuthors)
        // {
        //     Console.WriteLine("Distinct Author: " + author);
        // }

/////////////////////////////////////Movie Streamin Platform Query System//////////////////////////////////////
       
        var movies = new List<Movie>
        {
            new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
            new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
            new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
        }; 

        //Filter movies with rating > 8
        var RatedMovies = movies.Where(m=>m.Rating > 8);
        foreach(var movie in RatedMovies)
        {
            Console.WriteLine("Movies with rating > 8: " + movie.Title);
        }

        //Group movies by Genre and get average rating
        var genreRating = movies.GroupBy(g=>g.Genre)
                                .Select(g => new { Genre = g.Key, AvgRating = g.Average(m => m.Rating) });
        foreach(var genre in genreRating)
        {
            Console.WriteLine("Genre: " + genre.Genre + ", Average Rating: " + genre.AvgRating);
        }

        //Find latest movie per Genre 

        var latestMovies = movies.GroupBy(l=>l.Genre)
                                .Select(g => new { Genre = g.Key, LatestMovie = g.OrderByDescending(m => m.Year).FirstOrDefault() });
        foreach(var movie in latestMovies)
        {
            Console.WriteLine("Latest movie in Genre: " + movie.Genre + " is " + movie.LatestMovie.Title + " released in " + movie.LatestMovie.Year);
        }

        //Get top 5 highest-rated movies
        var topRatedMovies = movies.OrderByDescending(t=>t.Rating).Take(5);
        foreach(var movie in topRatedMovies)
        {
            Console.WriteLine("Top Rated Movies: " + movie.Title + " with rating " + movie.Rating);
        }
    }
}

