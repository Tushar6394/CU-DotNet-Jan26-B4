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
internal class Program
{
    private static void Main(string[] args)
    {
        int n = 5;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == j || j == (n - i + 1))
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
            Console.WriteLine();
        }
    }
}