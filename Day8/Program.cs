//Print 1 5 2 4 3 3 4 2 5 1 in a single line using single for loop
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.Write(i + " ");
            Console.Write((6 - i) + " ");
        }
        Console.WriteLine();
    }
}
