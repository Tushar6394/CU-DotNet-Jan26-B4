using System.Text.Json;
namespace LINQLearning
{
internal class Program
{
    static void Main(string[] args)
    {
        List<Laptop> laptops = new List<Laptop>()
            {
                new Laptop
                {
                    LaptopId = 1,
                    ModelName = "XPS 13",
                    Price = 100000 
                },
                new Laptop
                {
                    LaptopId = 2,
                    ModelName = "MacBook Pro",
                    Price = 150000 
                },
                new Laptop
                {
                    LaptopId = 3,
                    ModelName = "Spectre x360",
                    Price = 120000
                }
            };
            string jsonFile = @"laptops.json";
            // JsonSerializerOptions options = new JsonSerializerOptions
            // {
            //     WriteIndented = true
            // };
            // var serData = JsonSerializer.Serialize(laptops, options);
            // File.WriteAllText(jsonFile, serData);
            string jsonData = File.ReadAllText(jsonFile);
            var result = JsonSerializer.Deserialize<List<Laptop>>(jsonData);
            foreach(var laptop in result)
            {
                Console.WriteLine($"ModelName: {laptop.ModelName}");
            }
            Console.WriteLine("Done..");
            
        }
    }
}