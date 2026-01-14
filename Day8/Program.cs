//Print 1 5 2 4 3 3 4 2 5 1 in a single line using single for loop
/*using System;
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
*/




//=============================================================================================================================================





//If we don't want spaces between the entries
 /*   string cityNames = "Delhi,,Lucknow, ,CHD,   ,Noida";
    Console.WriteLine(cityNames);
    string[] cities = cityNames.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    for (int i=0; i < cities.Length; i++)
    {
        Console.WriteLine(cities[i]);
    }
*/




//=============================================================================================================================================




/* 
//Byte Conversion
//Conversion has 2 types
//1. Implicit Conversion - done by compiler automatically
byte b = 100;
int i = b; //implicit conversion from byte to int
Console.WriteLine("Byte value: " + b);
Console.WriteLine("Int value after implicit conversion from byte to int: " + i);
//Output will be 100 because int can hold larger range of values than byte


//2. Explicit Conversion - done by programmer manually
int j = 260;
byte c = (byte)j; //explicit conversion from int to byte
Console.WriteLine("Int value: " + j);
Console.WriteLine("Byte value after explicit conversion from int to byte: " + c); //
//Output will be 4 because 260 % 256 = 4
*/



//=============================================================================================================================================



/*
//Print Pattern 
//A
//AB
//ABC
//ABCD
//ABCDE
internal class Program
{
    private static void Main(string[] args)
    {
        for (char i = 'A'; i <= 'E'; i++)
        {
            for (char j = 'A'; j <= i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }
}
//Explaination:
//Outer loop runs from 'A' to 'E' controlling the number of rows
//Inner loop runs from 'A' to current value of outer loop variable 'i', printing characters in each row
//After inner loop completes for a row, Console.WriteLine() is called to move to the next line
*/


//=============================================================================================================================================



//Print Pattern 
//    A
//   AB
//  ABC
// ABCD
//ABCDE
//print this with spaces
internal class Program
{
    private static void Main(string[] args)
    {
        int totalRows = 5;
        for (int i = 1; i <= totalRows; i++)
        {
            for (int space = totalRows - i; space >= 1; space--)
            {
                Console.Write(" ");
            }
            for (char j = 'A'; j < 'A' + i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }
}
//Explaination:
//Outer loop runs from 1 to totalRows controlling the number of rows   
//First inner loop prints spaces before characters in each row
//Second inner loop prints characters from 'A' up to the current row number 