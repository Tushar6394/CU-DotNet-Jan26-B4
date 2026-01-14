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