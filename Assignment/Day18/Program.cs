// using System;
// namespace Day18
// {
//     internal class Program
//     {
//         static void Main(string [] args)
//         {
//             Console.Write("Enter numbers separated by spaces: ");
//             int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
//             Array.Sort(numbers);
//             Array.Reverse(numbers);
//             int secondHighest = Array.Find(numbers, n => n < numbers[0]);
//             Console.WriteLine(secondHighest != 0 ? $"The second highest number is: {secondHighest}" : "There is no second highest number.");
//         }
//     }
// }

// namespace Day18
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             int[] arr = { 34, 67, 23, 89, 2, 78, 56 };
//             Array.Sort(arr);
//             Array.Reverse(arr);
//             Console.WriteLine(arr[1]);
//         }
//     }
// }
//will equals methods work for UDT?
//answer: yes, but you need to override Equals and GetHashCode methods in your UDT class for proper comparison.

//write code of equals
// using System;
// namespace Day18
// {
//     internal class Program
//     {
//         class Person
//         {
//             public string Name { get; set; }
//             public int Age { get; set; }

//             public override bool Equals(object obj)
//             {
//                 if (obj is Person other)
//                 {
//                     return this.Name == other.Name && this.Age == other.Age;
//                 }
//                 return false;
//             }

//             public override int GetHashCode()
//             {
//                 return HashCode.Combine(Name, Age);
//             }
//         }

//         static void Main(string[] args)
//         {
//             Person person1 = new Person { Name = "Alice", Age = 30 };
//             Person person2 = new Person { Name = "Alice", Age = 30 };
//             Person person3 = new Person { Name = "Bob", Age = 25 };

//             Console.WriteLine(person1.Equals(person2)); // True
//             Console.WriteLine(person1.Equals(person3)); // False
//         }
//     }
// } 



////////////////////#Inheritance#////////////////////////

// namespace Day18_Inheritence
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             string str = "abcd";
//             char[] charr = str.ToCharArray();
//             Array.Reverse(charr);
//             string s2 = new string(charr);
//             Console.WriteLine(s2);
//         }
//     }
// }

//////#Example of inheritance

using System.Collections.Immutable;
using System.Reflection;

namespace DAY18
{
    internal class Program
    {
        class Person
        {
            public Person()
            {
                Console.WriteLine("Person Default Constructor");
                AadharId = 0;
                Name = string.Empty;
            }

            public Person(int id, string name)
            {
                AadharId = id;
                Name = name;
                Console.WriteLine("Person overloaded Constructor");
            }

            public int AadharId { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"AadharId - {AadharId} Name - {Name}";
            }

        }

        class Student : Person
        {
            public string Degree { get; set; }
            public string College { get; set; }

            public Student()
            {
                Console.WriteLine("Student Default Constructor");
                Degree = string.Empty;
                College = string.Empty;
            }

            public Student(string degree, string college)
            {
                Degree = degree;
                College = college;
            }

            public Student(int id,string name,string degree, string college): base(id,name)
            {
                Degree = degree;
                College = college;
                Console.WriteLine("Student overloaded Constructor");
            }

            override public string ToString()
            {
                return base.ToString() + $" Degree - {Degree} College - {College}";
            }

        }

        internal class Demo04Inheritance
        {
            static void Main(string[] args)
            {
                Student s1 = new Student(111,"Student1","CSE","CU");
                Console.WriteLine(s1);
            }
        }
    }
}