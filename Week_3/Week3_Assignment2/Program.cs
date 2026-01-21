//Application Context
//You are developing a text analysis utility used in an educational platform to evaluate basic string processing skills.
//Method Contract(Mandatory): int CountVowels(string input)
//Sample Inputs and Expected Outputs:
//Input String.               Output 
//"Hello World"                 3
//"BCDF"                        0
//"AEIOUaeiou"                  10
// " "                          0
// null                         0
using System;
namespace Week3_Assignment2
{
    public class Program
    {
        public static int CountVowels(string input)
        {
            int count = 0;
            if(input == "" || input == null)
            {
                return 0;
            }
            input = input.ToLower();
            for(int i=0; i<input.Length; i++)
            {
                if(input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                {
                    count++;
                }
            }
            return count;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to count vowels:");
            string input = Console.ReadLine();
            int vowelCount = CountVowels(input);
            Console.WriteLine($"The number of vowels in the input is: {vowelCount}");
        }
    }
}