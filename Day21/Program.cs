// //Quest- Count the frequency of each character in a given string and display the results.and Use Dictionar Approach 
// using System; 
// namespace Day21 { 
//     internal class Program { 
//         static void Main(string[] args) 
//         { 
//             string sentence = "My name is Tushar Singh and I am Learning Dot Net"; 
//             sentence = sentence.ToLower(); 
//             int[] counts = new int[26]; 
//             foreach (char c in sentence) 
//             { 
//                 if (c >= 'a' && c <= 'z') 
//                 { 
//                     counts[c - 'a']++; 
//                 } 
//             } 
//             for (int i = 0; i < counts.Length; i++) 
//             { 
//                 if (counts[i] > 0) 
//                 { 
//                     Console.WriteLine($"{(char)(i + 'a')} - {counts[i]}"); 
//                 } 
//             } 
//         } 
//     } 
// }
// using System;
// using System.Collections.Generic;
// namespace Day21
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             string sentence = "My name is Tushar Singh and I am Learning Dot Net";
//             sentence = sentence.ToLower();
//             Dictionary<char, int> letterCounts = new Dictionary<char, int>();
//             foreach (char c in sentence)
//             {
//                 if (c >= 'a' && c <= 'z') 
//                 {
//                     if (letterCounts.ContainsKey(c))
//                     {
//                         letterCounts[c]++;
//                     }
//                     else
//                     {
//                         letterCounts[c] = 1; 
//                     }
//                 }
//             }
//             foreach (var pair in letterCounts)
//             {
//                 Console.WriteLine($"{pair.Key} - {pair.Value}");
//             }
//         }
//     }
// }




//Dictionary Approach
// using System;
// namespace Day21
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Dictionary<string, string> countryCapitals= new Dictionary<string, string>();

//             countryCapitals.Add("India", "Delhi");
//             countryCapitals.Add("USA", "Washington D.C.");
//             countryCapitals.Add("UK", "London");
//             countryCapitals.Add("Germany", "Berlin");
//             countryCapitals.Add("France", "Paris");
//             countryCapitals["Japan"] = "Tokyo"; // Another way to add key-value pair
//             countryCapitals["India"] = "New Delhi"; // Update value for existing key
//             if (!countryCapitals.ContainsKey("India"))
//             {
//                 countryCapitals.Add("India", "New Delhi");
//             }
//             else
//             {
//                 Console.WriteLine("Key already exists.");
//             }
//             foreach (KeyValuePair<string, string> item in countryCapitals)
//             {
//                 Console.WriteLine($"{item.Key} - {item.Value}");
//             }
//             Console.WriteLine("All the countries in my collection:");
//             foreach (string country in countryCapitals.Keys)
//             {
//                 Console.WriteLine(country);
//             }
//             Console.WriteLine("All the capitals in my collection:");
//             foreach (string capital in countryCapitals.Values)
//             {
//                 Console.WriteLine(capital);
//             }
//             Console.Write("Enter country name to get its capital:");
//             string countryName = Console.ReadLine();
//             string cap = string.Empty;
//             bool existing = countryCapitals.TryGetValue(countryName, out cap);
//             if(existing){
//                 Console.WriteLine($"{cap}");
//             }
//             else{
//                 Console.WriteLine("Country not found.");
//             }
//         }
//     }
// }


//create an entity class student with properties - Id, Name, Marks
//Create a StudentManager class to manage students database in terms of a dictionary<int, student>
//The class should facilitate all CRUD operations like AddStudent, DeleteStudent, UpdateStudent, SearchStudent, DisplayAllStudents
//Create a class to use the UseStudentManager class.
// using System;
// namespace StudentManagement
// {
//     class Student
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//         public int Marks { get; set; }
//         override public string ToString()
//         {
//             return $"ID: {Id}, Name: {Name}, Marks: {Marks}";
//         }
//     }
//     class StudentManager
//     {
//         Dictionary<int, Student> studentsData = new Dictionary<int, Student>();
//         public bool AddStudent(Student student)
//         {
//             if (!studentsData.ContainsKey(student.Id))
//             {
//                 studentsData.Add(student.Id, student);
//                 return true;
//             }
//                 return false;
//             }
//             public bool UpdateStudent(int id, int marks)
//         {
//             Student foundStudent = SearchStudent(id); 
//             if(foundStudent!= null)
//             {
//                 foundStudent.Marks = marks;
//                 return true;
//             }
//             return false;
//         }
//          public bool DeleteStudent(int id)
//         {
//                 return studentsData.Remove(id);
//         }
        
//         public Student SearchStudent(int id)
//         {
//             Student student = null;
//             bool found = studentsData.TryGetValue(id, out student);
//             return student;
//         }
//             public void DisplayAllStudents()
//         {
//             foreach(var student in studentsData)
//             {
//                 Console.WriteLine(student.Value);
//             }
//         }
//         }
//         internal class Program
//     {
//         static void Main(string[] args)
//         {
//             StudentManager manager = new StudentManager();
//             manager.AddStudent(new Student()
//             {
//                 Id = 111,
//                 Name = "Student1",
//                 Marks = 85
//             });
//             manager.AddStudent(new Student()
//             {
//                 Id = 112,
//                 Name = "Student2",
//                 Marks = 90
//             });
//             int searchId = 115;
//             Student foundStudent = manager.SearchStudent(111);
//             if (foundStudent != null)
//             Console.WriteLine($"Student with {searchId} ID not found");
//             else
//             Console.WriteLine("Student found:");
//              Console.WriteLine("----------------------------------");
//             bool updated = manager.UpdateStudent(112, 95);
//             if (updated)
//             {
//                 Console.WriteLine(manager.SearchStudent(112));
//             }
//             Console.WriteLine("----------------------------------");

//             bool deleted =manager.DeleteStudent(111);
//             if (deleted)
//             {
//                 Console.WriteLine("Student deleted successfully.");
//             }
//             Console.WriteLine("----------------------------------");
//             manager.DisplayAllStudents();
//         }
//     }
//     }

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


//create a string with dummy pan card numbers we have to create a method validate the pan numbers also like if pan number is true then print valid number otherwise false