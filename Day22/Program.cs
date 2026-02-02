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
// using System;
// using System.Text.RegularExpressions;
// namespace Day22
// {
//     internal class DemoRegex
//     {
//        static void Main(string[] args)
//         {
//             string Pan ="ABCDE1234F";
//             bool validpan = Regex.IsMatch(Pan, @"^[A-Z]{5}[0-9]{4}[A-Z]$");
//             Console.WriteLine(validpan);

//             string mob ="99887-76655";
//             bool validmob = Regex.IsMatch(mob, @"^[7-9]{2}[0-9]{3}-[0-9]{5}$");
//             Console.WriteLine(validmob);

//             string name= "Tushar";
//             bool validFirstname = Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}$");
//             Console.WriteLine(validFirstname);

//             string Fullname= "Tushar Singh";
//             bool validFullname = Regex.IsMatch(Fullname, @"^[A-Z]{1}[a-z]{2,}[ ][A-Z]{1}[a-z]{2,}$");
//             Console.WriteLine(validFullname);
//         }
//     }
// }
// Create an OLADriver class{
// 	Id, Name, VechileNo, Rides
// }
// Driver can take multiple rides List<Ride>
// Create a class Ride{
// 	RideID, From, To, Fare
// }

// Create App to create multiple Drivers(each driver with multiple rides)like make this also we have to multiple drivers like 10 on their own and display driver wise rides and total fare for each driver
// Display Driver wise rides and total fare for each driver 
using System;
namespace Day22
{
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }

        public OLADriver(int id, string name, string vehicleNo)
        {
            Id = id;
            Name = name;
            VehicleNo = vehicleNo;
            Rides = new List<Ride>();
        }

        public void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }
    }

    class Ride
    {
        public int RideID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }

        public Ride(int rideID, string from, string to, decimal fare)
        {
            RideID = rideID;
            From = from;
            To = to;
            Fare = fare;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();
            for (int i = 1; i <= 10; i++)
            {
                OLADriver driver = new OLADriver(i, $"Driver{i}", $"VEH{i:000}");
                for (int j = 1; j <= 3; j++)
                {
                    Ride ride = new Ride(j, $"Location{j}A", $"Location{j}B", 100 + (i * 10) + (j * 5));
                    driver.AddRide(ride);
                }
                drivers.Add(driver);
            }
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Driver ID: {driver.Id}, Name: {driver.Name}, Vehicle No: {driver.VehicleNo}");
                decimal totalFare = 0;
                foreach (var ride in driver.Rides)
                {
                    Console.WriteLine($"\tRide ID: {ride.RideID}, From: {ride.From}, To: {ride.To}, Fare: {ride.Fare}");
                    totalFare += ride.Fare;
                }
                Console.WriteLine($"\tTotal Fare for Driver {driver.Name}: {totalFare}\n");
            }
        }
    }
}