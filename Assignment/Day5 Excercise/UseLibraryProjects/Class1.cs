using System;
// library name for MyMath
using MyMathLibrary;
using MyClassLibrary;
namespace UseLibraryProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = MyMath.GetDouble(11);
            ConsoleTraceListener.WriteLine(result);
            Console.WriteLine("Library Project Console Application Running...");
        }
    }
}