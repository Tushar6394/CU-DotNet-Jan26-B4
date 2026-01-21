// we have to print the student marks by taking the user input for 5 students and validate the marks also like if i give more than 100 or negative number it should ask again to enter the marks
using System;
namespace Day11
{
    internal class Day11Program
    {
        static void Main(string[] args)
        {
            string[] studentNames = new string[5];
            int[] studentMarks = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter name of student {i + 1}: ");
                studentNames[i] = Console.ReadLine();

                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter marks of {studentNames[i]} (0-100): ");
                    if (int.TryParse(Console.ReadLine(), out int marks) && marks >= 0 && marks <= 100)
                    {
                        studentMarks[i] = marks;
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter marks between 0 and 100.");
                    }
                }
            }
        }
    }
}