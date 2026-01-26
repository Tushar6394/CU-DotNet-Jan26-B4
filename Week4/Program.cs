//Make stone paper scissors game
using System;
namespace DayWiseDemo
{
    class Program
    {
        static void Main()
        {
            string[] choices = { "stone", "paper", "scissors" };
            Random rand = new Random();
            string computerChoice = choices[rand.Next(choices.Length)];

            Console.Write("Enter your choice (stone, paper, scissors): ");
            string userChoice = Console.ReadLine().ToLower();

            Console.WriteLine($"Computer chose: {computerChoice}");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((userChoice == "stone" && computerChoice == "scissors") ||
                     (userChoice == "paper" && computerChoice == "stone") ||
                     (userChoice == "scissors" && computerChoice == "paper"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Computer wins!");
            }
        }
    }
}