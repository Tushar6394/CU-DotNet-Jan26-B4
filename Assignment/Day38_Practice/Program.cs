using System;
namespace Day38_Practice
{
    class Program
    {
        public string CleanseAndInvert(string input)
        {
            // Check if input is null or less than 6 characters
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return string.Empty;
            }

            // Check for spaces, digits, or special characters
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c) || char.IsDigit(c) || !char.IsLetter(c))
                {
                    return string.Empty;
                }
            }

            // Convert to lowercase
            input = input.ToLower();

            // Remove characters with even ASCII values and reverse the remaining characters
            string result = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if ((int)input[i] % 2 != 0) // Check for odd ASCII value
                {
                    result += input[i];
                }
            }

            // Convert even positioned characters to uppercase
            char[] resultArray = result.ToCharArray();
            for (int i = 0; i < resultArray.Length; i++)
            {
                if (i % 2 == 0) // Even position (0-based index)
                {
                    resultArray[i] = char.ToUpper(resultArray[i]);
                }
            }

            return new string(resultArray);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            
            Console.WriteLine("Enter the word");
            string userInput = Console.ReadLine();

            string generatedKey = program.CleanseAndInvert(userInput);
            
            if (string.IsNullOrEmpty(generatedKey))
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine($"The generated key is - {generatedKey}");
            }
        }
    }
}



