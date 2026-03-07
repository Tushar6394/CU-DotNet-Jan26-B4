// Assignment: The Daily Logger
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"..\..\..\journal.txt";

        Console.WriteLine("Enter your Daily Reflection:");
        string reflection = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("Date: " + DateTime.Now);
            writer.WriteLine(reflection);
            writer.WriteLine("-----------------------------");
        }

        Console.WriteLine("Your reflection has been saved successfully.");
    }
}
