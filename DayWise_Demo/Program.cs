////Create a method to return the number is palindrome or not
// namespace DayWiseDemo{
//     class Program
//     {
//         static bool IsPalindrome(string word)
//         {
//             string reverse = "";
//             for(int i=word.Length-1; i>=0; i--)
//             {
//                 reverse += word[i];
//             }
//             return word == reverse;
//         }
//         static void Main()
//         {
//             Console.Write("Enter string: ");
//             string input = Console.ReadLine();
//             if (IsPalindrome(input))
//             {
//                 Console.WriteLine("It is Palindrome");
//             }
//             else
//             {
//                 Console.WriteLine("Not a Palindrome");
//             }
//         }
//     }
// }

//Using While Loop 
// namespace DayWiseDemo
// {
//     class Program
//     {
//         static bool IsPalindrome(string word)
//         {
//             string reverse = "";
//             int i = word.Length - 1;
//             while (i >= 0)
//             {
//                 reverse += word[i];
//                 i--;
//             }

//             return word == reverse;
//         }

//         static void Main()
//         {
//             Console.Write("Enter string: ");
//             string input = Console.ReadLine();

//             if (IsPalindrome(input))
//             {
//                 Console.WriteLine("It is Palindrome");
//             }
//             else
//             {
//                 Console.WriteLine("Not a Palindrome");
//             }
//         }
//     }
// }



//Fibonacci Series
// using System;

// class Program1
// {
//     // Method to print Fibonacci series
//     static void Fibonacci(int n)
//     {
//         int a = 0, b = 1, c;

//         Console.Write("Fibonacci Series: ");

//         for (int i = 1; i <= n; i++)
//         {
//             Console.Write(a + " ");

//             c = a + b;
//             a = b;
//             b = c;
//         }
//     }

//     static void Main()
//     {
//         Console.Write("Enter number of terms: ");
//         int n = Convert.ToInt32(Console.ReadLine());

//         Fibonacci(n);
//     }
// }

//Pattern Printing
// class Program2
// {
//     static void PrintPattern(int n)
//     {
//         for (int i = 1; i <= n; i++)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(j + " ");
//             }
//             Console.WriteLine();
//         }
//     }

//     static void Main()
//     {
//         Console.Write("Enter the number of rows: ");
//         int n = Convert.ToInt32(Console.ReadLine());

//         PrintPattern(n);
//     }
// }

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         for (char i = '1'; i <= '5'; i++)
//         {
//             for (char j = '1'; j <= i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//     }
// }

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int totalRows = 5;
//         for (int i = 1; i <= totalRows; i++)
//         {
//             for (int space = totalRows - i; space >= 1; space--)
//             {
//                 Console.Write(" ");
//             }
//             for (char j = 'A'; j < 'A' + i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//     }
// }


// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int totalRows = 5;
//         for (int i = 1; i <= totalRows; i++)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//         for (int i = totalRows - 1; i >= 1; i--)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//     }
// }

//  internal class Program
// {
//     private static void Main(string[] args)
//     {
//         for (int i = 1; i <= 5; i++, Console.WriteLine()) for (int j = 1; j <= i; j++) Console.Write(j);
//         for (int i = 4; i >= 1; i--, Console.WriteLine()) for (int j = 1; j <= i; j++) Console.Write(j);
//     }
// }

// pattern printing 1's and 0's( 1's in diagonals and 0's in other places)
// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int n = 5;
//         for (int i = 1; i <= n; i++)
//         {
//             for (int j = 1; j <= n; j++)
//             {
//                 if (i == j || j == (n - i + 1))
//                 {
//                     Console.Write("1 ");
//                 }
//                 else
//                 {
//                     Console.Write("0 ");
//                 }
//             }
//             Console.WriteLine();
//         }
//     }
// }

// Write a simple factorial program using recursion and also print all the numbers and print the values of n also in the output
//print in this format like 
//5
////3
/////2
//////1
//////2
/////6
////24
//120 
// using System;

// class Program
// {
//     static int Fact(int n, int space)
//     {
//         for (int i = 0; i < space; i++)
//             Console.Write("  ");

//         Console.WriteLine(n);

//         if (n == 1)
//             return 1;

//         int result = n * Fact(n - 1, space + 1);
//         for (int i = 0; i < space; i++)
//             Console.Write("  ");

//         Console.WriteLine(result);

//         return result;
//     }

//     static void Main()
//     {
//         int n = 5;
//         Fact(n, 0);
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Xml;

// namespace ClassPractice
// {
//     interface IDevice
//     {
//         void Print();
//     }
//     class Printer: IDevice 
//     {
//         public void Print()
//         {
//             Console.WriteLine("Printing");
//         }
//     }
//     class InkjetPrinter: IDevice
//     {
//         public void Print()
//         {
//             Console.WriteLine("InkjetPrinter");
//         }
//     }
//     class Computer
//     {
//         private IDevice device;

//         //private Printer p = new Printer();
//         public Computer(IDevice d)
//         {
//             device = d;
//         }

//         public void StartPrinting()
//         {
//             device.Print();
//             //p.Print();
//         }
//     }
//     internal class DIP
//     {
//         static void Main(string[] args)
//         {
//             IDevice device = new InkjetPrinter();
//             IDevice device1 = new Printer();
//             Computer c = new Computer(device);
//             Computer c1 = new Computer(device1);
//             //Computer c = new Computer();
//             c.StartPrinting();
//             c1.StartPrinting();
//         }
//     }
// }


///////////////Interface Segregation Principle Example //////////////////////////
using System;
interface IPrinter
{
    void Print();
}
interface IScanner
{
    void Scan();
}
class SimplePrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Simple Printer: Printing...");
    }
}

class MultiFunctionPrinter : IPrinter, IScanner
{
    public void Print()
    {
        Console.WriteLine("MultiFunction Printer: Printing...");
    }

    public void Scan()
    {
        Console.WriteLine("MultiFunction Printer: Scanning...");
    }
}

class Program
{
    static void Main()
    {
        SimplePrinter sp = new SimplePrinter();
        sp.Print();

        Console.WriteLine();

        MultiFunctionPrinter mp = new MultiFunctionPrinter();
        mp.Print();
        mp.Scan();
    }
}