using System;
using System.IO;
using System.Collections.Generic;

public class Loan
{
    public string ClientName { get; set; }
    public double Principal { get; set; }
    public double InterestRate { get; set; }
}
class Program
{
    static void Main()
    {
        string filePath = @"../../../loan.csv";

        // Create file with header if not exists
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("ClientName,Principal,InterestRate");
            }
        }
        // ===== APPEND NEW LOAN =====
        Console.WriteLine("Enter Client Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Principal:");
        double principal = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Interest Rate:");
        double rate = double.Parse(Console.ReadLine());

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine($"{name},{principal},{rate}");
        }

        Console.WriteLine("\nLoan saved successfully.\n");
        List<Loan> loans = new List<Loan>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); 

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 3 &&
                    double.TryParse(parts[1], out double p) &&
                    double.TryParse(parts[2], out double r))
                {
                    loans.Add(new Loan
                    {
                        ClientName = parts[0],
                        Principal = p,
                        InterestRate = r
                    });
                }
            }
        }
        // ===== DISPLAY RESULTS =====
        Console.WriteLine("Loan Portfolio Analysis:\n");

        foreach (var loan in loans)
        {
            double interestAmount = loan.Principal * loan.InterestRate / 100;

            string risk;
            if (loan.InterestRate > 10)
                risk = "High Risk";
            else if (loan.InterestRate >= 5)
                risk = "Medium Risk";
            else
                risk = "Low Risk";

            Console.WriteLine(
                $"{loan.ClientName} | " +
                $"Principal: {loan.Principal:C} | " +
                $"Rate: {loan.InterestRate}% | " +
                $"Interest: {interestAmount:C} | " +
                $"Risk Level: {risk}"
            );
        }
    }
}
