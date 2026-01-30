
/*
using System.Collections.Specialized;

namespace DAY10METHODS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting demo");
            SayHello();
            Console.WriteLine("calling SayHello method again");
            SayHello("sahil");

            //demoMethods obj = new demoMethods();
            //obj.classAnotherClassMethod();

            demoMethods.classAnotherClassMethod();

            int square = GetSquare(10);
            Console.WriteLine($"square of taken number is: {square}");

            // ================= METHOD WITH RETURN TYPE ================= 
            static int GetSquare(int num1)
            {
                return num1 * num1;
            }

            // ================= METHOD RETURNUNG ARRAY ================= 

            int[] results = GetOddNumber(10);
            Console.WriteLine($"Odd numbers are: {string.Join(',', results)}");

            static int[] GetOddNumber(int num)
            {
                int size = num % 2 == 0 ? num / 2 : (num / 2) + 1;
                Console.WriteLine(size);
                int[] arr = new int[size];

                int index = 0;
                for(int i = 1; i <= num; i = i+2)
                {
                    arr[index] = i;
                    index++;
                }

                return arr;
            }


        }
        public static void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }
        // METHOD OVERLOADING
        public static void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
    }

    class demoMethods
    {
        //static void demo()
        //{
        //    Console.WriteLine("Demo method in demoMethods class");
        //}

        public static void classAnotherClassMethod()
        {
            //Console.WriteLine("Method in another class");
            // if static is not there then create class object to call the method
            //Program classObj = new Program();
            //classObj.SayHello();
            Program.SayHello();
            Console.WriteLine("classAnotherClassMethod called");

            
        }
    }
}
*/

//create 2 array to store 5 student names
//and to store 5 students marks respectively
//create a method to get student name with highest marks

using System;
namespace DAY10METHODS
{
    internal class Program
    {        static void Main(string[] args)
        {
            string[] studentNames = { "Tushar", "Sahil", "Hrithil", "Agam", "Nandini" };
            int[] studentMarks = { 85, 92, 78, 90, 88 };

            string topStudent = GetTopStudent(studentNames, studentMarks);
            Console.WriteLine($"Top student is : {topStudent}");
        }
        static string GetTopStudent(string[] names, int[] marks)
        {
            int highestMarks = -1;// assuming marks are non-negative
            string topStudent = "";// to store name of top student
            for(int i =0; i< names.Length; i++)//iterate through all students
            {
                if(marks[i]> highestMarks) //check if current student has highest marks
                {
                    highestMarks  = marks[i]; //update highest marks
                    topStudent = names[i]; //update top student name 
                }
            }
            return topStudent;
        }
    }      
}
