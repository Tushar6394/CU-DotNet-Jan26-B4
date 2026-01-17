using System;
namespace InsurancePremiumSummary
{
    internal class Week2_Assessment
    {
        static void Main(string[] args)
        {
            const int policyHolderCount = 5;
            string[] policyHolderNames = new string[policyHolderCount];
            decimal[] annualPremiums = new decimal[policyHolderCount];
            for (int i = 0; i < policyHolderCount; i++)
            {
                Console.WriteLine($"\nEnter details for policyholder #{i + 1}");
                string name;
                while (true)
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("Name cannot be empty. Please re-enter.");
                }
                decimal premium;
                while (true)
                {
                    Console.Write("Annual Premium: ");
                    string premiumInput = Console.ReadLine();
                    if (!decimal.TryParse(premiumInput, out premium) || premium <= 0)
                    {
                        Console.WriteLine("Premium must be a valid number greater than 0. Please re-enter.");
                    }
                    else
                    {
                        break;
                    }
                }
                policyHolderNames[i] = name;
                annualPremiums[i] = premium;
            }
            decimal totalPremium = 0m;
            decimal highestPremium = annualPremiums[0];
            decimal lowestPremium = annualPremiums[0];
            for (int i = 0; i < policyHolderCount; i++) 
            {
                decimal premium = annualPremiums[i]; 
                totalPremium += premium;

                if (premium > highestPremium)
                    highestPremium = premium;

                if (premium < lowestPremium)
                    lowestPremium = premium;
            }

            decimal averagePremium = totalPremium / policyHolderCount;
            Console.WriteLine();
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine(new string('-', 25));
            string nameHeader = "Name";
            string premiumHeader = "Premium";
            string categoryHeader = "Category";

            Console.WriteLine(
                nameHeader.PadRight(15) +
                premiumHeader.PadRight(15) +
                categoryHeader.PadRight(10));

            Console.WriteLine(new string('-', 40));
            for (int i = 0; i < policyHolderCount; i++)
            {
                string nameUpper = policyHolderNames[i].ToUpper(); 
                decimal premium = annualPremiums[i]; //array se current policyholder ka annual premium nikal kar premium variable me store karta hai

                string category;
                if (premium < 10000m)
                {
                    category = "LOW";
                }
                else if (premium <= 25000m)
                {
                    category = "MEDIUM";
                }
                else
                {
                    category = "HIGH";
                }

                Console.WriteLine(
                    nameUpper.PadRight(15) +
                    premium.ToString("0.00").PadRight(15) + 
                    category.PadRight(10));
            }

            Console.WriteLine(new string('-', 40));

            Console.WriteLine($"Total Premium   : {totalPremium:0,0.00}");
            Console.WriteLine($"Average Premium : {averagePremium:0,0.00}");
            Console.WriteLine($"Highest Premium : {highestPremium:0,0.00}");
            Console.WriteLine($"Lowest Premium  : {lowestPremium:0,0.00}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
