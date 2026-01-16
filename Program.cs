
/*using System;

class Code
{
    static void Main(string[] args)
    {
        int x = 1000;

        Console.WriteLine(
            "int data type: Min = " + int.MinValue + 
            ", Max = " + int.MaxValue + 
            ", My value x = " + x
        );
    }
}
*/
﻿//Method 
//Main() is entry point method
//(accessmodifier) (static) returnType NameOfFunctions(parameters){}
//method default access specifier is private
//class default access specifier is internal
// parameteres are arguments
//arguments will be passed when calling methods
using System;
namespace Day10Methods
{
    internal class NewMethods
    {
        public void SayHello()
        {
            Console.WriteLine("Hello!");
        }

        // Method Overloading
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

    class DemoMethods
    {
        void CallAnotherMethod()
        {
            NewMethods classobj = new NewMethods();
            classobj.SayHello();
            classobj.SayHello("Tushar");
        }

        static void Main(string[] args)
        {
            DemoMethods demo = new DemoMethods();
            demo.CallAnotherMethod();
        }
    }
}





/*
//main() is the entry point method
//create a method to return the max values of the int array passed and make it user can it own input and dont make the array limit fixed
using System;
internal class Program
{
     static void Main(string[] args)
    {
        int n;
        Console.Write("Enter number of elements in the array: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer: ");
        }

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write($"Invalid input. Please enter an integer for element {i + 1}: ");
            }
        }

        int maxValue = FindMaxValue(numbers);
        Console.WriteLine($"The maximum value in the array is: {maxValue}");
    }

    static int FindMaxValue(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
}
*/
