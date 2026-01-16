# ############################################## Weekly Sales Analysis System #################################################################

1. The program starts from the Main() method and initializes two arrays to store daily sales values and their corresponding sales categories.
<!-- static void Main(string[] args)
{
    decimal[] dailySales = new decimal[7];
    string[] salesCategories = new string[7]; -->

2. Sales data for seven days is captured using "Console.ReadLine()" with continuous validation until a valid, non-negative number is entered.
    <!-- CaptureWeeklySales(dailySales); -->
    <!-- string input = Console.ReadLine(); -->

3. Input validation is handled using decimal.TryParse() to safely convert string input into decimal values and prevent runtime errors.
    <!-- if (decimal.TryParse(input, out decimal saleAmount)) -->

4. Negative sales values are rejected to ensure realistic and meaningful sales data.
<!-- if (saleAmount >= 0)
{
    sales[i] = saleAmount;
}
else
{
    Console.WriteLine("Error: Sales cannot be negative.");
} -->

5. Total weekly sales are calculated by iterating through the sales array and summing all daily values.
<!-- static decimal CalculateTotalSales(decimal[] sales)
{
    decimal total = 0;
    for (int i = 0; i < sales.Length; i++)
    {
        total += sales[i];
    }
    return total;
} -->

6. Average daily sales are computed by dividing the total sales by the number of days.
<!-- static decimal CalculateAverageSales(decimal[] sales)
{
    decimal total = CalculateTotalSales(sales);
    return total / sales.Length;
} -->

7. The highest sales day is determined by comparing all daily sales values and returning both the amount and the day number using a tuple.
<!-- static (decimal amount, int dayNumber) FindHighestSalesDay(decimal[] sales)
if (sales[i] > highest)
{
    highest = sales[i];
    dayNumber = i + 1;
} -->

8. The lowest sales day is identified using similar comparison logic to track the minimum sales value and its day.
<!-- static (decimal amount, int dayNumber) FindLowestSalesDay(decimal[] sales)
if (sales[i] < lowest)
{
    lowest = sales[i];
    dayNumber = i + 1;
} -->

9. The program counts how many days have sales greater than the calculated average.
<!-- static int CountDaysAboveAverage(decimal[] sales, decimal average)
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
} -->

10. Each day’s sales amount is categorized as Low, Medium, or High using predefined threshold values.
<!-- static void CategorizeSales(decimal[] sales, string[] categories)
{
    if (sales[i] < 5000)
        categories[i] = "Low";
    else if (sales[i] <= 15000)
        categories[i] = "Medium";
    else
        categories[i] = "High";
} -->

11. A well-formatted weekly sales report is displayed, showing totals, averages, highest and lowest sales, and category details.
<!-- Console.WriteLine($"Total Sales        : ₹{totalSales:N2}");
Console.WriteLine($"Average Daily Sale : ₹{averageSales:N2}");
Console.WriteLine($"Highest Sale       : ₹{highestAmount:N2} (Day {highestDay})");
Console.WriteLine($"Lowest Sale        : ₹{lowestAmount:N2} (Day {lowestDay})"); -->

12. Display Day-wise category details
<!-- Console.WriteLine($"Day {i + 1} : {categories[i]} (₹{sales[i]:N2})"); -->

12. The program waits for a key press before exiting to allow the user to review the output.
<!-- Console.WriteLine("\nPress any key to exit...");
Console.ReadKey(); -->
