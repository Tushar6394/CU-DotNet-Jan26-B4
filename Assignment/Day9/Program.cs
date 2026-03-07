using System;

namespace WeeklySalesAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] dailySales = new decimal[7];
            string[] salesCategories = new string[7];

            Console.WriteLine("=== Weekly Sales Analysis System ===\n");
            CaptureWeeklySales(dailySales);

            CategorizeSales(dailySales, salesCategories);

            DisplayWeeklyReport(dailySales, salesCategories);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        static void CaptureWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                bool validInput = false;
                
                while (!validInput)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ₹");
                    string input = Console.ReadLine();

                    if (decimal.TryParse(input, out decimal saleAmount)) 
                    {
                        if (saleAmount >= 0)
                        {
                            sales[i] = saleAmount;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Sales cannot be negative. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                    }
                }
            }
            Console.WriteLine(); 
        }

        static decimal CalculateTotalSales(decimal[] sales)
        {
            decimal total = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                total += sales[i];
            }
            return total;
        }
        static decimal CalculateAverageSales(decimal[] sales)
        {
            decimal total = CalculateTotalSales(sales);
            return total / sales.Length;
        }
        static (decimal amount, int dayNumber) FindHighestSalesDay(decimal[] sales)
        {
            decimal highest = sales[0];
            int dayNumber = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > highest)
                {
                    highest = sales[i];
                    dayNumber = i + 1;
                }
            }

            return (highest, dayNumber);
        }
        static (decimal amount, int dayNumber) FindLowestSalesDay(decimal[] sales)
        {
            decimal lowest = sales[0];
            int dayNumber = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < lowest)
                {
                    lowest = sales[i];
                    dayNumber = i + 1;
                }
            }

            return (lowest, dayNumber);
        }
        static int CountDaysAboveAverage(decimal[] sales, decimal average)
        {
            int count = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > average)
                {
                    count++;
                }
            }
            return count;
        }
        static void CategorizeSales(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                {
                    categories[i] = "Low";
                }
                else if (sales[i] <= 15000)
                {
                    categories[i] = "Medium";
                }
                else
                {
                    categories[i] = "High";
                }
            }
        }
        static void DisplayWeeklyReport(decimal[] sales, string[] categories)
        {
            decimal totalSales = CalculateTotalSales(sales);
            decimal averageSales = CalculateAverageSales(sales);
            var (highestAmount, highestDay) = FindHighestSalesDay(sales);
            var (lowestAmount, lowestDay) = FindLowestSalesDay(sales);
            int daysAboveAverage = CountDaysAboveAverage(sales, averageSales);

            Console.WriteLine("\n=== Weekly Sales Report ===");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Total Sales        : ₹{totalSales:N2}");
            Console.WriteLine($"Average Daily Sale : ₹{averageSales:N2}");
            Console.WriteLine();
            Console.WriteLine($"Highest Sale       : ₹{highestAmount:N2} (Day {highestDay})");
            Console.WriteLine($"Lowest Sale        : ₹{lowestAmount:N2} (Day {lowestDay})");
            Console.WriteLine();
            Console.WriteLine($"Days Above Average : {daysAboveAverage}");
            Console.WriteLine();
            Console.WriteLine("=== Sales Category Summary ===");
            for (int i = 0; i < sales.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]} (₹{sales[i]:N2})");
            }
        }
    }
}