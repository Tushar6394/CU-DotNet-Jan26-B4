// namespace GymManagementApplication

// {
//     internal class Program
//     {
//         static double calculateGymBill(bool tread, bool weight, bool zumba)
//         {
//             double bill = 1000.0;
//             if(tread || weight || zumba)
//             {
//                 if(tread)
//                 {
//                     bill += 500;
//                 }
//                 if(weight)
//                 {
//                     bill += 1000;
//                 }
//                 if(zumba)
//                 {
//                     bill += 1000;
//                 }
//             }
//             else
//             {
//                 Console.WriteLine("No service opted");
//             }
//             // 5% tax
//             bill += bill * 0.05;
//             return bill;

//         }

//         static void Main(string[] args)
//         {
//             Console.WriteLine("Welcome to Gym Management Application");
//             Console.WriteLine(new string ('-', 40));
//             Console.WriteLine("Base Membership Fee: 1000");
//             Console.WriteLine("cost of all services:");
//             Console.WriteLine("Treadmill: 500, Zumba: 1000, Weight-lifting: 1000");
//             Console.Write("Do you want to opt for Treadmill (y/n): ");
//             bool tread = Console.ReadLine().ToLower() == "y";
//             Console.Write("Do you want to opt for Weight Training (y/n): ");
//             bool weight = Console.ReadLine().ToLower() == "y";
//             Console.Write("Do you want to opt for Zumba (y/n): ");
//             bool zumba = Console.ReadLine().ToLower() == "y";
//             double totalBill = calculateGymBill(tread, weight, zumba);
//             Console.WriteLine($"Your total gym bill is: {totalBill}");


using System;
internal class Program
{
    public static void Main(string[] args)
    {
        PrintLine('-', 40);                 
        PrintLine('+', 40);             
        PrintLine('$', 60);         

        Console.ReadKey();
    }
    static void PrintLine(char ch, int count)
    {
        Console.WriteLine(new string(ch, count)); 
    }
}

//Create a method with 5 parameters return 
