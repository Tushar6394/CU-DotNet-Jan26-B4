using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter input: ");

        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string[] parts = input.Split('|');

        if (parts.Length != 5)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string gateCode = parts[0];
        string userInitialStr = parts[1];
        string accessLevelStr = parts[2];
        string isActiveStr = parts[3];
        string attemptsStr = parts[4];

        // Validate GateCode
        if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        if (userInitialStr.Length != 1 || !char.IsUpper(userInitialStr[0]))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }
        char userInitial = userInitialStr[0];

        if (!byte.TryParse(accessLevelStr, out byte accessLevel) || accessLevel < 1 || accessLevel > 7)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        if (!bool.TryParse(isActiveStr, out bool isActive))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        if (!byte.TryParse(attemptsStr, out byte attempts) || attempts > 200)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string status;

        if (!isActive)
            status = "ACCESS DENIED – INACTIVE USER";
        else if (attempts > 100)
            status = "ACCESS DENIED – TOO MANY ATTEMPTS";
        else if (accessLevel >= 5)
            status = "ACCESS GRANTED – HIGH SECURITY";
        else
            status = "ACCESS GRANTED – STANDARD";

        Console.WriteLine($"{"Gate".PadRight(10)}: {gateCode}");
        Console.WriteLine($"{"User".PadRight(10)}: {userInitial}");
        Console.WriteLine($"{"Level".PadRight(10)}: {accessLevel}");
        Console.WriteLine($"{"Attempts".PadRight(10)}: {attempts}");
        Console.WriteLine($"{"Status".PadRight(10)}: {status}");
    }
}

// The full log is read using a single Console.ReadLine() call, as required by
// the problem statement. The input is then split using the '|' character to
// separate GateCode, UserInitial, AccessLevel, IsActive, and Attempts.
// We convert input values into proper C# data types:
// - char for UserInitial
// - byte for AccessLevel and Attempts
// - bool for IsActive
// This ensures invalid or out-of-range values cannot be accepted.
// For validation, C# built-in character APIs are used 
// - char.IsLetter() checks if a character is a letter
// - char.IsDigit() checks if a character is a digit
// - char.IsUpper() checks if the letter is uppercase
// These methods provide fast, safe, and readable validation.
// Numeric values are parsed using byte.TryParse(), which prevents runtime
// crashes and ensures that only valid numbers are accepted.
// Boolean values are parsed using bool.TryParse() to ensure only true or false
// (case-insensitive) values are allowed.
// Null safety is handled by checking if the input is empty or null before processing, preventing unexpected runtime errors.
// The business logic simulates a real security system:
// - Inactive users are denied access
// - Users with too many attempts are blocked
// - High-level users get high-security access
// - Others get standard access
// The output is formatted using PadRight() so that all fields align cleanly,
// The program is executed using:
// Program.cs → dotnet build → dotnet run
// where .NET compiles the C# code into Intermediate Language (IL) and executes
// it using the Common Language Runtime (CLR).