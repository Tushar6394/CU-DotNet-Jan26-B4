using System;
using System.IO;
using System.Collections.Generic;

namespace Week5_Assessment
{
    [Flags]
    public enum PackageState { None = 0, Fragile = 1, Reinforced = 2 }

    public class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; }
        public RestrictedDestinationException(string loc)
            : base($"Forbidden: {loc}")
        {
            DeniedLocation = loc;
        }
    }

    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string msg) : base(msg) { }
    }

    public interface ILoggable
    {
        void SaveLog(string msg);
    }

    public abstract class Shipment
    {
        public string TrackingId { get; init; }
        public double Weight { get; init; }
        public string Destination { get; init; }
        public PackageState State { get; init; }

        public abstract void ProcessShipment();
    }

    public sealed class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(Weight));

            if (State.HasFlag(PackageState.Fragile) &&
                !State.HasFlag(PackageState.Reinforced))
                throw new InsecurePackagingException("Packaging check failed.");

            Console.WriteLine($"Express {TrackingId} processed.");
        }
    }

    public sealed class HeavyFreight : Shipment
    {
        private static readonly string[] Blacklist =
            { "North Pole", "Unknown Island" };

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(Weight));

            if (Blacklist.Any(d =>
                d.Equals(Destination, StringComparison.OrdinalIgnoreCase)))
                throw new RestrictedDestinationException(Destination);

            if (Weight > 1000)
                Console.WriteLine("Heavy Lift permit required.");

            Console.WriteLine($"Freight {TrackingId} processed.");
        }
    }

    public class LogManager : ILoggable
    {
        public void SaveLog(string msg)
        {
            using var sw = new StreamWriter("shipment_audit.log", true);
            sw.WriteLine($"[{DateTime.Now}] {msg}");
        }
    }

    public static class Program
    {
        public static void Main()
        {
            ILoggable log = new LogManager();

            var pipeline = new List<Shipment>
            {
                new HeavyFreight { TrackingId = "TUS123", Weight = 12000, Destination = "Oslo" },
                new ExpressShipment { TrackingId = "SAI123", Weight = 100, State = PackageState.Fragile },
                new HeavyFreight { TrackingId = "AMA123", Weight = 400, Destination = "North Pole" }
            };

            foreach (var s in pipeline)
            {
                string res;

                try
                {
                    s.ProcessShipment();
                    res = $"SUCCESS: {s.TrackingId}";
                }
                catch (RestrictedDestinationException ex)
                {
                    res = $"SECURITY ALERT ({s.TrackingId}): {ex.Message}";
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    res = $"DATA ENTRY ERROR ({s.TrackingId}): {ex.Message}";
                }
                catch (InsecurePackagingException ex)
                {
                    res = $"PACKAGING ERROR ({s.TrackingId}): {ex.Message}";
                }
                catch (Exception ex)
                {
                    res = $"GENERAL ERROR ({s.TrackingId}): {ex.Message}";
                }
                finally
                {
                    Console.WriteLine(
                        $"Processing attempt finished for ID: {s.TrackingId}");
                }

                log.SaveLog(res);
            }
        }
    }
}
