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
