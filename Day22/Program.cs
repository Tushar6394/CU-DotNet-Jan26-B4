//create a string with dummy pan card numbers we have to create a method validate the pan numbers also like if pan number is true then print valid number otherwise false use simple method and make user take inputon their own give me single line code
// using System;
// namespace Day22
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Enter PAN card number to validate:");
//             string userInput = Console.ReadLine();
//             bool isValid = ValidatePanNumber(userInput);
//             if (isValid)
//             {
//                 Console.WriteLine("Valid PAN number.");
//             }
//             else
//             {
//                 Console.WriteLine("Invalid PAN number.");
//             }
//         }
//         static bool ValidatePanNumber(string panNumber)
//         {
//             if (panNumber.Length != 10)
//                 return false;

//             for (int i = 0; i < 5; i++)
//             {
//                 if (!char.IsLetter(panNumber[i]))
//                     return false;
//             }

//             for (int i = 5; i < 9; i++)
//             {
//                 if (!char.IsDigit(panNumber[i]))
//                     return false;
//             }

//             if (!char.IsLetter(panNumber[9]))
//                 return false;

//             return true;
//         }
//     }
// }
using System;
using System.Text.RegularExpressions;
namespace Day22
{
    internal class DemoRegex
    {
       static void Main(string[] args)
        {
            string Pan ="ABCDE1234F";
            bool validpan = Regex.IsMatch(Pan, @"^[A-Z]{5}[0-9]{4}[A-Z]$");
            Console.WriteLine(validpan);

            string mob ="99887-76655";
            bool validmob = Regex.IsMatch(mob, @"^[7-9]{2}[0-9]{3}-[0-9]{5}$");
            Console.WriteLine(validmob);

            string name= "Tushar";
            bool validFirstname = Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}$");
            Console.WriteLine(validFirstname);

            string Fullname= "Tushar Singh";
            bool validFullname = Regex.IsMatch(Fullname, @"^[A-Z]{1}[a-z]{2,}[ ][A-Z]{1}[a-z]{2,}$");
            Console.WriteLine(validFullname);
        }
    }
}
