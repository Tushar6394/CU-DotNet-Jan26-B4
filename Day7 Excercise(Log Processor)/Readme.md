
1. The full log is read using a single Console.ReadLine() call, as required by the problem statement. The input is then split using the '|' character to separate GateCode, UserInitial, AccessLevel, IsActive, and Attempts.

2. We convert input values into proper C# data types:
--> char for UserInitial
--> byte for AccessLevel and Attempts
--> bool for IsActive
--> This ensures invalid or out-of-range values cannot be accepted.

3. For validation, C# built-in character APIs are used 
--> char.IsLetter() checks if a character is a letter
--> char.IsDigit() checks if a character is a digit
--> char.IsUpper() checks if the letter is uppercase
--> These methods provide fast, safe, and readable validation.

4. Numeric values are parsed using byte.TryParse(), which prevents runtime crashes and ensures that only valid numbers are accepted.

5. Boolean values are parsed using bool.TryParse() to ensure only true or false (case-insensitive) values are allowed.

6. Null safety is handled by checking if the input is empty or null before processing, preventing unexpected runtime errors.

7. The business logic simulates a real security system:
--> Inactive users are denied access
--> Users with too many attempts are blocked
--> High-level users get high-security access
--> Others get standard access

8. The output is formatted using PadRight() so that all fields align cleanly,
--> The program is executed using:
--> Program.cs → dotnet build → dotnet run
--> where .NET compiles the C# code into Intermediate Language (IL) and executes it using the Common Language Runtime (CLR).