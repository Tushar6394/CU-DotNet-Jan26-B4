using System;
using System.Collections.Generic;
using System.IO;

namespace FreightSystem
{
    // Custom Exception 1
    public class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message)
            : base(message)
        {
        }
    }

    // Custom Exception 2
    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message)
            : base(message)
        {
        }
    }

    // Interface
    public interface ILoggable
    {
        void SaveLog(string message);
    }

    // Log Manager
    public class LogManager : ILoggable
    {
        private string filePath = "shipment_audit.log";

        public void SaveLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(DateTime.Now + " : " + message);
            }
        }
    }

    // Abstract Base Class
    public abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool Fragile { get; set; }
        public bool Reinforced { get; set; }

        protected List<string> restrictedZones = new List<string>
        {
            "North Pole",
            "Unknown Island"
        };

        public abstract void ProcessShipment();
    }

    // Express Shipment
    public class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Weight must be greater than zero.");

            if (restrictedZones.Contains(Destination))
                throw new RestrictedDestinationException("Restricted destination: " + Destination);

            if (Fragile && !Reinforced)
                throw new InsecurePackagingException("Fragile item must be reinforced.");

            Console.WriteLine("Express shipment " + TrackingId + " processed successfully.");
        }
    }

    // Heavy Freight
    public class HeavyFreight : Shipment
    {
        public bool HasHeavyLiftPermit { get; set; }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Weight must be greater than zero.");

            if (restrictedZones.Contains(Destination))
                throw new RestrictedDestinationException("Restricted destination: " + Destination);

            if (Fragile && !Reinforced)
                throw new InsecurePackagingException("Fragile item must be reinforced.");

            if (Weight > 1000 && !HasHeavyLiftPermit)
                throw new Exception("Heavy Lift permit required.");

            Console.WriteLine("Heavy freight " + TrackingId + " processed successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILoggable logger = new LogManager();

            List<Shipment> shipments = new List<Shipment>
            {
                new ExpressShipment
                {
                    TrackingId = "EXP001",
                    Weight = 10,
                    Destination = "Delhi",
                    Fragile = false,
                    Reinforced = false
                },
                new ExpressShipment
                {
                    TrackingId = "EXP002",
                    Weight = -5,
                    Destination = "Mumbai",
                    Fragile = false,
                    Reinforced = false
                },
                new ExpressShipment
                {
                    TrackingId = "EXP003",
                    Weight = 20,
                    Destination = "North Pole",
                    Fragile = false,
                    Reinforced = false
                },
                new HeavyFreight
                {
                    TrackingId = "HF001",
                    Weight = 1500,
                    Destination = "Chandigarh",
                    Fragile = true,
                    Reinforced = false,
                    HasHeavyLiftPermit = false
                }
            };

            foreach (var shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog("SUCCESS: " + shipment.TrackingId + " processed.");
                }
                catch (RestrictedDestinationException ex)
                {
                    logger.SaveLog("SECURITY ALERT: " + shipment.TrackingId + " - " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.SaveLog("DATA ERROR: " + shipment.TrackingId + " - " + ex.Message);
                }
                catch (Exception ex)
                {
                    logger.SaveLog("GENERAL ERROR: " + shipment.TrackingId + " - " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Processing attempt finished for ID: " + shipment.TrackingId);
                }
            }
        }
    }
}
