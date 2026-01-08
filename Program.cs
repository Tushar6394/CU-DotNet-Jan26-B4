using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Exercise 1: Student Attendance & Eligibility System
            int totalDays = 180;
            int attendedDays = 150;
            double percentage = (double)attendedDays / totalDays * 100;
            int displayPercentage = (int)Math.Round(percentage); 
            Console.WriteLine($"Attendance Percentage: {displayPercentage}%");
            

            // Exercise 2: Online Examination Result Processing
            int[] marks = { 80, 90, 85, 95 };
            double average = Math.Round(marks.Average(), 2); 
            Console.WriteLine($"Average Marks: {average}");
            int scholarshipAverage = (int)Math.Round(average); 
            Console.WriteLine($"Scholarship Eligibility Average: {scholarshipAverage}");


            // Exercise 3: Library Fine Calculation System
            decimal finePerDay = 2.50m;
            int daysOverdue = 5;
            decimal totalFine = finePerDay * daysOverdue;
            double loggedFine = (double)totalFine;
            Console.WriteLine($"Total Fine (display): {totalFine:C}");
            Console.WriteLine($"Total Fine (logged): {loggedFine}");


            // Exercise 4: Banking Interest Calculation Module
            decimal balance = 10000.00m;
            float interestRate = 3.5f; 
            decimal monthlyInterest = balance * (decimal)interestRate / 100 / 12;
            balance += monthlyInterest;
            Console.WriteLine($"Updated Balance: {balance:C}");


            // Exercise 5: E-Commerce Order Pricing Engine
            double cartTotal = 999.99;
            decimal tax = 99.99m;
            decimal discount = 50.00m;
            decimal finalAmount = (decimal)cartTotal + tax - discount;
            Console.WriteLine($"Final Payable Amount: {finalAmount:C}");


            // Exercise 6: Weather Monitoring & Reporting
            short sensorReading = 250;
            double celsius = sensorReading / 10.0;
            double dailyAverage = 23.7;
            int dashboardTemp = (int)Math.Round(dailyAverage);
            Console.WriteLine($"Sensor Celsius: {celsius}");
            Console.WriteLine($"Dashboard Temp: {dashboardTemp}");


            // Exercise 7: University Grading Engine
            double finalScore = 87.5;
            byte grade;
            if (finalScore >= 90) grade = 10;
            else if (finalScore >= 80) grade = 9;
            else if (finalScore >= 70) grade = 8;
            else grade = 7;
            Console.WriteLine($"Grade: {grade}");


            // Exercise 8: Mobile Data Usage Tracker
            long usageBytes = 1073741824;
            double usageMB = usageBytes / (1024.0 * 1024);
            double usageGB = usageBytes / (1024.0 * 1024 * 1024);
            int monthlySummary = (int)Math.Round(usageGB);
            Console.WriteLine($"Usage in MB: {usageMB}");
            Console.WriteLine($"Usage in GB: {usageGB}");
            Console.WriteLine($"Monthly Summary (GB): {monthlySummary}");


            // Exercise 9: Warehouse Inventory Capacity Control
            int itemCount = 5000;
            ushort maxCapacity = 10000;
            bool isOverCapacity = itemCount > maxCapacity;
            Console.WriteLine($"Over Capacity: {isOverCapacity}");
            

            // Exercise 10: Payroll Salary Computation
            int basicSalary = 30000;
            double allowances = 5000.75;
            double deductions = 2000.25;
            decimal netSalary = basicSalary + (decimal)allowances - (decimal)deductions;
            Console.WriteLine($"Net Salary: {netSalary:C}");
        }
    }
}