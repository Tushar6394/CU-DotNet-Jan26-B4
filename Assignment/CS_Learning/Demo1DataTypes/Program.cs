/*class demo1DataTypes
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Demo of Data Types in C#");
    }
}

//Boxing 
class demo2Boxing
{
    public static void Main(string[] args)
    {
        int num = 123;
        object obj = num;
        Console.WriteLine("Boxed value: " + obj);
    }
}
*/

//modify the code and display the name also above the age get the age of the person in a single line and display in the single line the age and message you are able to code or not above the age 18 or below the age 18 and also //Display odd number from 1 to the age in a single line with spacing and dont use for loop for displaying odd numbers and dont show the sepearate line for name and age only Enter your name and age this is enough
using System;
class demo3UserInput
{
    public static void main(string[] args)
    {
        Console.WriteLine("Enter your name and age:");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');
        string name = parts[0];
        int age = int.Parse(parts[1]);

        Console.WriteLine($"Name: {name}, Age: {age}");

        if (age >= 18)
        {
            Console.WriteLine("You are able to code.");
        }
        else
        {
            Console.WriteLine("You are not able to code.");
        }

        Console.Write("Odd numbers from 1 to " + age + ": ");
        PrintOddNumbers(age, 1);
    }

    static void PrintOddNumbers(int max, int current)
    {
        if (current > max) return;
        if (current % 2 != 0)
        {
            Console.Write(current + " ");
        }
        PrintOddNumbers(max, current + 1);
    }
}