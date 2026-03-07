using System;
using System.Collections.Generic;
namespace KitchenElectricAppliances
{
    public abstract class Appliance
    {
        public string ModelName{get; set;}
        public int PowerWatts{get; set;}
        public abstract void Cook();
        public virtual void Preheat()
        {
            Console.WriteLine("No preheating required.");
        }
    }
    //Timer Interface 
    public interface ITimer
    {
        void SetTimer(int minutes);
    }

    //Wifi Interface
    public interface IWiFi
    {
        void ConnectToWiFi(string network);
    }

    //Microwave
    public class Microwave : Appliance, ITimer
    {
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Microwave time set for " + minutes + " minutes.");
        }
        public override void Cook()
        {
            Console.WriteLine("Microwave is cooking food.");
        }
    }

    //Electric Oven
    public class ElectricOven : Appliance, ITimer, IWiFi
    {
        public void SetTimer(int minutes)
        {
            Console.WriteLine("Oven time set for " + minutes + " minutes.");
        }
        public void ConnectToWiFi(string network)
        {
            Console.WriteLine("Oven connected to Wifi: " + network);
        }public override void Preheat()
        {
            Console.WriteLine("Oven is preheating");
        }
        public override void Cook()
        {
            Preheat();
            Console.WriteLine("Oven is cooking food.");
        }
    }

    //Air Fryer
    public class AirFryer : Appliance
    {
        public override void Cook()
        {
            Console.WriteLine("Air Fryer is cooking food.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> devices = new List<Appliance>
            {
                new Microwave { ModelName = "MW-101", PowerWatts=700},
                new ElectricOven {ModelName = "EO-500", PowerWatts=1500},
                new AirFryer { ModelName = "AF-202", PowerWatts=1200}
            };

            //Polymorphic Cooking
            foreach(var device in devices)
            {
                Console.WriteLine($"Device: " + device.ModelName);
                device.Cook();
                Console.WriteLine();
            }

            //Wifi only for Oven
            ElectricOven oven = new ElectricOven
            {
                ModelName = "OV-300",
                PowerWatts = 1800
            };
            oven.ConnectToWiFi("Home_Network");
        }
    }
}