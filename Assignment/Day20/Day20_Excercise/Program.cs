using System;
using System.Collections;
using System.Collections.Generic;
namespace SkyHighFlightAggregator
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"FlightNumber: {FlightNumber}, Price: {Price}, Duration: {Duration}, DepartureTime: {DepartureTime}";
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Duration.CompareTo(y.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>
            {
                new Flight { FlightNumber = "SH101", Price = 150.00m, Duration = TimeSpan.FromHours(2), DepartureTime = new DateTime(2024, 7, 1, 8, 0, 0) },
                new Flight { FlightNumber = "SH202", Price = 120.00m, Duration = TimeSpan.FromHours(3), DepartureTime = new DateTime(2024, 7, 1, 6, 30, 0) },
                new Flight { FlightNumber = "SH303", Price = 200.00m, Duration = TimeSpan.FromHours(1.5), DepartureTime = new DateTime(2024, 7, 1, 9, 15, 0) },
                new Flight { FlightNumber = "SH404", Price = 180.00m, Duration = TimeSpan.FromHours(2.5), DepartureTime = new DateTime(2024, 7, 1, 7, 45, 0) }
            };

            // Economy View: Sort by Price
            flights.Sort();
            Console.WriteLine("Economy View (Sorted by Price):");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }

            // Business Runner View: Sort by Duration
            flights.Sort(new DurationComparer());
            Console.WriteLine("\nBusiness Runner View (Sorted by Duration):");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }

            // Early Bird View: Sort by Departure Time
            flights.Sort(new DepartureComparer());
            Console.WriteLine("\nEarly Bird View (Sorted by Departure Time):");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
    }
}