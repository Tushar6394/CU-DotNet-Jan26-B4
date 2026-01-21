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



/*
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
*/




//=============================================================================================================================================
/*
//Date and Time of Today
internal class Program
{
    static void Main(string[] args)
    {
        DateTime today = DateTime.Today;
        Console.WriteLine(today);
        Console.WriteLine($"{today:dd/MM/yyyy}");
        Console.WriteLine($"{today:ddd/MMM/yyyy}");
        Console.WriteLine($"{today:dddd/MMMM/yyyy}");

        DateTime now = DateTime.Now;
        Console.WriteLine(now);
    }
}
*/




//=============================================================================================================================================



/*

//String Immutability
internal class Program
{
    static void Main(string[] args)
    {
        string name = "Tuhsar";
        Console.WriteLine(name.GetHashCode());
        name = name + "Macbookair";
        Console.WriteLine(name.GetHashCode());

        //index is used as an indexer to access individual characters in the string
        //a topic in OOPs
        Console.WriteLine(name[3]);
    }
}
//explaination:
//Strings are immutable in C#. When we modify a string, a new string object is created in memory
//Defined in namespace System
//The GetHashCode() method returns a hash code for the string object, which changes when the string is modified
//In this example, the hash code changes after we append "Macbookair" to the original string "Tuhsar"
//This demonstrates that a new string object is created in memory after modification

//String Creation
//1. Using string literal
//string str1 = "Hello World";
//2. Using new keyword
//string str2 = new string(new char[] {'H', 'e', 'l', 'l', 'o'});
//3. Using String.Format
//string str3 = String.Format("Hello {0}", "World");
//4. Using String.Concat
//string str4 = String.Concat("Hello", " ", "World");
//5. Using String.Join
//string str5 = String.Join(" ", new string[] {"Hello", "World"});

//Important properties and methods of String class
//1. Length property - returns the length of the string
//2. string|index|
//3. IsNUllOrEmpty() - checks if the string is null or empty
//4. IsNullOrWhiteSpace() - checks if the string is null, empty, or consists only of white-space characters
//5. ToUpper() - converts the string to uppercase
//6. ToLower() - converts the string to lowercase
//7. Trim() - removes leading and trailing white-space characters
//8. Substring() - retrieves a substring from the string
//9. Split() - splits the string into an array of substrings based on a delimiter
//10. Replace() - replaces occurrences of a specified substring with another substring
//11. Contains() - checks if the string contains a specified substring
//12. IndexOf() - returns the index of the first occurrence of a specified substring
//13. StartsWith() - checks if the string starts with a specified substring
//14. EndsWith() - checks if the string ends with a specified substring
//15. Format() - formats a string using placeholders
//16. Concat() - concatenates multiple strings into one
//17. Join() - joins an array of strings into a single string with a specified separator
//18. GetHashCode() - returns a hash code for the string
*/




//Using Index

 string input = "A9";
 if(char.IsLetter(input[0]) && char.IsDigit(input[1]))
 {
    Console.WriteLine("Valid format"); 
 }
    else
    {
        Console.WriteLine("Invalid format");
    }