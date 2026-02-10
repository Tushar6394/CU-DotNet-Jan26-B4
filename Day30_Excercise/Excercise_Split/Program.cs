using System;
using System.Collections.Generic;

class ExpenseSplitter
{
    static void Main()
    {
        try
        {
            Console.Write("Enter number of people: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
                throw new Exception("Number of people must be greater than zero.");

            List<string> names = new List<string>(n);
            List<double> paid = new List<double>(n);

            double total = 0;

            // Input Lenge 
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                names.Add(Console.ReadLine());

                Console.Write($"Enter amount paid by {names[i]}: ");
                paid.Add(double.Parse(Console.ReadLine()));

                if (paid[i] < 0)
                    throw new Exception("Amount cannot be negative.");

                total += paid[i];
            }

            // equal share calculate karenge
            double share = total / n;

            Console.WriteLine("\n--- Expense Summary ---");
            Console.WriteLine("Total expense: " + total);
            Console.WriteLine("Each person should pay: " + share);

            // Balance section
            Console.WriteLine("\n--- Balance ---");

            double[] balance = new double[n];

            for (int i = 0; i < n; i++)
            {
                balance[i] = paid[i] - share;

                if (balance[i] > 0)
                {
                    Console.WriteLine(names[i] + " should receive : " + balance[i]);
                }
                else if (balance[i] < 0)
                {
                    Console.WriteLine(names[i] + " should pay : " + (-balance[i]));
                }
                else
                {
                    Console.WriteLine(names[i] + " is settled.");
                }
            }

            Console.WriteLine("\n--- Kaun kisko kitna dega ---");

            for (int i = 0; i < n; i++)
            {
                if (balance[i] > 0) 
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (balance[j] < 0) 
                        {
                            double amount = Math.Min(balance[i], -balance[j]);

                            if (amount > 0)
                            {
                                Console.WriteLine(names[j] + " pays " + amount + " to " + names[i]);

                                balance[i] -= amount;
                                balance[j] += amount;
                            }
                        }
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid numbers only.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
